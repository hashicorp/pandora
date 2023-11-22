using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ContainerService.v2023_10_15.UpdateRuns;

internal class Definition : ResourceDefinition
{
    public string Name => "UpdateRuns";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListByFleetOperation(),
        new StartOperation(),
        new StopOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(ManagedClusterUpgradeTypeConstant),
        typeof(NodeImageSelectionTypeConstant),
        typeof(UpdateRunProvisioningStateConstant),
        typeof(UpdateStateConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(ErrorAdditionalInfoModel),
        typeof(ErrorDetailModel),
        typeof(ManagedClusterUpdateModel),
        typeof(ManagedClusterUpgradeSpecModel),
        typeof(MemberUpdateStatusModel),
        typeof(NodeImageSelectionModel),
        typeof(NodeImageSelectionStatusModel),
        typeof(NodeImageVersionModel),
        typeof(UpdateGroupModel),
        typeof(UpdateGroupStatusModel),
        typeof(UpdateRunModel),
        typeof(UpdateRunPropertiesModel),
        typeof(UpdateRunStatusModel),
        typeof(UpdateRunStrategyModel),
        typeof(UpdateStageModel),
        typeof(UpdateStageStatusModel),
        typeof(UpdateStatusModel),
        typeof(WaitStatusModel),
    };
}
