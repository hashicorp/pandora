// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Directory.Beta.DirectoryImpactedResource;

internal class Definition : ResourceDefinition
{
    public string Name => "DirectoryImpactedResource";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateDirectoryImpactedResourceByIdCompleteOperation(),
        new CreateDirectoryImpactedResourceByIdDismisOperation(),
        new CreateDirectoryImpactedResourceByIdPostponeOperation(),
        new CreateDirectoryImpactedResourceByIdReactivateOperation(),
        new CreateDirectoryImpactedResourceOperation(),
        new DeleteDirectoryImpactedResourceByIdOperation(),
        new GetDirectoryImpactedResourceByIdOperation(),
        new GetDirectoryImpactedResourceCountOperation(),
        new ListDirectoryImpactedResourcesOperation(),
        new UpdateDirectoryImpactedResourceByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CreateDirectoryImpactedResourceByIdDismisRequestModel),
        typeof(CreateDirectoryImpactedResourceByIdPostponeRequestModel)
    };
}
