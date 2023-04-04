using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Consumption.v2021_10_01.Budgets;

internal class Definition : ResourceDefinition
{
    public string Name => "Budgets";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(BudgetOperatorTypeConstant),
        typeof(CategoryTypeConstant),
        typeof(CultureCodeConstant),
        typeof(OperatorTypeConstant),
        typeof(ThresholdTypeConstant),
        typeof(TimeGrainTypeConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(BudgetModel),
        typeof(BudgetComparisonExpressionModel),
        typeof(BudgetFilterModel),
        typeof(BudgetFilterPropertiesModel),
        typeof(BudgetPropertiesModel),
        typeof(BudgetTimePeriodModel),
        typeof(CurrentSpendModel),
        typeof(ForecastSpendModel),
        typeof(NotificationModel),
    };
}
