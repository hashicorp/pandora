// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Users.StableV1.UserOnenoteNotebookSectionGroupSectionGroup;

internal class ListUserByIdOnenoteNotebookByIdSectionGroupByIdSectionGroupsOperation : Operations.ListOperation
{
    public override string? FieldContainingPaginationDetails() => "nextLink";
    public override ResourceID? ResourceId() => new UserIdOnenoteNotebookIdSectionGroupId();
    public override Type NestedItemType() => typeof(SectionGroupCollectionResponseModel);
    public override string? UriSuffix() => "/sectionGroups";
}
