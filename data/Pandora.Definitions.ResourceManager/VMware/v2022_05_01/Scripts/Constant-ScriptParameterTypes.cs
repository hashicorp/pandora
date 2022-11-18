using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.VMware.v2022_05_01.Scripts;

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
