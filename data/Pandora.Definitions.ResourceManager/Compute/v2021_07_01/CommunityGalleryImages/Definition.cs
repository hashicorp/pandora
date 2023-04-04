using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Compute.v2021_07_01.CommunityGalleryImages;

internal class Definition : ResourceDefinition
{
    public string Name => "CommunityGalleryImages";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new GetOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(HyperVGenerationConstant),
        typeof(OperatingSystemStateTypesConstant),
        typeof(OperatingSystemTypesConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CommunityGalleryIdentifierModel),
        typeof(CommunityGalleryImageModel),
        typeof(CommunityGalleryImagePropertiesModel),
        typeof(DisallowedModel),
        typeof(GalleryImageFeatureModel),
        typeof(GalleryImageIdentifierModel),
        typeof(ImagePurchasePlanModel),
        typeof(RecommendedMachineConfigurationModel),
        typeof(ResourceRangeModel),
    };
}
