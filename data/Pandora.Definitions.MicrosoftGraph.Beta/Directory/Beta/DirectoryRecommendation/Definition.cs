// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Directory.Beta.DirectoryRecommendation;

internal class Definition : ResourceDefinition
{
    public string Name => "DirectoryRecommendation";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateDirectoryRecommendationByIdCompleteOperation(),
        new CreateDirectoryRecommendationByIdDismisOperation(),
        new CreateDirectoryRecommendationByIdPostponeOperation(),
        new CreateDirectoryRecommendationByIdReactivateOperation(),
        new CreateDirectoryRecommendationOperation(),
        new DeleteDirectoryRecommendationByIdOperation(),
        new GetDirectoryRecommendationByIdOperation(),
        new GetDirectoryRecommendationCountOperation(),
        new ListDirectoryRecommendationsOperation(),
        new UpdateDirectoryRecommendationByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CreateDirectoryRecommendationByIdDismisRequestModel),
        typeof(CreateDirectoryRecommendationByIdPostponeRequestModel)
    };
}
