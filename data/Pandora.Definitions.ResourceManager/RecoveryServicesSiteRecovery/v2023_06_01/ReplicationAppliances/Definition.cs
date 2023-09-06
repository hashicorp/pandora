using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesSiteRecovery.v2023_06_01.ReplicationAppliances;

internal class Definition : ResourceDefinition
{
    public string Name => "ReplicationAppliances";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new ListOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(HealthErrorCustomerResolvabilityConstant),
        typeof(ProtectionHealthConstant),
        typeof(RcmComponentStatusConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(ApplianceSpecificDetailsModel),
        typeof(DraDetailsModel),
        typeof(HealthErrorModel),
        typeof(InMageRcmApplianceDetailsModel),
        typeof(InMageRcmApplianceSpecificDetailsModel),
        typeof(InMageRcmFabricSwitchProviderBlockingErrorDetailsModel),
        typeof(InnerHealthErrorModel),
        typeof(MarsAgentDetailsModel),
        typeof(ProcessServerDetailsModel),
        typeof(PushInstallerDetailsModel),
        typeof(RcmProxyDetailsModel),
        typeof(ReplicationAgentDetailsModel),
        typeof(ReplicationApplianceModel),
        typeof(ReplicationAppliancePropertiesModel),
        typeof(ReprotectAgentDetailsModel),
    };
}
