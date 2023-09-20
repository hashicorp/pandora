// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Users.StableV1.UserMailFolderMessageRule;

internal class ListUserByIdMailFolderByIdMessageRulesOperation : Operations.ListOperation
{
    public override string? FieldContainingPaginationDetails() => "nextLink";
    public override ResourceID? ResourceId() => new UserIdMailFolderId();
    public override Type NestedItemType() => typeof(MessageRuleCollectionResponseModel);
    public override string? UriSuffix() => "/messageRules";
}
