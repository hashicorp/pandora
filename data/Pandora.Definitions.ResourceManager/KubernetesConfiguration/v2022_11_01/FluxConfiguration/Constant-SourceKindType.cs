using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.KubernetesConfiguration.v2022_11_01.FluxConfiguration;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SourceKindTypeConstant
{
    [Description("AzureBlob")]
    AzureBlob,

    [Description("Bucket")]
    Bucket,

    [Description("GitRepository")]
    GitRepository,
}
