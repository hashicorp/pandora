using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Automation.v2023_11_01.HybridRunbookWorkerGroup;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum GroupTypeEnumConstant
{
    [Description("System")]
    System,

    [Description("User")]
    User,
}
