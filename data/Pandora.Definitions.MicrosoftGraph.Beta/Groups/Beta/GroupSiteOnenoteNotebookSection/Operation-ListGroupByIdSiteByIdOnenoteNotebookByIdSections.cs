// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Groups.Beta.GroupSiteOnenoteNotebookSection;

internal class ListGroupByIdSiteByIdOnenoteNotebookByIdSectionsOperation : Operations.ListOperation
{
    public override string? FieldContainingPaginationDetails() => "nextLink";
    public override ResourceID? ResourceId() => new GroupIdSiteIdOnenoteNotebookId();
    public override Type NestedItemType() => typeof(OnenoteSectionCollectionResponseModel);
    public override string? UriSuffix() => "/sections";
}
