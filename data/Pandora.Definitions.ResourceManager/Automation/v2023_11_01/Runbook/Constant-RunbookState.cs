using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Automation.v2023_11_01.Runbook;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum RunbookStateConstant
{
    [Description("Edit")]
    Edit,

    [Description("New")]
    New,

    [Description("Published")]
    Published,
}
