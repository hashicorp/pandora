using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Logz.v2020_10_01.TagRules;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum TagActionConstant
{
    [Description("Exclude")]
    Exclude,

    [Description("Include")]
    Include,
}
