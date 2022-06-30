using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.HardwareSecurityModules.v2018_10_31_preview.DedicatedHsms;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SkuNameConstant
{
    [Description("payShield10K_LMK1_CPS60")]
    PayShieldOneZeroKLMKOneCPSSixZero,

    [Description("payShield10K_LMK1_CPS250")]
    PayShieldOneZeroKLMKOneCPSTwoFiveZero,

    [Description("payShield10K_LMK1_CPS2500")]
    PayShieldOneZeroKLMKOneCPSTwoFiveZeroZero,

    [Description("payShield10K_LMK2_CPS60")]
    PayShieldOneZeroKLMKTwoCPSSixZero,

    [Description("payShield10K_LMK2_CPS250")]
    PayShieldOneZeroKLMKTwoCPSTwoFiveZero,

    [Description("payShield10K_LMK2_CPS2500")]
    PayShieldOneZeroKLMKTwoCPSTwoFiveZeroZero,

    [Description("SafeNet Luna Network HSM A790")]
    SafeNetLunaNetworkHSMASevenNineZero,
}
