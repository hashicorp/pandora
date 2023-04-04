using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ServiceBus.v2021_11_01.DisasterRecoveryConfigs;

internal class Definition : ResourceDefinition
{
    public string Name => "DisasterRecoveryConfigs";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new BreakPairingOperation(),
        new CheckNameAvailabilityOperation(),
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new FailOverOperation(),
        new GetOperation(),
        new GetAuthorizationRuleOperation(),
        new ListOperation(),
        new ListAuthorizationRulesOperation(),
        new ListKeysOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(AccessRightsConstant),
        typeof(ProvisioningStateDRConstant),
        typeof(RoleDisasterRecoveryConstant),
        typeof(UnavailableReasonConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(AccessKeysModel),
        typeof(ArmDisasterRecoveryModel),
        typeof(ArmDisasterRecoveryPropertiesModel),
        typeof(CheckNameAvailabilityModel),
        typeof(CheckNameAvailabilityResultModel),
        typeof(FailoverPropertiesModel),
        typeof(FailoverPropertiesPropertiesModel),
        typeof(SBAuthorizationRuleModel),
        typeof(SBAuthorizationRulePropertiesModel),
    };
}
