using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.PaloAltoNetworks.v2023_09_01.PrefixListLocalRulestack;

internal class ListByLocalRulestacksOperation : Pandora.Definitions.Operations.ListOperation
{
    public override string? FieldContainingPaginationDetails() => "nextLink";

    public override ResourceID? ResourceId() => new LocalRulestackId();

    public override Type NestedItemType() => typeof(PrefixListResourceModel);

    public override string? UriSuffix() => "/prefixLists";


}
