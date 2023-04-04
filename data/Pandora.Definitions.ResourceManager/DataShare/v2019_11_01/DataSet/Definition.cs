using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DataShare.v2019_11_01.DataSet;

internal class Definition : ResourceDefinition
{
    public string Name => "DataSet";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListByShareOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(DataSetKindConstant),
        typeof(ProvisioningStateConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(ADLSGen1FileDataSetModel),
        typeof(ADLSGen1FilePropertiesModel),
        typeof(ADLSGen1FolderDataSetModel),
        typeof(ADLSGen1FolderPropertiesModel),
        typeof(ADLSGen2FileDataSetModel),
        typeof(ADLSGen2FilePropertiesModel),
        typeof(ADLSGen2FileSystemDataSetModel),
        typeof(ADLSGen2FileSystemPropertiesModel),
        typeof(ADLSGen2FolderDataSetModel),
        typeof(ADLSGen2FolderPropertiesModel),
        typeof(BlobContainerDataSetModel),
        typeof(BlobContainerPropertiesModel),
        typeof(BlobDataSetModel),
        typeof(BlobFolderDataSetModel),
        typeof(BlobFolderPropertiesModel),
        typeof(BlobPropertiesModel),
        typeof(DataSetModel),
        typeof(KustoClusterDataSetModel),
        typeof(KustoClusterDataSetPropertiesModel),
        typeof(KustoDatabaseDataSetModel),
        typeof(KustoDatabaseDataSetPropertiesModel),
        typeof(SqlDBTableDataSetModel),
        typeof(SqlDBTablePropertiesModel),
        typeof(SqlDWTableDataSetModel),
        typeof(SqlDWTablePropertiesModel),
    };
}
