using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.KubernetesConfiguration.v2022_03_01.SourceControlConfiguration;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum OperatorTypeConstant
{
    [Description("Flux")]
    Flux,
}
