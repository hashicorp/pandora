using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.PostgreSqlHsc.v2020_10_05_privatepreview.ServerGroups;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ServerStateConstant
{
    [Description("Disabled")]
    Disabled,

    [Description("Dropping")]
    Dropping,

    [Description("Provisioning")]
    Provisioning,

    [Description("Ready")]
    Ready,

    [Description("Starting")]
    Starting,

    [Description("Stopped")]
    Stopped,

    [Description("Stopping")]
    Stopping,

    [Description("Updating")]
    Updating,
}
