using Pandora.Definitions.Attributes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.PowerBIDedicated.v2021_01_01.Capacities
{
    internal class ListSkusForCapacityOperation : Operations.GetOperation
    {
        public override ResourceID? ResourceId()
        {
            return new CapacitiesId();
        }

        public override Type? ResponseObject()
        {
            return typeof(SkuEnumerationForExistingResourceResultModel);
        }

        public override string? UriSuffix()
        {
            return "/skus";
        }


    }
}
