using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.Web.v2016_06_01.CustomAPIs;

internal class CustomApisListByResourceGroupOperation : Operations.GetOperation
{
    public override ResourceID? ResourceId() => new ResourceGroupId();

    public override Type? ResponseObject() => typeof(CustomApiDefinitionCollectionModel);

    public override Type? OptionsObject() => typeof(CustomApisListByResourceGroupOperation.CustomApisListByResourceGroupOptions);

    public override string? UriSuffix() => "/providers/Microsoft.Web/customApis";

    internal class CustomApisListByResourceGroupOptions
    {
        [QueryStringName("skiptoken")]
        [Optional]
        public string Skiptoken { get; set; }

        [QueryStringName("$top")]
        [Optional]
        public int Top { get; set; }
    }
}
