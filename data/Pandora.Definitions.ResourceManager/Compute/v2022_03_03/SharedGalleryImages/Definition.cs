using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Compute.v2022_03_03.SharedGalleryImages;

internal class Definition : ResourceDefinition
{
    public string Name => "SharedGalleryImages";
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
        typeof(SharedToValuesConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(DisallowedModel),
        typeof(GalleryImageFeatureModel),
        typeof(GalleryImageIdentifierModel),
        typeof(ImagePurchasePlanModel),
        typeof(RecommendedMachineConfigurationModel),
        typeof(ResourceRangeModel),
        typeof(SharedGalleryIdentifierModel),
        typeof(SharedGalleryImageModel),
        typeof(SharedGalleryImagePropertiesModel),
    };
}
