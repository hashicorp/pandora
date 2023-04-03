using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Insights.v2018_03_01.MetricAlerts;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum OdatatypeConstant
{
    [Description("Microsoft.Azure.Monitor.MultipleResourceMultipleMetricCriteria")]
    MicrosoftPointAzurePointMonitorPointMultipleResourceMultipleMetricCriteria,

    [Description("Microsoft.Azure.Monitor.SingleResourceMultipleMetricCriteria")]
    MicrosoftPointAzurePointMonitorPointSingleResourceMultipleMetricCriteria,

    [Description("Microsoft.Azure.Monitor.WebtestLocationAvailabilityCriteria")]
    MicrosoftPointAzurePointMonitorPointWebtestLocationAvailabilityCriteria,
}
