using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Logz.v2020_10_01.SubAccount;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum LiftrResourceCategoriesConstant
{
    [Description("MonitorLogs")]
    MonitorLogs,

    [Description("Unknown")]
    Unknown,
}
