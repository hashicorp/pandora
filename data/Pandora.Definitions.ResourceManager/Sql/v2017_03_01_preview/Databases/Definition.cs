using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Sql.v2017_03_01_preview.Databases;

internal class Definition : ResourceDefinition
{
    public string Name => "Databases";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new DatabaseOperationsCancelOperation(),
        new DatabaseOperationsListByDatabaseOperation(),
        new DeleteOperation(),
        new ExportOperation(),
        new GetOperation(),
        new ListByElasticPoolOperation(),
        new ListByServerOperation(),
        new PauseOperation(),
        new RenameOperation(),
        new ResumeOperation(),
        new UpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(CatalogCollationTypeConstant),
        typeof(CreateModeConstant),
        typeof(DatabaseStatusConstant),
        typeof(ManagementOperationStateConstant),
        typeof(SampleNameConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(DatabaseModel),
        typeof(DatabaseOperationModel),
        typeof(DatabaseOperationPropertiesModel),
        typeof(DatabasePropertiesModel),
        typeof(DatabaseUpdateModel),
        typeof(ImportExportDatabaseDefinitionModel),
        typeof(ImportExportOperationResultModel),
        typeof(ImportExportOperationResultPropertiesModel),
        typeof(ResourceMoveDefinitionModel),
        typeof(SkuModel),
    };
}
