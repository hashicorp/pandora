using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Media.v2021_11_01.LiveOutputs;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum LiveOutputResourceStateConstant
{
    [Description("Creating")]
    Creating,

    [Description("Deleting")]
    Deleting,

    [Description("Running")]
    Running,
}
