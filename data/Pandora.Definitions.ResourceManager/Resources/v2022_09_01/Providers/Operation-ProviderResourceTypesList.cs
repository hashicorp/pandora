using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Resources.v2022_09_01.Providers;

internal class ProviderResourceTypesListOperation : Operations.GetOperation
{
\t\tpublic override ResourceID? ResourceId() => new SubscriptionProviderId();

\t\tpublic override Type? ResponseObject() => typeof(ProviderResourceTypeListResultModel);

\t\tpublic override Type? OptionsObject() => typeof(ProviderResourceTypesListOperation.ProviderResourceTypesListOptions);

\t\tpublic override string? UriSuffix() => "/resourceTypes";

    internal class ProviderResourceTypesListOptions
    {
        [QueryStringName("$expand")]
        [Optional]
        public string Expand { get; set; }
    }
}
