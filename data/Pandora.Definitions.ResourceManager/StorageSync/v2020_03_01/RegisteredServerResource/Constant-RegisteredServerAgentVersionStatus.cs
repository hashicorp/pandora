using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.StorageSync.v2020_03_01.RegisteredServerResource;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum RegisteredServerAgentVersionStatusConstant
{
    [Description("Blocked")]
    Blocked,

    [Description("Expired")]
    Expired,

    [Description("NearExpiry")]
    NearExpiry,

    [Description("Ok")]
    Ok,
}
