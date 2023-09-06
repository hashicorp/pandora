using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesBackup.v2023_01_15.BackupUsageSummariesCRR;

internal class Definition : ResourceDefinition
{
    public string Name => "BackupUsageSummariesCRR";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new ListOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(UsagesUnitConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(BackupManagementUsageModel),
        typeof(NameInfoModel),
    };
}
