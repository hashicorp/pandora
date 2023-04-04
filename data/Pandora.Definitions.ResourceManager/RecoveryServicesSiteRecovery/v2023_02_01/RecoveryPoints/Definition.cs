using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesSiteRecovery.v2023_02_01.RecoveryPoints;

internal class Definition : ResourceDefinition
{
    public string Name => "RecoveryPoints";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new GetOperation(),
        new ListByReplicationProtectedItemsOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(RecoveryPointSyncTypeConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(A2ARecoveryPointDetailsModel),
        typeof(InMageAzureV2RecoveryPointDetailsModel),
        typeof(InMageRcmRecoveryPointDetailsModel),
        typeof(ProviderSpecificRecoveryPointDetailsModel),
        typeof(RecoveryPointModel),
        typeof(RecoveryPointPropertiesModel),
    };
}
