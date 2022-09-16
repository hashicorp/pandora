using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Synapse.v2021_06_01.IntegrationRuntime;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SelfHostedIntegrationRuntimeNodeStatusConstant
{
    [Description("InitializeFailed")]
    InitializeFailed,

    [Description("Initializing")]
    Initializing,

    [Description("Limited")]
    Limited,

    [Description("NeedRegistration")]
    NeedRegistration,

    [Description("Offline")]
    Offline,

    [Description("Online")]
    Online,

    [Description("Upgrading")]
    Upgrading,
}
