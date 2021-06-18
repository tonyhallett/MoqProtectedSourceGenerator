using System;
using System.Collections.Generic;
using System.Text;

namespace MoqProtectedTyped
{
    public static class CustomMatcher
    {
        public static TReturn Wrap<T, TReturn>(Func<T, TReturn> matcher,T value)
        {
            return matcher(value);
        }

        public static TReturn Wrap<T1,T2, TReturn>(Func<T1,T2, TReturn> matcher, T1 value1, T2 value2)
        {
            return matcher(value1, value2);
        }

        public static TReturn Wrap<T1, T2, T3, TReturn>(Func<T1, T2, T3, TReturn> matcher, T1 value1, T2 value2, T3 value3)
        {
            return matcher(value1, value2, value3);
        }

        public static TReturn Wrap<T1, T2, T3, T4, TReturn>(Func<T1, T2, T3, T4, TReturn> matcher, T1 value1, T2 value2, T3 value3, T4 value4)
        {
            return matcher(value1, value2, value3, value4);
        }

        public static TReturn Wrap<T1, T2, T3, T4, T5, TReturn>(Func<T1, T2, T3, T4, T5, TReturn> matcher, T1 value1, T2 value2, T3 value3, T4 value4, T5 value5)
        {
            return matcher(value1, value2, value3, value4, value5);
        }

        public static TReturn Wrap<T1, T2, T3, T4, T5,T6, TReturn>(Func<T1, T2, T3, T4, T5,T6, TReturn> matcher, T1 value1, T2 value2, T3 value3, T4 value4, T5 value5, T6 value6)
        {
            return matcher(value1, value2, value3, value4, value5, value6);
        }
    }
}
