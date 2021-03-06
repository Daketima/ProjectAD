﻿using Api.VerifyMe.Core;
using Api.VerifyMe.Implementation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Api.VerifyMe.Factory
{
    public class AddressVerificationFactory : DefaultVerificationFactory
    {
        
        public override IVerificationManager CreateInstance(string WhatToVerify) => new AddressVerification(WhatToVerify);        
    }
}
