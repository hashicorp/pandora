using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ApiManagement.v2021_08_01.PerformConnectivityCheck;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SeverityConstant
{
    [Description("Error")]
    Error,

    [Description("Warning")]
    Warning,
}
