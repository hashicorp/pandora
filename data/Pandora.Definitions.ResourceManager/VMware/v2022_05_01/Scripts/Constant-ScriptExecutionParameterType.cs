using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.VMware.v2022_05_01.Scripts;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ScriptExecutionParameterTypeConstant
{
    [Description("Credential")]
    Credential,

    [Description("SecureValue")]
    SecureValue,

    [Description("Value")]
    Value,
}
