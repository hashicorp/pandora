using Pandora.Definitions.Attributes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.PowerBIDedicated.v2021_01_01.Capacities
{
    internal class CreateOperation : Operations.PutOperation
    {
        public override bool LongRunning()
        {
            return true;
        }

        public override object? RequestObject()
        {
            return new DedicatedCapacityModel();
        }

        public override ResourceID? ResourceId()
        {
            return new CapacitiesId();
        }

        public override object? ResponseObject()
        {
            return new DedicatedCapacityModel();
        }


    }
}
