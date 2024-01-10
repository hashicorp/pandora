using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ChaosStudio.v2024_01_01.Experiments;

internal class Definition : ResourceDefinition
{
    public string Name => "Experiments";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CancelOperation(),
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new ExecutionDetailsOperation(),
        new GetOperation(),
        new GetExecutionOperation(),
        new ListOperation(),
        new ListAllOperation(),
        new ListAllExecutionsOperation(),
        new StartOperation(),
        new UpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(FilterTypeConstant),
        typeof(ProvisioningStateConstant),
        typeof(SelectorTypeConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(ActionModel),
        typeof(ActionStatusModel),
        typeof(BranchModel),
        typeof(BranchStatusModel),
        typeof(ExperimentModel),
        typeof(ExperimentExecutionModel),
        typeof(ExperimentExecutionActionTargetDetailsErrorModel),
        typeof(ExperimentExecutionActionTargetDetailsPropertiesModel),
        typeof(ExperimentExecutionDetailsModel),
        typeof(ExperimentExecutionDetailsPropertiesModel),
        typeof(ExperimentExecutionDetailsPropertiesRunInformationModel),
        typeof(ExperimentExecutionPropertiesModel),
        typeof(ExperimentPropertiesModel),
        typeof(ExperimentUpdateModel),
        typeof(FilterModel),
        typeof(SelectorModel),
        typeof(StepModel),
        typeof(StepStatusModel),
    };
}
