using System;

namespace MoqProtectedGenerated
{
    public static class Guard
    {
        public static void Positive(TimeSpan delay)
        {
            if (delay <= TimeSpan.Zero)
            {
                throw new ArgumentException("Delays must be greater than 0");
            }
        }

    }
    
}
