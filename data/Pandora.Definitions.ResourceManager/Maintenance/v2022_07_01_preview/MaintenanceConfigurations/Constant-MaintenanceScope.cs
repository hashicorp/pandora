using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Maintenance.v2022_07_01_preview.MaintenanceConfigurations;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum MaintenanceScopeConstant
{
    [Description("Extension")]
    Extension,

    [Description("Host")]
    Host,

    [Description("InGuestPatch")]
    InGuestPatch,

    [Description("OSImage")]
    OSImage,

    [Description("Resource")]
    Resource,

    [Description("SQLDB")]
    SQLDB,

    [Description("SQLManagedInstance")]
    SQLManagedInstance,
}
