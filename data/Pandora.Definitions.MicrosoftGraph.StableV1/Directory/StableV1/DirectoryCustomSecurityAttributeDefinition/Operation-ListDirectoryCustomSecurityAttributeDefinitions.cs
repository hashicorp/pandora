// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Directory.StableV1.DirectoryCustomSecurityAttributeDefinition;

internal class ListDirectoryCustomSecurityAttributeDefinitionsOperation : Operations.ListOperation
{
    public override string? FieldContainingPaginationDetails() => "nextLink";
    public override ResourceID? ResourceId() => null;
    public override Type NestedItemType() => typeof(CustomSecurityAttributeDefinitionCollectionResponseModel);
    public override string? UriSuffix() => "/directory/customSecurityAttributeDefinitions";
}
