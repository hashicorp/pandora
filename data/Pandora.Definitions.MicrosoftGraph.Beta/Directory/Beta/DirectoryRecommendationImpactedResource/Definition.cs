// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Directory.Beta.DirectoryRecommendationImpactedResource;

internal class Definition : ResourceDefinition
{
    public string Name => "DirectoryRecommendationImpactedResource";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateDirectoryRecommendationByIdImpactedResourceByIdCompleteOperation(),
        new CreateDirectoryRecommendationByIdImpactedResourceByIdDismisOperation(),
        new CreateDirectoryRecommendationByIdImpactedResourceByIdPostponeOperation(),
        new CreateDirectoryRecommendationByIdImpactedResourceByIdReactivateOperation(),
        new CreateDirectoryRecommendationByIdImpactedResourceOperation(),
        new DeleteDirectoryRecommendationByIdImpactedResourceByIdOperation(),
        new GetDirectoryRecommendationByIdImpactedResourceByIdOperation(),
        new GetDirectoryRecommendationByIdImpactedResourceCountOperation(),
        new ListDirectoryRecommendationByIdImpactedResourcesOperation(),
        new UpdateDirectoryRecommendationByIdImpactedResourceByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CreateDirectoryRecommendationByIdImpactedResourceByIdDismisRequestModel),
        typeof(CreateDirectoryRecommendationByIdImpactedResourceByIdPostponeRequestModel)
    };
}
