using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Resources.v2022_12_01.Tenants;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ResourceNameStatusConstant
{
    [Description("Allowed")]
    Allowed,

    [Description("Reserved")]
    Reserved,
}
