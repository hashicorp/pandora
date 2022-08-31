using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Web.v2016_06_01.ManagedAPIs;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ApiTypeConstant
{
    [Description("NotSpecified")]
    NotSpecified,

    [Description("Rest")]
    Rest,

    [Description("Soap")]
    Soap,
}
