using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.SecurityInsights.v2022_10_01_preview.ThreatIntelligence;

internal class Definition : ResourceDefinition
{
    public string Name => "ThreatIntelligence";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new IndicatorAppendTagsOperation(),
        new IndicatorCreateOperation(),
        new IndicatorCreateIndicatorOperation(),
        new IndicatorDeleteOperation(),
        new IndicatorGetOperation(),
        new IndicatorMetricsListOperation(),
        new IndicatorQueryIndicatorsOperation(),
        new IndicatorReplaceTagsOperation(),
        new IndicatorsListOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(ThreatIntelligenceResourceKindEnumConstant),
        typeof(ThreatIntelligenceSortingCriteriaEnumConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(ThreatIntelligenceAppendTagsModel),
        typeof(ThreatIntelligenceExternalReferenceModel),
        typeof(ThreatIntelligenceFilteringCriteriaModel),
        typeof(ThreatIntelligenceGranularMarkingModelModel),
        typeof(ThreatIntelligenceIndicatorModelModel),
        typeof(ThreatIntelligenceIndicatorPropertiesModel),
        typeof(ThreatIntelligenceInformationModel),
        typeof(ThreatIntelligenceKillChainPhaseModel),
        typeof(ThreatIntelligenceMetricModel),
        typeof(ThreatIntelligenceMetricEntityModel),
        typeof(ThreatIntelligenceMetricsModel),
        typeof(ThreatIntelligenceMetricsListModel),
        typeof(ThreatIntelligenceParsedPatternModel),
        typeof(ThreatIntelligenceParsedPatternTypeValueModel),
        typeof(ThreatIntelligenceSortingCriteriaModel),
    };
}
