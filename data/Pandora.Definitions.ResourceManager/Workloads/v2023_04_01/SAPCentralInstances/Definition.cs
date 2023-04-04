using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Workloads.v2023_04_01.SAPCentralInstances;

internal class Definition : ResourceDefinition
{
    public string Name => "SAPCentralInstances";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListOperation(),
        new StartInstanceOperation(),
        new StopInstanceOperation(),
        new UpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(CentralServerVirtualMachineTypeConstant),
        typeof(EnqueueReplicationServerTypeConstant),
        typeof(SAPHealthStateConstant),
        typeof(SAPVirtualInstanceStatusConstant),
        typeof(SapVirtualInstanceProvisioningStateConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CentralServerVMDetailsModel),
        typeof(EnqueueReplicationServerPropertiesModel),
        typeof(EnqueueServerPropertiesModel),
        typeof(ErrorAdditionalInfoModel),
        typeof(ErrorDefinitionModel),
        typeof(ErrorDetailModel),
        typeof(GatewayServerPropertiesModel),
        typeof(LoadBalancerDetailsModel),
        typeof(MessageServerPropertiesModel),
        typeof(OperationStatusResultModel),
        typeof(SAPCentralServerInstanceModel),
        typeof(SAPCentralServerPropertiesModel),
        typeof(SAPVirtualInstanceErrorModel),
        typeof(StopRequestModel),
        typeof(StorageInformationModel),
        typeof(UpdateSAPCentralInstanceRequestModel),
    };
}
