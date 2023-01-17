using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.DevTestLab.v2018_09_15.CustomImages;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum WindowsOsStateConstant
{
    [Description("NonSysprepped")]
    NonSysprepped,

    [Description("SysprepApplied")]
    SysprepApplied,

    [Description("SysprepRequested")]
    SysprepRequested,
}
