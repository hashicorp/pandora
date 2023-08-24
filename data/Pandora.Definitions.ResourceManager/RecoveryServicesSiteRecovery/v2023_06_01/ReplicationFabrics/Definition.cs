using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServicesSiteRecovery.v2023_06_01.ReplicationFabrics;

internal class Definition : ResourceDefinition
{
    public string Name => "ReplicationFabrics";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CheckConsistencyOperation(),
        new CreateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListOperation(),
        new MigrateToAadOperation(),
        new PurgeOperation(),
        new ReassociateGatewayOperation(),
        new RenewCertificateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(AgentVersionStatusConstant),
        typeof(HealthErrorCustomerResolvabilityConstant),
        typeof(ProtectionHealthConstant),
        typeof(RcmComponentStatusConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(A2AExtendedLocationDetailsModel),
        typeof(A2AFabricSpecificLocationDetailsModel),
        typeof(A2AZoneDetailsModel),
        typeof(AgentDetailsModel),
        typeof(AgentDiskDetailsModel),
        typeof(AzureFabricCreationInputModel),
        typeof(AzureFabricSpecificDetailsModel),
        typeof(DataStoreModel),
        typeof(DraDetailsModel),
        typeof(EncryptionDetailsModel),
        typeof(FabricModel),
        typeof(FabricCreationInputModel),
        typeof(FabricCreationInputPropertiesModel),
        typeof(FabricPropertiesModel),
        typeof(FabricSpecificCreationInputModel),
        typeof(FabricSpecificDetailsModel),
        typeof(FailoverProcessServerRequestModel),
        typeof(FailoverProcessServerRequestPropertiesModel),
        typeof(HealthErrorModel),
        typeof(HyperVHostDetailsModel),
        typeof(HyperVSiteDetailsModel),
        typeof(IdentityProviderDetailsModel),
        typeof(IdentityProviderInputModel),
        typeof(InMageFabricSwitchProviderBlockingErrorDetailsModel),
        typeof(InMageRcmFabricCreationInputModel),
        typeof(InMageRcmFabricSpecificDetailsModel),
        typeof(InnerHealthErrorModel),
        typeof(MarsAgentDetailsModel),
        typeof(MasterTargetServerModel),
        typeof(MobilityServiceUpdateModel),
        typeof(ProcessServerModel),
        typeof(ProcessServerDetailsModel),
        typeof(PushInstallerDetailsModel),
        typeof(RcmProxyDetailsModel),
        typeof(RenewCertificateInputModel),
        typeof(RenewCertificateInputPropertiesModel),
        typeof(ReplicationAgentDetailsModel),
        typeof(ReprotectAgentDetailsModel),
        typeof(RetentionVolumeModel),
        typeof(RunAsAccountModel),
        typeof(VMmDetailsModel),
        typeof(VMwareDetailsModel),
        typeof(VMwareV2FabricCreationInputModel),
        typeof(VMwareV2FabricSpecificDetailsModel),
        typeof(VersionDetailsModel),
    };
}
