using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.LabServices.v2021_10_01_preview.LabPlan;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ConnectionTypeConstant
{
    [Description("None")]
    None,

    [Description("Private")]
    Private,

    [Description("Public")]
    Public,
}
