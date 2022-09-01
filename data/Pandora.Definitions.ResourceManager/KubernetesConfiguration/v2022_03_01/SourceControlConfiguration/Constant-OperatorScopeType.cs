using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.KubernetesConfiguration.v2022_03_01.SourceControlConfiguration;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum OperatorScopeTypeConstant
{
    [Description("cluster")]
    Cluster,

    [Description("namespace")]
    Namespace,
}
