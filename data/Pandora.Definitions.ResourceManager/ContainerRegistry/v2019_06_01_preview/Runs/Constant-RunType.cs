using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ContainerRegistry.v2019_06_01_preview.Runs;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum RunTypeConstant
{
    [Description("AutoBuild")]
    AutoBuild,

    [Description("AutoRun")]
    AutoRun,

    [Description("QuickBuild")]
    QuickBuild,

    [Description("QuickRun")]
    QuickRun,
}
