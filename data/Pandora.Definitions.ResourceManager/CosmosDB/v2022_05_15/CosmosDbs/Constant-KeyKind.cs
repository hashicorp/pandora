using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.CosmosDB.v2022_05_15.CosmosDbs;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum KeyKindConstant
{
    [Description("primary")]
    Primary,

    [Description("primaryReadonly")]
    PrimaryReadonly,

    [Description("secondary")]
    Secondary,

    [Description("secondaryReadonly")]
    SecondaryReadonly,
}
