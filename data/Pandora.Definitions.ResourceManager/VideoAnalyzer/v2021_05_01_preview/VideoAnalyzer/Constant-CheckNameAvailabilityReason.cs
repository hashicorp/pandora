using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.VideoAnalyzer.v2021_05_01_preview.VideoAnalyzer
{
    [ConstantType(ConstantTypeAttribute.ConstantType.String)]
    internal enum CheckNameAvailabilityReasonConstant
    {
        [Description("AlreadyExists")]
        AlreadyExists,

        [Description("Invalid")]
        Invalid,
    }
}
