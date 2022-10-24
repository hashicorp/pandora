using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.SecurityInsights.v2022_07_01_preview.SourceControls;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum RepoTypeConstant
{
    [Description("DevOps")]
    DevOps,

    [Description("Github")]
    Github,
}
