using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.OperationalInsights.v2022_10_01.Tables;

internal class Definition : ResourceDefinition
{
    public string Name => "Tables";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CancelSearchOperation(),
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListByWorkspaceOperation(),
        new MigrateOperation(),
        new UpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(ColumnDataTypeHintEnumConstant),
        typeof(ColumnTypeEnumConstant),
        typeof(ProvisioningStateEnumConstant),
        typeof(SourceEnumConstant),
        typeof(TablePlanEnumConstant),
        typeof(TableSubTypeEnumConstant),
        typeof(TableTypeEnumConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(ColumnModel),
        typeof(RestoredLogsModel),
        typeof(ResultStatisticsModel),
        typeof(SchemaModel),
        typeof(SearchResultsModel),
        typeof(TableModel),
        typeof(TablePropertiesModel),
        typeof(TablesListResultModel),
    };
}
