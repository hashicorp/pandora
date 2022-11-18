using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Web.v2016_06_01.CustomAPIs;

internal class CustomApisListByResourceGroupOperation : Operations.GetOperation
{
\t\tpublic override ResourceID? ResourceId() => new ResourceGroupId();

\t\tpublic override Type? ResponseObject() => typeof(CustomApiDefinitionCollectionModel);

\t\tpublic override Type? OptionsObject() => typeof(CustomApisListByResourceGroupOperation.CustomApisListByResourceGroupOptions);

\t\tpublic override string? UriSuffix() => "/providers/Microsoft.Web/customApis";

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
