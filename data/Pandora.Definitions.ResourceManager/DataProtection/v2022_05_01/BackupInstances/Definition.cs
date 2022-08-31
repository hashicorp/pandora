using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DataProtection.v2022_05_01.BackupInstances;

internal class Definition : ResourceDefinition
{
    public string Name => "BackupInstances";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new AdhocBackupOperation(),
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListOperation(),
        new ResumeBackupsOperation(),
        new ResumeProtectionOperation(),
        new StopProtectionOperation(),
        new SuspendBackupsOperation(),
        new SyncBackupInstanceOperation(),
        new TriggerRehydrateOperation(),
        new TriggerRestoreOperation(),
        new ValidateForBackupOperation(),
        new ValidateForRestoreOperation(),
    };
}
