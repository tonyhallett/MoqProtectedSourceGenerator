using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Moq;

namespace MoqProtectedTyped
{
    public class MatcherObserver
    {
        private static readonly Type matcherObserverType;
        private static readonly MethodInfo activateMethod;
        private static readonly MethodInfo getMatchesBetweenMethod;
        private static readonly FieldInfo observationsField;
        private readonly object matcherObserver;

        public static MatcherObserver Instance { get; private set; }
        
        static MatcherObserver()
        {
            matcherObserverType = typeof(Mock).Assembly.GetType("Moq.MatcherObserver");
            activateMethod = matcherObserverType.GetMethod("Activate", BindingFlags.Public | BindingFlags.Static);
            getMatchesBetweenMethod = matcherObserverType.GetMethod("GetMatchesBetween");
            observationsField = matcherObserverType.GetField("observations", BindingFlags.NonPublic | BindingFlags.Instance);
        }

        public MatcherObserver(object matcherObserver)
        {
            this.matcherObserver = matcherObserver;
        }
        public static void EnsureInstance()
        {
            if(Instance == null)
            {
                Instance = Activate();
            }
        }

        public static MatcherObserver Activate()
        {
           return new MatcherObserver(activateMethod.Invoke(null, new object[] { }));
        }

        public static List<Match> GetMatches()
        {
            var matches = Instance.InstanceGetMatches().ToList();
            Clear();
            return matches;
        }
        
        private static void Clear()
        {
            Instance.InstanceClear();
        }

        private void InstanceClear()
        {
            if (observationsField.GetValue(matcherObserver) is IList list)
            {
                list.Clear();
            }
        }

        private IEnumerable<Match> InstanceGetMatches()
        {
            return getMatchesBetweenMethod.Invoke(matcherObserver, new object[] { 0, int.MaxValue }) as IEnumerable<Match>;
        }
    }
}