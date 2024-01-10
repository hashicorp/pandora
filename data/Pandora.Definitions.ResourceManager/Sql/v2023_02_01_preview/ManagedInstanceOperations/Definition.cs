using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Sql.v2023_02_01_preview.ManagedInstanceOperations;

internal class Definition : ResourceDefinition
{
    public string Name => "ManagedInstanceOperations";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new ListByManagedInstanceOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(ManagementOperationStateConstant),
        typeof(StatusConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(ManagedInstanceOperationModel),
        typeof(ManagedInstanceOperationParametersPairModel),
        typeof(ManagedInstanceOperationPropertiesModel),
        typeof(ManagedInstanceOperationStepsModel),
        typeof(UpsertManagedServerOperationParametersModel),
        typeof(UpsertManagedServerOperationStepWithEstimatesAndDurationModel),
    };
}
