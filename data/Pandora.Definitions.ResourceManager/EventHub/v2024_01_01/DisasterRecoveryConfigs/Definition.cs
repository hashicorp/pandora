using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.EventHub.v2024_01_01.DisasterRecoveryConfigs;

internal class Definition : ResourceDefinition
{
    public string Name => "DisasterRecoveryConfigs";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new BreakPairingOperation(),
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new FailOverOperation(),
        new GetOperation(),
        new ListOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(ProvisioningStateDRConstant),
        typeof(RoleDisasterRecoveryConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(ArmDisasterRecoveryModel),
        typeof(ArmDisasterRecoveryPropertiesModel),
    };
}
