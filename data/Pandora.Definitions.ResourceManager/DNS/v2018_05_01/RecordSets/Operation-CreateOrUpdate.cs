using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.DNS.v2018_05_01.RecordSets
{
    internal class CreateOrUpdateOperation : Operations.PutOperation
    {
        public override Type? RequestObject() => typeof(RecordSetModel);

        public override ResourceID? ResourceId() => new RecordTypeId();

        public override Type? ResponseObject() => typeof(RecordSetModel);


    }
}
