using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Compute.v2021_07_01.VirtualMachineScaleSetRollingUpgrades;

internal class Definition : ResourceDefinition
{
    public string Name => "VirtualMachineScaleSetRollingUpgrades";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CancelOperation(),
        new GetLatestOperation(),
        new StartExtensionUpgradeOperation(),
        new StartOSUpgradeOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(RollingUpgradeActionTypeConstant),
        typeof(RollingUpgradeStatusCodeConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(ApiErrorModel),
        typeof(ApiErrorBaseModel),
        typeof(InnerErrorModel),
        typeof(RollingUpgradePolicyModel),
        typeof(RollingUpgradeProgressInfoModel),
        typeof(RollingUpgradeRunningStatusModel),
        typeof(RollingUpgradeStatusInfoModel),
        typeof(RollingUpgradeStatusInfoPropertiesModel),
    };
}
