using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.RedisEnterprise.v2022_01_01.RedisEnterprise;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SkuNameConstant
{
    [Description("Enterprise_E50")]
    EnterpriseEFiveZero,

    [Description("Enterprise_E100")]
    EnterpriseEOneHundred,

    [Description("Enterprise_E10")]
    EnterpriseEOneZero,

    [Description("Enterprise_E20")]
    EnterpriseETwoZero,

    [Description("EnterpriseFlash_F1500")]
    EnterpriseFlashFOneFiveHundred,

    [Description("EnterpriseFlash_F700")]
    EnterpriseFlashFSevenHundred,

    [Description("EnterpriseFlash_F300")]
    EnterpriseFlashFThreeHundred,
}
