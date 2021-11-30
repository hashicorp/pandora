using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.EventGrid.v2020_10_15_preview.Topics
{
    [ConstantType(ConstantTypeAttribute.ConstantType.String)]
    internal enum SkuConstant
    {
        [Description("Basic")]
        Basic,

        [Description("Premium")]
        Premium,
    }
}
