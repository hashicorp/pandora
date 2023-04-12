using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Resources.v2021_04_01.Providers;

internal class ListAtTenantScopeOperation : Pandora.Definitions.Operations.ListOperation
{
    public override string? FieldContainingPaginationDetails() => "nextLink";

    public override Type NestedItemType() => typeof(ProviderModel);

    public override Type? OptionsObject() => typeof(ListAtTenantScopeOperation.ListAtTenantScopeOptions);

    public override string? UriSuffix() => "/providers";

    internal class ListAtTenantScopeOptions
    {
        [QueryStringName("$expand")]
        [Optional]
        public string Expand { get; set; }
    }
}
