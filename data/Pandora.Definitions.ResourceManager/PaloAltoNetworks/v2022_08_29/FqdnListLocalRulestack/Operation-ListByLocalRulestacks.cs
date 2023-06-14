using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.PaloAltoNetworks.v2022_08_29.FqdnListLocalRulestack;

internal class ListByLocalRulestacksOperation : Pandora.Definitions.Operations.ListOperation
{
    public override string? FieldContainingPaginationDetails() => "nextLink";

    public override ResourceID? ResourceId() => new LocalRuleStackId();

    public override Type NestedItemType() => typeof(FqdnListLocalRulestackResourceModel);

    public override string? UriSuffix() => "/fqdnLists";


}
