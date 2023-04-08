using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.HDInsight.v2018_06_01_preview.Regions;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum TierConstant
{
    [Description("Premium")]
    Premium,

    [Description("Standard")]
    Standard,
}
