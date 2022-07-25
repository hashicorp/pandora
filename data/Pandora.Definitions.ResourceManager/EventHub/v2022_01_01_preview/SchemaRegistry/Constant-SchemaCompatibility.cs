using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.EventHub.v2022_01_01_preview.SchemaRegistry;

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
