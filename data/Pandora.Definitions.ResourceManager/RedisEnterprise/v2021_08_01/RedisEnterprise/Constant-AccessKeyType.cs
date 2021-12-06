using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.RedisEnterprise.v2021_08_01.RedisEnterprise
{
    [ConstantType(ConstantTypeAttribute.ConstantType.String)]
    internal enum AccessKeyTypeConstant
    {
        [Description("Primary")]
        Primary,

        [Description("Secondary")]
        Secondary,
    }
}
