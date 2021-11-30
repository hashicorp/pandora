using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.EventGrid.v2020_10_15_preview.TopicTypes
{
    [ConstantType(ConstantTypeAttribute.ConstantType.String)]
    internal enum ResourceRegionTypeConstant
    {
        [Description("GlobalResource")]
        GlobalResource,

        [Description("RegionalResource")]
        RegionalResource,
    }
}
