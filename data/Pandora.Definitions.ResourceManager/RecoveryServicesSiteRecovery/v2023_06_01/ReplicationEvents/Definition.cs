using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesSiteRecovery.v2023_06_01.ReplicationEvents;

internal class Definition : ResourceDefinition
{
    public string Name => "ReplicationEvents";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new GetOperation(),
        new ListOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(HealthErrorCustomerResolvabilityConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(A2AEventDetailsModel),
        typeof(EventModel),
        typeof(EventPropertiesModel),
        typeof(EventProviderSpecificDetailsModel),
        typeof(EventSpecificDetailsModel),
        typeof(HealthErrorModel),
        typeof(HyperVReplica2012EventDetailsModel),
        typeof(HyperVReplica2012R2EventDetailsModel),
        typeof(HyperVReplicaAzureEventDetailsModel),
        typeof(HyperVReplicaBaseEventDetailsModel),
        typeof(InMageAzureV2EventDetailsModel),
        typeof(InMageRcmEventDetailsModel),
        typeof(InMageRcmFailbackEventDetailsModel),
        typeof(InnerHealthErrorModel),
        typeof(JobStatusEventDetailsModel),
        typeof(VMwareCbtEventDetailsModel),
    };
}
