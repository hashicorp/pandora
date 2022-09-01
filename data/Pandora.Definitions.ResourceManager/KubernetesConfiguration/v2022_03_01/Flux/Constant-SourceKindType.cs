using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.KubernetesConfiguration.v2022_03_01.Flux;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SourceKindTypeConstant
{
    [Description("Bucket")]
    Bucket,

    [Description("GitRepository")]
    GitRepository,
}
