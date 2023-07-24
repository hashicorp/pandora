using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Web.v2022_09_01.Workflows;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum KeyTypeConstant
{
    [Description("NotSpecified")]
    NotSpecified,

    [Description("Primary")]
    Primary,

    [Description("Secondary")]
    Secondary,
}
