using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.SecurityInsights.v2023_02_01.Metadata;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SourceKindConstant
{
    [Description("Community")]
    Community,

    [Description("LocalWorkspace")]
    LocalWorkspace,

    [Description("Solution")]
    Solution,

    [Description("SourceRepository")]
    SourceRepository,
}
