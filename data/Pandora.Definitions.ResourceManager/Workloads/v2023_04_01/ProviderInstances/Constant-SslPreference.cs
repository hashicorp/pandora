using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Workloads.v2023_04_01.ProviderInstances;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SslPreferenceConstant
{
    [Description("Disabled")]
    Disabled,

    [Description("RootCertificate")]
    RootCertificate,

    [Description("ServerCertificate")]
    ServerCertificate,
}
