using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Resources.v2020_10_01.Providers;

internal class ProviderResourceTypesListOperation : Operations.GetOperation
{
    public override ResourceID? ResourceId() => new SubscriptionProviderId();

    public override Type? ResponseObject() => typeof(ProviderResourceTypeListResultModel);

    public override Type? OptionsObject() => typeof(ProviderResourceTypesListOperation.ProviderResourceTypesListOptions);

    public override string? UriSuffix() => "/resourceTypes";

    internal class ProviderResourceTypesListOptions
    {
        [QueryStringName("$expand")]
        [Optional]
        public string Expand { get; set; }
    }
}
