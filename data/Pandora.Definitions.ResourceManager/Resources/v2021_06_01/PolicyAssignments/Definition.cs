using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Resources.v2021_06_01.PolicyAssignments;

internal class Definition : ResourceDefinition
{
    public string Name => "PolicyAssignments";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOperation(),
        new CreateByIdOperation(),
        new DeleteOperation(),
        new DeleteByIdOperation(),
        new GetOperation(),
        new GetByIdOperation(),
        new ListOperation(),
        new ListForManagementGroupOperation(),
        new ListForResourceOperation(),
        new ListForResourceGroupOperation(),
        new UpdateOperation(),
        new UpdateByIdOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(EnforcementModeConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(NonComplianceMessageModel),
        typeof(ParameterValuesValueModel),
        typeof(PolicyAssignmentModel),
        typeof(PolicyAssignmentPropertiesModel),
        typeof(PolicyAssignmentUpdateModel),
    };
}
