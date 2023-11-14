using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Web.v2023_01_01.CertificateOrdersDiagnostics;

internal class Definition : ResourceDefinition
{
    public string Name => "CertificateOrdersDiagnostics";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new GetAppServiceCertificateOrderDetectorResponseOperation(),
        new ListAppServiceCertificateOrderDetectorResponseOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(DetectorTypeConstant),
        typeof(InsightStatusConstant),
        typeof(RenderingTypeConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(DataProviderMetadataModel),
        typeof(DataTableResponseColumnModel),
        typeof(DataTableResponseObjectModel),
        typeof(DetectorInfoModel),
        typeof(DetectorResponseModel),
        typeof(DetectorResponsePropertiesModel),
        typeof(DiagnosticDataModel),
        typeof(KeyValuePairStringObjectModel),
        typeof(QueryUtterancesResultModel),
        typeof(QueryUtterancesResultsModel),
        typeof(RenderingModel),
        typeof(SampleUtteranceModel),
        typeof(StatusModel),
        typeof(SupportTopicModel),
    };
}
