using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Sql.v2017_03_01_preview.ManagedRestorableDroppedDatabaseBackupShortTermRetentionPolicies;

internal class Definition : ResourceDefinition
{
    public string Name => "ManagedRestorableDroppedDatabaseBackupShortTermRetentionPolicies";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new GetOperation(),
        new ListByRestorableDroppedDatabaseOperation(),
        new UpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(ManagedBackupShortTermRetentionPolicyModel),
        typeof(ManagedBackupShortTermRetentionPolicyPropertiesModel),
    };
}
