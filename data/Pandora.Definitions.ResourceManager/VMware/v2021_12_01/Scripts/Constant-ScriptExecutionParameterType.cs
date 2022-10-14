using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.VMware.v2021_12_01.Scripts;

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
