using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DataProtection.v2022_12_01.RecoveryPoint;

internal class Definition : ResourceDefinition
{
    public string Name => "RecoveryPoint";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new GetOperation(),
        new ListOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(RehydrationStatusConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(AzureBackupDiscreteRecoveryPointModel),
        typeof(AzureBackupRecoveryPointModel),
        typeof(AzureBackupRecoveryPointResourceModel),
        typeof(RecoveryPointDataStoreDetailsModel),
    };
}
