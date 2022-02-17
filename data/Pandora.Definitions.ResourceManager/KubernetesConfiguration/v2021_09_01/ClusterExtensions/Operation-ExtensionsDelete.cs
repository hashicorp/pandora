using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.KubernetesConfiguration.v2021_09_01.ClusterExtensions;

internal class ExtensionsDeleteOperation : Operations.DeleteOperation
{
    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
                HttpStatusCode.Accepted,
                HttpStatusCode.NoContent,
                HttpStatusCode.OK,
        };

    public override bool LongRunning() => true;

    public override ResourceID? ResourceId() => new ExtensionId();

    public override Type? OptionsObject() => typeof(ExtensionsDeleteOperation.ExtensionsDeleteOptions);

    internal class ExtensionsDeleteOptions
    {
        [QueryStringName("forceDelete")]
        [Optional]
        public bool ForceDelete { get; set; }
    }
}
