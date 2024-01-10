using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesBackup.v2023_08_01.FetchTieringCost;

internal class Definition : ResourceDefinition
{
    public string Name => "FetchTieringCost";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new PostOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(RecoveryPointTierTypeConstant),
        typeof(RehydrationPriorityConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(FetchTieringCostInfoForRehydrationRequestModel),
        typeof(FetchTieringCostInfoRequestModel),
        typeof(FetchTieringCostSavingsInfoForPolicyRequestModel),
        typeof(FetchTieringCostSavingsInfoForProtectedItemRequestModel),
        typeof(FetchTieringCostSavingsInfoForVaultRequestModel),
        typeof(TieringCostInfoModel),
        typeof(TieringCostRehydrationInfoModel),
        typeof(TieringCostSavingInfoModel),
    };
}
