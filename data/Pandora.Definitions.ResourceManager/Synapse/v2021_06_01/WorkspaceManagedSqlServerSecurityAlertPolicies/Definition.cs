using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Synapse.v2021_06_01.WorkspaceManagedSqlServerSecurityAlertPolicies;

internal class Definition : ResourceDefinition
{
    public string Name => "WorkspaceManagedSqlServerSecurityAlertPolicies";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new WorkspaceManagedSqlServerSecurityAlertPolicyCreateOrUpdateOperation(),
        new WorkspaceManagedSqlServerSecurityAlertPolicyGetOperation(),
        new WorkspaceManagedSqlServerSecurityAlertPolicyListOperation(),
    };
}
