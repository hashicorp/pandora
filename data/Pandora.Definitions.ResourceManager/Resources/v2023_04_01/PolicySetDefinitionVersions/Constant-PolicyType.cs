using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Resources.v2023_04_01.PolicySetDefinitionVersions;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum PolicyTypeConstant
{
    [Description("BuiltIn")]
    BuiltIn,

    [Description("Custom")]
    Custom,

    [Description("NotSpecified")]
    NotSpecified,

    [Description("Static")]
    Static,
}
