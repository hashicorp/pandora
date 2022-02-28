using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Elastic.v2020_07_01.MonitoredResources;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SendingLogsConstant
{
    [Description("False")]
    False,

    [Description("True")]
    True,
}
