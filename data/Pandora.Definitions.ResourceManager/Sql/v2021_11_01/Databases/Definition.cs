using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Sql.v2021_11_01.Databases;

internal class Definition : ResourceDefinition
{
    public string Name => "Databases";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new ExportOperation(),
        new FailoverOperation(),
        new GetOperation(),
        new ImportOperation(),
        new ListByElasticPoolOperation(),
        new ListByServerOperation(),
        new ListInaccessibleByServerOperation(),
        new PauseOperation(),
        new RenameOperation(),
        new ResumeOperation(),
        new UpdateOperation(),
        new UpgradeDataWarehouseOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(BackupStorageRedundancyConstant),
        typeof(CatalogCollationTypeConstant),
        typeof(CreateModeConstant),
        typeof(DatabaseLicenseTypeConstant),
        typeof(DatabaseReadScaleConstant),
        typeof(DatabaseStatusConstant),
        typeof(ReplicaTypeConstant),
        typeof(SampleNameConstant),
        typeof(SecondaryTypeConstant),
        typeof(StorageKeyTypeConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(DatabaseModel),
        typeof(DatabasePropertiesModel),
        typeof(DatabaseUpdateModel),
        typeof(DatabaseUpdatePropertiesModel),
        typeof(ExportDatabaseDefinitionModel),
        typeof(ImportExistingDatabaseDefinitionModel),
        typeof(ImportExportOperationResultModel),
        typeof(ImportExportOperationResultPropertiesModel),
        typeof(NetworkIsolationSettingsModel),
        typeof(PrivateEndpointConnectionRequestStatusModel),
        typeof(ResourceMoveDefinitionModel),
        typeof(SkuModel),
    };
}
