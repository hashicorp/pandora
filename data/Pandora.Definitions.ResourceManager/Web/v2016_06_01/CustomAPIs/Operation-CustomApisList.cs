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

internal class CustomApisListOperation : Operations.GetOperation
{
    public override ResourceID? ResourceId() => new SubscriptionId();

    public override Type? ResponseObject() => typeof(CustomApiDefinitionCollectionModel);

    public override Type? OptionsObject() => typeof(CustomApisListOperation.CustomApisListOptions);

    public override string? UriSuffix() => "/providers/Microsoft.Web/customApis";

    internal class CustomApisListOptions
    {
        [QueryStringName("skiptoken")]
        [Optional]
        public string Skiptoken { get; set; }

        [QueryStringName("$top")]
        [Optional]
        public int Top { get; set; }
    }
}
