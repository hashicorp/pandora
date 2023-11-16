using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.PostgreSql.v2023_06_01_preview.LocationBasedCapabilities;

internal class Definition : ResourceDefinition
{
    public string Name => "LocationBasedCapabilities";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new ExecuteOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(CapabilityStatusConstant),
        typeof(FastProvisioningSupportedEnumConstant),
        typeof(GeoBackupSupportedEnumConstant),
        typeof(HaModeConstant),
        typeof(OnlineResizeSupportedEnumConstant),
        typeof(RestrictedEnumConstant),
        typeof(StorageAutoGrowthSupportedEnumConstant),
        typeof(ZoneRedundantHaAndGeoBackupSupportedEnumConstant),
        typeof(ZoneRedundantHaSupportedEnumConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(FastProvisioningEditionCapabilityModel),
        typeof(FlexibleServerCapabilityModel),
        typeof(FlexibleServerEditionCapabilityModel),
        typeof(ServerSkuCapabilityModel),
        typeof(ServerVersionCapabilityModel),
        typeof(StorageEditionCapabilityModel),
        typeof(StorageMbCapabilityModel),
        typeof(StorageTierCapabilityModel),
    };
}
