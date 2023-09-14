using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Migrate.v2023_06_06.SqlAvailabilityGroupsController;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SqlAvailabilityGroupPropertiesAvailabilityGroupTypeConstant
{
    [Description("Distributed")]
    Distributed,

    [Description("Traditional")]
    Traditional,

    [Description("Unknown")]
    Unknown,
}
