using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Security.v2019_08_01.IoTSecuritySolutionAnalytics;

internal class Definition : ResourceDefinition
{
    public string Name => "IoTSecuritySolutionAnalytics";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new IotSecuritySolutionAnalyticsGetOperation(),
        new IotSecuritySolutionAnalyticsListOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(ReportedSeverityConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(IoTSecurityAlertedDeviceModel),
        typeof(IoTSecurityDeviceAlertModel),
        typeof(IoTSecurityDeviceRecommendationModel),
        typeof(IoTSecuritySolutionAnalyticsModelModel),
        typeof(IoTSecuritySolutionAnalyticsModelListModel),
        typeof(IoTSecuritySolutionAnalyticsModelPropertiesModel),
        typeof(IoTSecuritySolutionAnalyticsModelPropertiesDevicesMetricsInlinedModel),
        typeof(IoTSeverityMetricsModel),
    };
}
