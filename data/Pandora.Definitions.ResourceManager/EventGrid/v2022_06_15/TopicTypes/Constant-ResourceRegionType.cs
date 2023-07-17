using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.EventGrid.v2022_06_15.TopicTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ResourceRegionTypeConstant
{
    [Description("GlobalResource")]
    GlobalResource,

    [Description("RegionalResource")]
    RegionalResource,
}
