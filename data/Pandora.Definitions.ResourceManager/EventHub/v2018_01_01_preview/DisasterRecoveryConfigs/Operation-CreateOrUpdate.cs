using Pandora.Definitions.Attributes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.EventHub.v2018_01_01_preview.DisasterRecoveryConfigs
{
    internal class CreateOrUpdateOperation : Operations.PutOperation
    {
        public override Type? RequestObject() => typeof(ArmDisasterRecoveryModel);

        public override ResourceID? ResourceId() => new DisasterRecoveryConfigId();

        public override Type? ResponseObject() => typeof(ArmDisasterRecoveryModel);


    }
}
