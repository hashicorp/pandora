using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Maintenance.v2022_07_01_preview.PublicMaintenanceConfigurations;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum TaskScopeConstant
{
    [Description("Global")]
    Global,

    [Description("Resource")]
    Resource,
}
