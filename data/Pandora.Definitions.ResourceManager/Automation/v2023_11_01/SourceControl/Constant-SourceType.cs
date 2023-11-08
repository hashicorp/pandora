using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Automation.v2023_11_01.SourceControl;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SourceTypeConstant
{
    [Description("GitHub")]
    GitHub,

    [Description("VsoGit")]
    VsoGit,

    [Description("VsoTfvc")]
    VsoTfvc,
}
