// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Directory.Beta.DirectoryAdministrativeUnitMember;

internal class ListDirectoryAdministrativeUnitByIdMembersOperation : Operations.ListOperation
{
    public override string? FieldContainingPaginationDetails() => "nextLink";
    public override ResourceID? ResourceId() => new DirectoryAdministrativeUnitId();
    public override Type NestedItemType() => typeof(DirectoryObjectCollectionResponseModel);
    public override string? UriSuffix() => "/members";
}
