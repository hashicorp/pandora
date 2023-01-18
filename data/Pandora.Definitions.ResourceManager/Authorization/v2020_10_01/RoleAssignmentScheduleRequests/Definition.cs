using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Authorization.v2020_10_01.RoleAssignmentScheduleRequests;

internal class Definition : ResourceDefinition
{
    public string Name => "RoleAssignmentScheduleRequests";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CancelOperation(),
        new CreateOperation(),
        new GetOperation(),
        new ListForScopeOperation(),
        new ValidateOperation(),
    };
}
