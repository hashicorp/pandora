using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesBackup.v2022_03_01.BackupUsageSummaries;

internal class Definition : ResourceDefinition
{
    public string Name => "BackupUsageSummaries";
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
