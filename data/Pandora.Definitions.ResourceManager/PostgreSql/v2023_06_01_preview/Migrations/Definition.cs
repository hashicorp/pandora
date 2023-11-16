using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.PostgreSql.v2023_06_01_preview.Migrations;

internal class Definition : ResourceDefinition
{
    public string Name => "Migrations";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListByTargetServerOperation(),
        new UpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(CancelEnumConstant),
        typeof(LogicalReplicationOnSourceDbEnumConstant),
        typeof(MigrationDbStateConstant),
        typeof(MigrationListFilterConstant),
        typeof(MigrationModeConstant),
        typeof(MigrationOptionConstant),
        typeof(MigrationStateConstant),
        typeof(MigrationSubStateConstant),
        typeof(OverwriteDbsInTargetEnumConstant),
        typeof(SkuTierConstant),
        typeof(SourceTypeConstant),
        typeof(SslModeConstant),
        typeof(StartDataMigrationEnumConstant),
        typeof(TriggerCutoverEnumConstant),
        typeof(ValidationStateConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(AdminCredentialsModel),
        typeof(DbLevelValidationStatusModel),
        typeof(DbMigrationStatusModel),
        typeof(DbServerMetadataModel),
        typeof(MigrationResourceModel),
        typeof(MigrationResourceForPatchModel),
        typeof(MigrationResourcePropertiesModel),
        typeof(MigrationResourcePropertiesForPatchModel),
        typeof(MigrationSecretParametersModel),
        typeof(MigrationStatusModel),
        typeof(MigrationSubStateDetailsModel),
        typeof(ServerSkuModel),
        typeof(ValidationDetailsModel),
        typeof(ValidationMessageModel),
        typeof(ValidationSummaryItemModel),
    };
}
