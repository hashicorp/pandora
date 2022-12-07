using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.AzureStackHCI.v2022_12_01.UpdateRuns;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum UpdateRunPropertiesStateConstant
{
    [Description("Failed")]
    Failed,

    [Description("InProgress")]
    InProgress,

    [Description("Succeeded")]
    Succeeded,

    [Description("Unknown")]
    Unknown,
}
