// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Me.Beta.MeOutlookTaskGroupTaskFolder;

internal class ListMeOutlookTaskGroupByIdTaskFoldersOperation : Operations.ListOperation
{
    public override string? FieldContainingPaginationDetails() => "nextLink";
    public override ResourceID? ResourceId() => new MeOutlookTaskGroupId();
    public override Type NestedItemType() => typeof(OutlookTaskFolderCollectionResponseModel);
    public override string? UriSuffix() => "/taskFolders";
}
