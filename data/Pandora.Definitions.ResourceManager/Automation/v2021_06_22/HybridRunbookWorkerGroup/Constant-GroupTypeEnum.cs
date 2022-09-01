using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Automation.v2021_06_22.HybridRunbookWorkerGroup;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum GroupTypeEnumConstant
{
    [Description("System")]
    System,

    [Description("User")]
    User,
}
