using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.NetApp.v2022_09_01.VolumeQuotaRules;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum TypeConstant
{
    [Description("DefaultGroupQuota")]
    DefaultGroupQuota,

    [Description("DefaultUserQuota")]
    DefaultUserQuota,

    [Description("IndividualGroupQuota")]
    IndividualGroupQuota,

    [Description("IndividualUserQuota")]
    IndividualUserQuota,
}
