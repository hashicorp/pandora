using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Synapse.v2021_06_01.IntegrationRuntime;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum IntegrationRuntimeInternalChannelEncryptionModeConstant
{
    [Description("NotEncrypted")]
    NotEncrypted,

    [Description("NotSet")]
    NotSet,

    [Description("SslEncrypted")]
    SslEncrypted,
}
