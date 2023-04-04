using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DataBoxEdge.v2020_12_01.Shares;

internal class Definition : ResourceDefinition
{
    public string Name => "Shares";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListByDataBoxEdgeDeviceOperation(),
        new RefreshOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(AzureContainerDataFormatConstant),
        typeof(ClientPermissionTypeConstant),
        typeof(DataPolicyConstant),
        typeof(MonitoringStatusConstant),
        typeof(MountTypeConstant),
        typeof(RoleTypesConstant),
        typeof(ShareAccessProtocolConstant),
        typeof(ShareAccessTypeConstant),
        typeof(ShareStatusConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(AzureContainerInfoModel),
        typeof(ClientAccessRightModel),
        typeof(MountPointMapModel),
        typeof(RefreshDetailsModel),
        typeof(ShareModel),
        typeof(SharePropertiesModel),
        typeof(UserAccessRightModel),
    };
}
