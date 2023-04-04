using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Workloads.v2023_04_01.SAPDiskConfigurations;

internal class Definition : ResourceDefinition
{
    public string Name => "SAPDiskConfigurations";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new SAPDiskConfigurationsOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(DiskSkuNameConstant),
        typeof(SAPDatabaseTypeConstant),
        typeof(SAPDeploymentTypeConstant),
        typeof(SAPEnvironmentTypeConstant),
        typeof(SAPProductTypeConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(DiskDetailsModel),
        typeof(DiskSkuModel),
        typeof(DiskVolumeConfigurationModel),
        typeof(SAPDiskConfigurationModel),
        typeof(SAPDiskConfigurationsRequestModel),
        typeof(SAPDiskConfigurationsResultModel),
    };
}
