using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.NotificationHubs.v2017_04_01.NotificationHubs;

internal class ListAuthorizationRulesOperation : Pandora.Definitions.Operations.ListOperation
{
    public override string? FieldContainingPaginationDetails() => "nextLink";

    public override ResourceID? ResourceId() => new NotificationHubId();

    public override Type NestedItemType() => typeof(SharedAccessAuthorizationRuleResourceModel);

    public override string? UriSuffix() => "/authorizationRules";


}
