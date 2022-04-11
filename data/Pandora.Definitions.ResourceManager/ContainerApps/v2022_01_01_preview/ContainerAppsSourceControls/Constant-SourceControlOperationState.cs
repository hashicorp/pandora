using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ContainerApps.v2022_01_01_preview.ContainerAppsSourceControls;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SourceControlOperationStateConstant
{
    [Description("Canceled")]
    Canceled,

    [Description("Failed")]
    Failed,

    [Description("InProgress")]
    InProgress,

    [Description("Succeeded")]
    Succeeded,
}
