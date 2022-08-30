using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Automation.v2019_06_01.SoftwareUpdateConfiguration;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum WindowsUpdateClassesConstant
{
    [Description("Critical")]
    Critical,

    [Description("Definition")]
    Definition,

    [Description("FeaturePack")]
    FeaturePack,

    [Description("Security")]
    Security,

    [Description("ServicePack")]
    ServicePack,

    [Description("Tools")]
    Tools,

    [Description("Unclassified")]
    Unclassified,

    [Description("UpdateRollup")]
    UpdateRollup,

    [Description("Updates")]
    Updates,
}
