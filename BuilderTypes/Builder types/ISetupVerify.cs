﻿using Moq;


namespace MoqProtectedGenerated
{
    public interface ISetupVerify<TSetup,TSetupSequence>
    {
        TSetup Setup();
        //https://github.com/moq/moq4/pull/1174
        //TSetup InSequence(MockSequence mockSequence);
        TSetupSequence SetupSequence();
        void Verify(Times? times = null, string failMessage = null);
    }
}
