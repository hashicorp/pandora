using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Security.v2020_01_01.SecureScoreControls;

internal class SecureScoreControlsListOperation : Operations.ListOperation
{
    public override string? FieldContainingPaginationDetails() => "nextLink";

    public override ResourceID? ResourceId() => new SubscriptionId();

    public override Type NestedItemType() => typeof(SecureScoreControlDetailsModel);

    public override Type? OptionsObject() => typeof(SecureScoreControlsListOperation.SecureScoreControlsListOptions);

    public override string? UriSuffix() => "/providers/Microsoft.Security/secureScoreControls";

    internal class SecureScoreControlsListOptions
    {
        [QueryStringName("$expand")]
        [Optional]
        public ExpandControlsEnumConstant Expand { get; set; }
    }
}
