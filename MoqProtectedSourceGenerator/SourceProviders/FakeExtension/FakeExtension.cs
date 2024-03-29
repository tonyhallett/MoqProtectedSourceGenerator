﻿using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;

namespace MoqProtectedSourceGenerator
{
    public class FakeExtension
    {
        private readonly Dictionary<string, List<IFakeExtensionMethodClass>> fakeExtensionMethodClassesByMethod = new();
        public FakeExtension(ProtectedLike protectedLike)
        {
            //foreach(var property in protectedLike.Properties)
            //{
            //    //todo
            //}

            foreach (var methodDetails in protectedLike.Methods)
            {
                var methodDeclaration = methodDetails.Declaration;
                var methodName = methodDeclaration.Identifier.ToString();

                if (!fakeExtensionMethodClassesByMethod.TryGetValue(methodName, out var overrideExtensionMethodClasses))
                {
                    overrideExtensionMethodClasses = new List<IFakeExtensionMethodClass>();
                    fakeExtensionMethodClassesByMethod.Add(methodName, overrideExtensionMethodClasses);
                }
                overrideExtensionMethodClasses.Add(new MethodFakeExtensionClass(protectedLike.LikeTypeName, protectedLike.MockedTypeName, protectedLike.MockedTypeNamespace, methodDetails));

            }
        }

        public void AddSource(GeneratorExecutionContext context)
        {
            var fakeExtensionMethodClasses = fakeExtensionMethodClassesByMethod.Values.SelectMany(l => l);
            foreach (var fakeExtensionClass in fakeExtensionMethodClasses)
            {
                fakeExtensionClass.AddSource(context);
            }
        }

        public void AddSetupOrVerify(bool isSetup, ExtensionMethod extensionMethod, FileLocation fileLocation)
        {
            //todo overloads - symbols from ExtensionMethod.Arguments
            var overrideExtensionMethodClasses = fakeExtensionMethodClassesByMethod[extensionMethod.Name];
            //for now assume just the one
            var extensionMethodClass = overrideExtensionMethodClasses[0];
            extensionMethodClass.AddSetupOrVerify(isSetup, extensionMethod.Arguments, fileLocation);
        }

        public bool IsExtensionMethod(ExtensionMethod extensionMethod)
        {
            return fakeExtensionMethodClassesByMethod.ContainsKey(extensionMethod.Name);
        }
    }
}
