using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Web.v2022_09_01.Provider;

internal class GetAvailableStacksOnPremOperation : Pandora.Definitions.Operations.ListOperation
{
    public override string? FieldContainingPaginationDetails() => "nextLink";

    public override ResourceID? ResourceId() => new SubscriptionId();

    public override Type NestedItemType() => typeof(ApplicationStackResourceModel);

    public override Type? OptionsObject() => typeof(GetAvailableStacksOnPremOperation.GetAvailableStacksOnPremOptions);

    public override string? UriSuffix() => "/providers/Microsoft.Web/availableStacks";

    internal class GetAvailableStacksOnPremOptions
    {
        [QueryStringName("osTypeSelected")]
        [Optional]
        public ProviderOsTypeSelectedConstant OsTypeSelected { get; set; }
    }
}
