using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.SecurityInsights.v2022_10_01_preview.Watchlists;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SourceTypeConstant
{
    [Description("Local file")]
    LocalFile,

    [Description("Remote storage")]
    RemoteStorage,
}
