using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.RedisEnterprise.v2021_08_01.RedisEnterprise
{
    [ConstantType(ConstantTypeAttribute.ConstantType.String)]
    internal enum SkuNameConstant
    {
        [Description("Enterprise_E50")]
        EnterpriseEFiveZero,

        [Description("Enterprise_E10")]
        EnterpriseEOneZero,

        [Description("Enterprise_E100")]
        EnterpriseEOneZeroZero,

        [Description("Enterprise_E20")]
        EnterpriseETwoZero,

        [Description("EnterpriseFlash_F1500")]
        EnterpriseFlashFOneFiveZeroZero,

        [Description("EnterpriseFlash_F700")]
        EnterpriseFlashFSevenZeroZero,

        [Description("EnterpriseFlash_F300")]
        EnterpriseFlashFThreeZeroZero,
    }
}
