using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.DataMigration.v2018_04_19.GET;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ServiceScalabilityConstant
{
    [Description("automatic")]
    Automatic,

    [Description("manual")]
    Manual,

    [Description("none")]
    None,
}
