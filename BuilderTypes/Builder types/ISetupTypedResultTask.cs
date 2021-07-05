﻿using System;
using System.Threading.Tasks;

namespace MoqProtectedGenerated
{
    public interface ISetupTypedResultTask<TMock, TCallbackDelegate, TReturnsDelegate> :
         ISetupTypedResultTaskNoReturn<TMock, Task, TCallbackDelegate, TReturnsDelegate>      
        
            where TMock : class
            where TCallbackDelegate : Delegate
            where TReturnsDelegate : Delegate
    { }

}
