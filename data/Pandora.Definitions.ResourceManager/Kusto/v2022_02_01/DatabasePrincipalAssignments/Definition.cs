using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Kusto.v2022_02_01.DatabasePrincipalAssignments;

internal class Definition : ResourceDefinition
{
    public string Name => "DatabasePrincipalAssignments";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CheckNameAvailabilityOperation(),
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(DatabasePrincipalAssignmentTypeConstant),
        typeof(DatabasePrincipalRoleConstant),
        typeof(PrincipalTypeConstant),
        typeof(ProvisioningStateConstant),
        typeof(ReasonConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CheckNameResultModel),
        typeof(DatabasePrincipalAssignmentModel),
        typeof(DatabasePrincipalAssignmentCheckNameRequestModel),
        typeof(DatabasePrincipalAssignmentListResultModel),
        typeof(DatabasePrincipalPropertiesModel),
    };
}
