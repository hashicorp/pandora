using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.EventGrid.v2020_10_15_preview.Topics
{
    internal class ExtensionTopicsGetOperation : Operations.GetOperation
    {
        public override ResourceID? ResourceId() => new ScopeId();

        public override Type? ResponseObject() => typeof(ExtensionTopicModel);

        public override string? UriSuffix() => "/providers/Microsoft.EventGrid/extensionTopics/default";


    }
}
