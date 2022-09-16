using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Synapse.v2021_06_01.BigDataPools;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ConfigurationTypeConstant
{
    [Description("Artifact")]
    Artifact,

    [Description("File")]
    File,
}
