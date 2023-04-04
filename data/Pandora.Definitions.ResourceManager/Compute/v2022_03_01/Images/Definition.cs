using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Compute.v2022_03_01.Images;

internal class Definition : ResourceDefinition
{
    public string Name => "Images";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListOperation(),
        new ListByResourceGroupOperation(),
        new UpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(CachingTypesConstant),
        typeof(HyperVGenerationTypesConstant),
        typeof(OperatingSystemStateTypesConstant),
        typeof(OperatingSystemTypesConstant),
        typeof(StorageAccountTypesConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(ImageModel),
        typeof(ImageDataDiskModel),
        typeof(ImageOSDiskModel),
        typeof(ImagePropertiesModel),
        typeof(ImageStorageProfileModel),
        typeof(ImageUpdateModel),
        typeof(SubResourceModel),
    };
}
