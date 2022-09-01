using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.PowerBIDedicated.v2021_01_01.Capacities;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ModeConstant
{
    [Description("Gen1")]
    GenOne,

    [Description("Gen2")]
    GenTwo,
}
