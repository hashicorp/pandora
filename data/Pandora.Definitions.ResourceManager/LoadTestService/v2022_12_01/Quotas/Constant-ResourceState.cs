using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.LoadTestService.v2022_12_01.Quotas;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ResourceStateConstant
{
    [Description("Canceled")]
    Canceled,

    [Description("Deleted")]
    Deleted,

    [Description("Failed")]
    Failed,

    [Description("Succeeded")]
    Succeeded,
}
