using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DataShare.v2021_08_01.DataSetMapping;

internal class Definition : ResourceDefinition
{
    public string Name => "DataSetMapping";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListByShareSubscriptionOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(DataSetMappingKindConstant),
        typeof(DataSetMappingStatusConstant),
        typeof(OutputTypeConstant),
        typeof(ProvisioningStateConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(ADLSGen2FileDataSetMappingModel),
        typeof(ADLSGen2FileDataSetMappingPropertiesModel),
        typeof(ADLSGen2FileSystemDataSetMappingModel),
        typeof(ADLSGen2FileSystemDataSetMappingPropertiesModel),
        typeof(ADLSGen2FolderDataSetMappingModel),
        typeof(ADLSGen2FolderDataSetMappingPropertiesModel),
        typeof(BlobContainerDataSetMappingModel),
        typeof(BlobContainerMappingPropertiesModel),
        typeof(BlobDataSetMappingModel),
        typeof(BlobFolderDataSetMappingModel),
        typeof(BlobFolderMappingPropertiesModel),
        typeof(BlobMappingPropertiesModel),
        typeof(DataSetMappingModel),
        typeof(KustoClusterDataSetMappingModel),
        typeof(KustoClusterDataSetMappingPropertiesModel),
        typeof(KustoDatabaseDataSetMappingModel),
        typeof(KustoDatabaseDataSetMappingPropertiesModel),
        typeof(KustoTableDataSetMappingModel),
        typeof(KustoTableDataSetMappingPropertiesModel),
        typeof(SqlDBTableDataSetMappingModel),
        typeof(SqlDBTableDataSetMappingPropertiesModel),
        typeof(SqlDWTableDataSetMappingModel),
        typeof(SqlDWTableDataSetMappingPropertiesModel),
        typeof(SynapseWorkspaceSqlPoolTableDataSetMappingModel),
        typeof(SynapseWorkspaceSqlPoolTableDataSetMappingPropertiesModel),
    };
}
