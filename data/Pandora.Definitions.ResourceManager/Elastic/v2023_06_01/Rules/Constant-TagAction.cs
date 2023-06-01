using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Elastic.v2023_06_01.Rules;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum TagActionConstant
{
    [Description("Exclude")]
    Exclude,

    [Description("Include")]
    Include,
}
