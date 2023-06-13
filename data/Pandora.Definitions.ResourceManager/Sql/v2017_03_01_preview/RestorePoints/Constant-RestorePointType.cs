using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Sql.v2017_03_01_preview.RestorePoints;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum RestorePointTypeConstant
{
    [Description("CONTINUOUS")]
    CONTINUOUS,

    [Description("DISCRETE")]
    DISCRETE,
}
