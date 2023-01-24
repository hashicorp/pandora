using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Automation.v2020_01_13_preview.HybridRunbookWorkerGroup;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum GroupTypeEnumConstant
{
    [Description("System")]
    System,

    [Description("User")]
    User,
}
