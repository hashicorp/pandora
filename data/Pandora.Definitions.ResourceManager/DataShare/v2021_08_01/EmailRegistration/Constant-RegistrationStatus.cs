using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.DataShare.v2021_08_01.EmailRegistration;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum RegistrationStatusConstant
{
    [Description("Activated")]
    Activated,

    [Description("ActivationAttemptsExhausted")]
    ActivationAttemptsExhausted,

    [Description("ActivationPending")]
    ActivationPending,
}
