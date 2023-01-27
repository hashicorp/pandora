using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.DataDog.v2021_03_01.Rules;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum TagActionConstant
{
    [Description("Exclude")]
    Exclude,

    [Description("Include")]
    Include,
}
