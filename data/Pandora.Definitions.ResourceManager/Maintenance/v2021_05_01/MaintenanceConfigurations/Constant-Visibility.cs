using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Maintenance.v2021_05_01.MaintenanceConfigurations;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum VisibilityConstant
{
    [Description("Custom")]
    Custom,

    [Description("Public")]
    Public,
}
