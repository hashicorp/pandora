using Pandora.Definitions.Attributes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.EventHub.v2017_04_01.DisasterRecoveryConfigs
{
    internal class GetOperation : Operations.GetOperation
    {
        public override ResourceID? ResourceId() => new DisasterRecoveryConfigId();

        public override Type? ResponseObject() => typeof(ArmDisasterRecoveryModel);


    }
}
