using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.SecurityInsights.v2023_11_01.SourceControls;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum RepoTypeConstant
{
    [Description("AzureDevOps")]
    AzureDevOps,

    [Description("Github")]
    Github,
}
