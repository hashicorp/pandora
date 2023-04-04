using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesSiteRecovery.v2022_10_01.ReplicationVaultHealth;

internal class Definition : ResourceDefinition
{
    public string Name => "ReplicationVaultHealth";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new GetOperation(),
        new RefreshOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(HealthErrorCategoryConstant),
        typeof(HealthErrorCustomerResolvabilityConstant),
        typeof(SeverityConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(HealthErrorModel),
        typeof(HealthErrorSummaryModel),
        typeof(InnerHealthErrorModel),
        typeof(ResourceHealthSummaryModel),
        typeof(VaultHealthDetailsModel),
        typeof(VaultHealthPropertiesModel),
    };
}
