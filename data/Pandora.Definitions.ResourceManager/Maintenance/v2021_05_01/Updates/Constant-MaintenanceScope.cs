using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Maintenance.v2021_05_01.Updates;

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

    [Description("SQLDB")]
    SQLDB,

    [Description("SQLManagedInstance")]
    SQLManagedInstance,
}
