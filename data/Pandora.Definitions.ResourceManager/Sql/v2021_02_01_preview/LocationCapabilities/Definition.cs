using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Sql.v2021_02_01_preview.LocationCapabilities;

internal class Definition : ResourceDefinition
{
    public string Name => "LocationCapabilities";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CapabilitiesListByLocationOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(CapabilityGroupConstant),
        typeof(CapabilityStatusConstant),
        typeof(LogSizeUnitConstant),
        typeof(MaxSizeUnitConstant),
        typeof(PauseDelayTimeUnitConstant),
        typeof(PerformanceLevelUnitConstant),
        typeof(StorageAccountTypeConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(AutoPauseDelayTimeRangeModel),
        typeof(EditionCapabilityModel),
        typeof(ElasticPoolEditionCapabilityModel),
        typeof(ElasticPoolPerDatabaseMaxPerformanceLevelCapabilityModel),
        typeof(ElasticPoolPerDatabaseMinPerformanceLevelCapabilityModel),
        typeof(ElasticPoolPerformanceLevelCapabilityModel),
        typeof(InstancePoolEditionCapabilityModel),
        typeof(InstancePoolFamilyCapabilityModel),
        typeof(InstancePoolVcoresCapabilityModel),
        typeof(LicenseTypeCapabilityModel),
        typeof(LocationCapabilitiesModel),
        typeof(LogSizeCapabilityModel),
        typeof(MaintenanceConfigurationCapabilityModel),
        typeof(ManagedInstanceEditionCapabilityModel),
        typeof(ManagedInstanceFamilyCapabilityModel),
        typeof(ManagedInstanceMaintenanceConfigurationCapabilityModel),
        typeof(ManagedInstanceVcoresCapabilityModel),
        typeof(ManagedInstanceVersionCapabilityModel),
        typeof(MaxSizeCapabilityModel),
        typeof(MaxSizeRangeCapabilityModel),
        typeof(MinCapacityCapabilityModel),
        typeof(PerformanceLevelCapabilityModel),
        typeof(ReadScaleCapabilityModel),
        typeof(ServerVersionCapabilityModel),
        typeof(ServiceObjectiveCapabilityModel),
        typeof(SkuModel),
        typeof(StorageCapabilityModel),
    };
}
