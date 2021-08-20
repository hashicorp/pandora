using Pandora.Definitions.Attributes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.PowerBIDedicated.v2021_01_01.Capacities
{
    internal class CreateOperation : Operations.PutOperation
    {
        public override bool LongRunning() => true;

        public override Type? RequestObject() => typeof(DedicatedCapacityModel);

        public override ResourceID? ResourceId() => new CapacitiesId();

        public override Type? ResponseObject() => typeof(DedicatedCapacityModel);


    }
}
