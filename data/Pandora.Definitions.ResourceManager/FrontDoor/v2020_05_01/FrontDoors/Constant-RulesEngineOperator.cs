using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.FrontDoor.v2020_05_01.FrontDoors
{
    [ConstantType(ConstantTypeAttribute.ConstantType.String)]
    internal enum RulesEngineOperatorConstant
    {
        [Description("Any")]
        Any,

        [Description("BeginsWith")]
        BeginsWith,

        [Description("Contains")]
        Contains,

        [Description("EndsWith")]
        EndsWith,

        [Description("Equal")]
        Equal,

        [Description("GeoMatch")]
        GeoMatch,

        [Description("GreaterThan")]
        GreaterThan,

        [Description("GreaterThanOrEqual")]
        GreaterThanOrEqual,

        [Description("IPMatch")]
        IPMatch,

        [Description("LessThan")]
        LessThan,

        [Description("LessThanOrEqual")]
        LessThanOrEqual,
    }
}
