using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ApplicationInsights.v2015_05_01.ComponentsAPIs;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum PurgeStateConstant
{
    [Description("completed")]
    Completed,

    [Description("pending")]
    Pending,
}
