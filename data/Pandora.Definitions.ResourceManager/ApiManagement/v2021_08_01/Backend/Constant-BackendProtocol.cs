using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ApiManagement.v2021_08_01.Backend;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum BackendProtocolConstant
{
    [Description("http")]
    HTTP,

    [Description("soap")]
    Soap,
}
