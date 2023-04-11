using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Security.v2020_01_01.SecureScoreControlDefinitions;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ControlTypeConstant
{
    [Description("BuiltIn")]
    BuiltIn,

    [Description("Custom")]
    Custom,
}
