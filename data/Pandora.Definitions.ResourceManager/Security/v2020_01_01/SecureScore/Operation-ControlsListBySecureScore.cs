using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Security.v2020_01_01.SecureScore;

internal class ControlsListBySecureScoreOperation : Pandora.Definitions.Operations.ListOperation
{
    public override string? FieldContainingPaginationDetails() => "nextLink";

    public override ResourceID? ResourceId() => new SecureScoreId();

    public override Type NestedItemType() => typeof(SecureScoreControlDetailsModel);

    public override Type? OptionsObject() => typeof(ControlsListBySecureScoreOperation.ControlsListBySecureScoreOptions);

    public override string? UriSuffix() => "/secureScoreControls";

    internal class ControlsListBySecureScoreOptions
    {
        [QueryStringName("$expand")]
        [Optional]
        public ExpandControlsEnumConstant Expand { get; set; }
    }
}
