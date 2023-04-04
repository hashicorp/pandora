using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DevTestLab.v2018_09_15.CustomImages;

internal class Definition : ResourceDefinition
{
    public string Name => "CustomImages";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListOperation(),
        new UpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(CustomImageOsTypeConstant),
        typeof(LinuxOsStateConstant),
        typeof(StorageTypeConstant),
        typeof(WindowsOsStateConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CustomImageModel),
        typeof(CustomImagePropertiesModel),
        typeof(CustomImagePropertiesCustomModel),
        typeof(CustomImagePropertiesFromPlanModel),
        typeof(CustomImagePropertiesFromVMModel),
        typeof(DataDiskStorageTypeInfoModel),
        typeof(LinuxOsInfoModel),
        typeof(UpdateResourceModel),
        typeof(WindowsOsInfoModel),
    };
}
