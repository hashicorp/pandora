using Pandora.Definitions.Attributes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.SignalR.v2020_05_01.SignalR
{
    internal class GetOperation : Operations.GetOperation
    {
        public override ResourceID? ResourceId()
        {
            return new SignalRId();
        }

        public override object? ResponseObject()
        {
            return new SignalRResource();
        }


    }
}
