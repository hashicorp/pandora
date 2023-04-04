using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.SecurityInsights.v2022_10_01_preview.Entities;

internal class Definition : ResourceDefinition
{
    public string Name => "Entities";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new ExpandOperation(),
        new GetOperation(),
        new GetInsightsOperation(),
        new GetTimelinelistOperation(),
        new ListOperation(),
        new QueriesOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(AlertSeverityConstant),
        typeof(EntityItemQueryKindConstant),
        typeof(EntityKindConstant),
        typeof(EntityQueryKindConstant),
        typeof(EntityTimelineKindConstant),
        typeof(EntityTypeConstant),
        typeof(GetInsightsErrorConstant),
        typeof(KillChainIntentConstant),
        typeof(OutputTypeConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(ActivityTimelineItemModel),
        typeof(AnomalyTimelineItemModel),
        typeof(BookmarkTimelineItemModel),
        typeof(EntityModel),
        typeof(EntityEdgesModel),
        typeof(EntityExpandParametersModel),
        typeof(EntityExpandResponseModel),
        typeof(EntityExpandResponseValueModel),
        typeof(EntityGetInsightsParametersModel),
        typeof(EntityGetInsightsResponseModel),
        typeof(EntityInsightItemModel),
        typeof(EntityInsightItemQueryTimeIntervalModel),
        typeof(EntityQueryItemModel),
        typeof(EntityQueryItemPropertiesDataTypesInlinedModel),
        typeof(EntityTimelineItemModel),
        typeof(EntityTimelineParametersModel),
        typeof(EntityTimelineResponseModel),
        typeof(ExpansionResultAggregationModel),
        typeof(ExpansionResultsMetadataModel),
        typeof(GetInsightsErrorKindModel),
        typeof(GetInsightsResultsMetadataModel),
        typeof(GetQueriesResponseModel),
        typeof(InsightQueryItemModel),
        typeof(InsightQueryItemPropertiesModel),
        typeof(InsightQueryItemPropertiesAdditionalQueryModel),
        typeof(InsightQueryItemPropertiesDefaultTimeRangeModel),
        typeof(InsightQueryItemPropertiesReferenceTimeRangeModel),
        typeof(InsightQueryItemPropertiesTableQueryModel),
        typeof(InsightQueryItemPropertiesTableQueryColumnsDefinitionsInlinedModel),
        typeof(InsightQueryItemPropertiesTableQueryQueriesDefinitionsInlinedModel),
        typeof(InsightQueryItemPropertiesTableQueryQueriesDefinitionsInlinedLinkColumnsDefinitionsInlinedModel),
        typeof(InsightsTableResultModel),
        typeof(InsightsTableResultColumnsInlinedModel),
        typeof(SecurityAlertTimelineItemModel),
        typeof(TimelineAggregationModel),
        typeof(TimelineErrorModel),
        typeof(TimelineResultsMetadataModel),
        typeof(UserInfoModel),
    };
}
