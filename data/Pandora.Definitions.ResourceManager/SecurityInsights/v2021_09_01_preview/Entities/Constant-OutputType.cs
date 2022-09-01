using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.SecurityInsights.v2021_09_01_preview.Entities;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum OutputTypeConstant
{
    [Description("Date")]
    Date,

    [Description("Entity")]
    Entity,

    [Description("Number")]
    Number,

    [Description("String")]
    String,
}
