using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.DataFactory.v2018_06_01.IntegrationRuntimes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum IntegrationRuntimeStateConstant
{
    [Description("AccessDenied")]
    AccessDenied,

    [Description("Initial")]
    Initial,

    [Description("Limited")]
    Limited,

    [Description("NeedRegistration")]
    NeedRegistration,

    [Description("Offline")]
    Offline,

    [Description("Online")]
    Online,

    [Description("Started")]
    Started,

    [Description("Starting")]
    Starting,

    [Description("Stopped")]
    Stopped,

    [Description("Stopping")]
    Stopping,
}
