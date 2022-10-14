using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.VMware.v2021_12_01.Scripts;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ScriptParameterTypesConstant
{
    [Description("Bool")]
    Bool,

    [Description("Credential")]
    Credential,

    [Description("Float")]
    Float,

    [Description("Int")]
    Int,

    [Description("SecureString")]
    SecureString,

    [Description("String")]
    String,
}
