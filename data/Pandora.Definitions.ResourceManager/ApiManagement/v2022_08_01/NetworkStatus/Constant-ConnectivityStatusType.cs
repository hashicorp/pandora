using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ApiManagement.v2022_08_01.NetworkStatus;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ConnectivityStatusTypeConstant
{
    [Description("failure")]
    Failure,

    [Description("initializing")]
    Initializing,

    [Description("success")]
    Success,
}
