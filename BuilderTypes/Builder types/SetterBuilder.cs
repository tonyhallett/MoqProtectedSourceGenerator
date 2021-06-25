﻿using Moq;
using MoqProtectedGenerated;
using System;
using Moq.Language.Flow;
using Moq.Language;

public class SetterBuilder<T, TProperty> :
        SetupVerifyBuilder<ISetupSetter<T, TProperty>, ISetupSequentialAction>,
        ISetterBuilder<T, TProperty> where T : class
{
    public SetterBuilder(
        Func<string, int, ISetupSetter<T, TProperty>> setup,
        Func<string, int, ISetupSequentialAction> setupSequence,
        Action<string, int, Times?, string> verify
    ) : base(setup, setupSequence, verify) { }
}
