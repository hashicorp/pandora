using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Compute.v2022_03_03.CommunityGalleryImages;

internal class Definition : ResourceDefinition
{
    public string Name => "CommunityGalleryImages";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new GetOperation(),
        new ListOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(ArchitectureConstant),
        typeof(HyperVGenerationConstant),
        typeof(OperatingSystemStateTypesConstant),
        typeof(OperatingSystemTypesConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CommunityGalleryIdentifierModel),
        typeof(CommunityGalleryImageModel),
        typeof(CommunityGalleryImageIdentifierModel),
        typeof(CommunityGalleryImagePropertiesModel),
        typeof(DisallowedModel),
        typeof(GalleryImageFeatureModel),
        typeof(ImagePurchasePlanModel),
        typeof(RecommendedMachineConfigurationModel),
        typeof(ResourceRangeModel),
    };
}
