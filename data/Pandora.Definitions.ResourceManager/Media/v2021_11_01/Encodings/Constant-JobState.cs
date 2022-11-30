using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Media.v2021_11_01.Encodings;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum JobStateConstant
{
    [Description("Canceled")]
    Canceled,

    [Description("Canceling")]
    Canceling,

    [Description("Error")]
    Error,

    [Description("Finished")]
    Finished,

    [Description("Processing")]
    Processing,

    [Description("Queued")]
    Queued,

    [Description("Scheduled")]
    Scheduled,
}
