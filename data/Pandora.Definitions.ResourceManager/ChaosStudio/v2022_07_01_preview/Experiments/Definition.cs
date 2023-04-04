using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ChaosStudio.v2022_07_01_preview.Experiments;

internal class Definition : ResourceDefinition
{
    public string Name => "Experiments";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CancelOperation(),
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new GetExecutionDetailsOperation(),
        new GetStatusOperation(),
        new ListOperation(),
        new ListAllOperation(),
        new ListAllStatusesOperation(),
        new ListExecutionDetailsOperation(),
        new StartOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(SelectorTypeConstant),
        typeof(TargetReferenceTypeConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(ActionModel),
        typeof(ActionStatusModel),
        typeof(BranchModel),
        typeof(BranchStatusModel),
        typeof(ExperimentModel),
        typeof(ExperimentCancelOperationResultModel),
        typeof(ExperimentExecutionActionTargetDetailsErrorModel),
        typeof(ExperimentExecutionActionTargetDetailsPropertiesModel),
        typeof(ExperimentExecutionDetailsModel),
        typeof(ExperimentExecutionDetailsPropertiesModel),
        typeof(ExperimentExecutionDetailsPropertiesRunInformationModel),
        typeof(ExperimentPropertiesModel),
        typeof(ExperimentStartOperationResultModel),
        typeof(ExperimentStatusModel),
        typeof(ExperimentStatusPropertiesModel),
        typeof(SelectorModel),
        typeof(StepModel),
        typeof(StepStatusModel),
        typeof(TargetReferenceModel),
    };
}
