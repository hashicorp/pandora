using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Media.v2020_05_01.Encodings;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum OnErrorTypeConstant
{
    [Description("ContinueJob")]
    ContinueJob,

    [Description("StopProcessingJob")]
    StopProcessingJob,
}
