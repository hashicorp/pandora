using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RedisEnterprise.v2023_11_01.Databases;

internal class Definition : ResourceDefinition
{
    public string Name => "Databases";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOperation(),
        new DeleteOperation(),
        new ExportOperation(),
        new FlushOperation(),
        new ForceUnlinkOperation(),
        new GetOperation(),
        new ImportOperation(),
        new ListByClusterOperation(),
        new ListKeysOperation(),
        new RegenerateKeyOperation(),
        new UpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(AccessKeyTypeConstant),
        typeof(AofFrequencyConstant),
        typeof(ClusteringPolicyConstant),
        typeof(EvictionPolicyConstant),
        typeof(LinkStateConstant),
        typeof(ProtocolConstant),
        typeof(ProvisioningStateConstant),
        typeof(RdbFrequencyConstant),
        typeof(ResourceStateConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(AccessKeysModel),
        typeof(DatabaseModel),
        typeof(DatabasePropertiesModel),
        typeof(DatabasePropertiesGeoReplicationModel),
        typeof(DatabaseUpdateModel),
        typeof(ExportClusterParametersModel),
        typeof(FlushParametersModel),
        typeof(ForceUnlinkParametersModel),
        typeof(ImportClusterParametersModel),
        typeof(LinkedDatabaseModel),
        typeof(ModuleModel),
        typeof(PersistenceModel),
        typeof(RegenerateKeyParametersModel),
    };
}
