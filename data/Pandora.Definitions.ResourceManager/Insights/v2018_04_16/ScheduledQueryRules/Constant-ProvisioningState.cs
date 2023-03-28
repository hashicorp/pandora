using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Insights.v2018_04_16.ScheduledQueryRules;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ProvisioningStateConstant
{
    [Description("Canceled")]
    Canceled,

    [Description("Deploying")]
    Deploying,

    [Description("Failed")]
    Failed,

    [Description("Succeeded")]
    Succeeded,
}
