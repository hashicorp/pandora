using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.EventHub.v2021_11_01.SchemaRegistry;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SchemaCompatibilityConstant
{
    [Description("Backward")]
    Backward,

    [Description("Forward")]
    Forward,

    [Description("None")]
    None,
}
