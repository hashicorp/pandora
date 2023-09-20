// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Applications.StableV1.ApplicationSynchronizationJobSchemaDirectory;

internal class ListApplicationByIdSynchronizationJobByIdSchemaDirectoriesOperation : Operations.ListOperation
{
    public override string? FieldContainingPaginationDetails() => "nextLink";
    public override ResourceID? ResourceId() => new ApplicationIdSynchronizationJobId();
    public override Type NestedItemType() => typeof(DirectoryDefinitionCollectionResponseModel);
    public override string? UriSuffix() => "/schema/directories";
}
