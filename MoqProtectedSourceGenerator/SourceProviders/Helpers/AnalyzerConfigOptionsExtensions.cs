using System;
using System.Linq;
using System.Reflection;
using Microsoft.CodeAnalysis.Diagnostics;

namespace MoqProtectedSourceGenerator
{

    public static class AnalyzerConfigOptionsExtensions
    {
        private static (bool converted, object value) ConvertValue(string value, Type toType)
        {
            if (toType == typeof(string))
            {
                return (true, value);
            }
            else
            {
                //do a case statement instead ?
                var tryParseMethods = toType.GetMethods(BindingFlags.Public | BindingFlags.Static).Where(m => m.Name == "TryParse");
                var tryParseMethod = tryParseMethods.FirstOrDefault(m => m.GetParameters().Length == 2);
                if (tryParseMethod != null)
                {
                    var args = new object[] { value, null };
                    var parsed = (bool)tryParseMethod.Invoke(null, args);
                    if (parsed)
                    {
                        return (true, args[1]);
                    }
                }
            }
            return (false, null);
        }

        public static void GetOption<T>(this AnalyzerConfigOptions analyzerConfigOptions, Option<T> option, OptionSearch optionSearch = OptionSearch.Both)
        {
            if (option.IsObject)
            {
                T instance = Activator.CreateInstance<T>();
                option.Value = instance;
                var properties = typeof(T).GetProperties();
                foreach (var property in properties)
                {
                    var propertyFinding = GetFinding(analyzerConfigOptions, option.Key + "_" + property.Name, property.PropertyType, optionSearch);
                    option.Findings.Add(propertyFinding);
                    if (propertyFinding.Converted)
                    {
                        property.SetValue(instance, propertyFinding.Value);
                    }
                }

            }
            else
            {
                var finding = GetFinding(analyzerConfigOptions, option.Key, typeof(T), optionSearch);
                option.Findings.Add(finding);
                if (finding.Converted)
                {
                    option.Value = (T)finding.Value;
                }
            }
        }
        private static Finding GetFinding(AnalyzerConfigOptions analyzerConfigOptions, string key, Type toType, OptionSearch optionSearch)
        {
            var msbuildKey = $"build_property.{key}";
            var firstSearchKey = optionSearch == OptionSearch.MSBuild ? msbuildKey : key;
            var found = analyzerConfigOptions.TryGetValue(firstSearchKey, out var value);
            if (!found && optionSearch == OptionSearch.Both)
            {
                found = analyzerConfigOptions.TryGetValue(msbuildKey, out value);
            }
            var finding = new Finding { Found = value, Key = key };
            if (found)
            {
                var (converted, convertedValue) = ConvertValue(value, toType);
                if (converted)
                {
                    finding.Converted = true;
                    finding.Value = convertedValue;
                }
            }
            return finding;
        }
    }

}
