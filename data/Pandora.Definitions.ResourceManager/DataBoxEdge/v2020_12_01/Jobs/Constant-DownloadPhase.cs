using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.DataBoxEdge.v2020_12_01.Jobs;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum DownloadPhaseConstant
{
    [Description("Downloading")]
    Downloading,

    [Description("Initializing")]
    Initializing,

    [Description("Unknown")]
    Unknown,

    [Description("Verifying")]
    Verifying,
}
