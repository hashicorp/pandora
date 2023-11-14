using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Web.v2023_01_01.Diagnostics;

internal class Definition : ResourceDefinition
{
    public string Name => "Diagnostics";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new ExecuteSiteAnalysisOperation(),
        new ExecuteSiteAnalysisSlotOperation(),
        new ExecuteSiteDetectorOperation(),
        new ExecuteSiteDetectorSlotOperation(),
        new GetHostingEnvironmentDetectorResponseOperation(),
        new GetSiteAnalysisOperation(),
        new GetSiteAnalysisSlotOperation(),
        new GetSiteDetectorOperation(),
        new GetSiteDetectorResponseOperation(),
        new GetSiteDetectorResponseSlotOperation(),
        new GetSiteDetectorSlotOperation(),
        new GetSiteDiagnosticCategoryOperation(),
        new GetSiteDiagnosticCategorySlotOperation(),
        new ListHostingEnvironmentDetectorResponsesOperation(),
        new ListSiteAnalysesOperation(),
        new ListSiteAnalysesSlotOperation(),
        new ListSiteDetectorResponsesOperation(),
        new ListSiteDetectorResponsesSlotOperation(),
        new ListSiteDetectorsOperation(),
        new ListSiteDetectorsSlotOperation(),
        new ListSiteDiagnosticCategoriesOperation(),
        new ListSiteDiagnosticCategoriesSlotOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(DetectorTypeConstant),
        typeof(InsightStatusConstant),
        typeof(IssueTypeConstant),
        typeof(RenderingTypeConstant),
        typeof(SolutionTypeConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(AbnormalTimePeriodModel),
        typeof(AnalysisDataModel),
        typeof(AnalysisDefinitionModel),
        typeof(AnalysisDefinitionPropertiesModel),
        typeof(DataProviderMetadataModel),
        typeof(DataSourceModel),
        typeof(DataTableResponseColumnModel),
        typeof(DataTableResponseObjectModel),
        typeof(DetectorAbnormalTimePeriodModel),
        typeof(DetectorDefinitionModel),
        typeof(DetectorDefinitionResourceModel),
        typeof(DetectorInfoModel),
        typeof(DetectorResponseModel),
        typeof(DetectorResponsePropertiesModel),
        typeof(DiagnosticAnalysisModel),
        typeof(DiagnosticAnalysisPropertiesModel),
        typeof(DiagnosticCategoryModel),
        typeof(DiagnosticCategoryPropertiesModel),
        typeof(DiagnosticDataModel),
        typeof(DiagnosticDetectorResponseModel),
        typeof(DiagnosticDetectorResponsePropertiesModel),
        typeof(DiagnosticMetricSampleModel),
        typeof(DiagnosticMetricSetModel),
        typeof(KeyValuePairStringObjectModel),
        typeof(NameValuePairModel),
        typeof(QueryUtterancesResultModel),
        typeof(QueryUtterancesResultsModel),
        typeof(RenderingModel),
        typeof(ResponseMetaDataModel),
        typeof(SampleUtteranceModel),
        typeof(SolutionModel),
        typeof(StatusModel),
        typeof(SupportTopicModel),
    };
}
