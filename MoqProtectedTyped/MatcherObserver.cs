using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Moq;

namespace MoqProtectedTyped
{
    public class MatcherObserver
    {
        private static readonly Type matcherObserverType = typeof(Mock).Assembly.GetType("Moq.MatcherObserver");
        private static readonly MethodInfo activateMethod = matcherObserverType.GetMethod("Activate", BindingFlags.Public | BindingFlags.Static);
        private static readonly MethodInfo getMatchesBetweenMethod = matcherObserverType.GetMethod("GetMatchesBetween");
        private static readonly MethodInfo disposeMethod = disposeMethod = matcherObserverType.GetMethod("Dispose");
        private readonly object matcherObserver;

        public static MatcherObserver Instance { get; private set; }
        
        //static MatcherObserver()
        //{
        //    //matcherObserverType = typeof(Mock).Assembly.GetType("Moq.MatcherObserver");
        //    //activateMethod = matcherObserverType.GetMethod("Activate", BindingFlags.Public | BindingFlags.Static);
        //    //getMatchesBetweenMethod = matcherObserverType.GetMethod("GetMatchesBetween");
        //   // disposeMethod = matcherObserverType.GetMethod("Dispose");
        //}

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
            try
            {
                disposeMethod.Invoke(Instance.matcherObserver, new object[] { });
            }
            catch { 
                // ignore exceptions
            }

            Instance = Activate();
            return matches;
        }

        private IEnumerable<Match> InstanceGetMatches()
        {
            return getMatchesBetweenMethod.Invoke(matcherObserver, new object[] { 0, int.MaxValue }) as IEnumerable<Match>;
        }
    }
}