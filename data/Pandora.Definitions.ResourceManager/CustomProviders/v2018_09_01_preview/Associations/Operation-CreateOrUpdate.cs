using Pandora.Definitions.Attributes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.CustomProviders.v2018_09_01_preview.Associations
{
    internal class CreateOrUpdateOperation : Operations.PutOperation
    {
        public override bool LongRunning()
        {
            return true;
        }

        public override object? RequestObject()
        {
            return new AssociationModel();
        }

        public override ResourceID? ResourceId()
        {
            return new AssociationId();
        }

        public override object? ResponseObject()
        {
            return new AssociationModel();
        }


    }
}
