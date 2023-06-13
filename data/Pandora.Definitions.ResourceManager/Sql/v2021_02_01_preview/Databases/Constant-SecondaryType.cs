using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Sql.v2021_02_01_preview.Databases;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SecondaryTypeConstant
{
    [Description("Geo")]
    Geo,

    [Description("Named")]
    Named,
}
