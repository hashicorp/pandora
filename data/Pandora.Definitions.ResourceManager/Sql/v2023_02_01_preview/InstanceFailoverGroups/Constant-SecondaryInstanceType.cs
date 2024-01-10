using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Sql.v2023_02_01_preview.InstanceFailoverGroups;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SecondaryInstanceTypeConstant
{
    [Description("Geo")]
    Geo,

    [Description("Standby")]
    Standby,
}
