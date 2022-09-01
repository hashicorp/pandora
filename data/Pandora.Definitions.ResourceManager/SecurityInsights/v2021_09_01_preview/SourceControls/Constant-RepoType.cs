using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.SecurityInsights.v2021_09_01_preview.SourceControls;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum RepoTypeConstant
{
    [Description("DevOps")]
    DevOps,

    [Description("Github")]
    Github,
}
