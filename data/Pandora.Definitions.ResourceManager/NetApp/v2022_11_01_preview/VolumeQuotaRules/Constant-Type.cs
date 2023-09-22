using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.NetApp.v2022_11_01_preview.VolumeQuotaRules;

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
