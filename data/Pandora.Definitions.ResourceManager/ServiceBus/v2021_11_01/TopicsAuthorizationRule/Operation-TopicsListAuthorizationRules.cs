using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ServiceBus.v2021_11_01.TopicsAuthorizationRule;

internal class TopicsListAuthorizationRulesOperation : Operations.ListOperation
{
\t\tpublic override string? FieldContainingPaginationDetails() => "nextLink";

\t\tpublic override ResourceID? ResourceId() => new TopicId();

\t\tpublic override Type NestedItemType() => typeof(SBAuthorizationRuleModel);

\t\tpublic override string? UriSuffix() => "/authorizationRules";


}
