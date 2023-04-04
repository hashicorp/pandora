using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesBackup.v2022_03_01.RecoveryPoint;

internal class Definition : ResourceDefinition
{
    public string Name => "RecoveryPoint";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new MoveRecoveryPointOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(RecoveryPointTierTypeConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(MoveRPAcrossTiersRequestModel),
    };
}
