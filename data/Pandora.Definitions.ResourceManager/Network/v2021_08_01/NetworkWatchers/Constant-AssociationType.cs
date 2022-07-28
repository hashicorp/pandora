using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Network.v2021_08_01.NetworkWatchers;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AssociationTypeConstant
{
    [Description("Associated")]
    Associated,

    [Description("Contains")]
    Contains,
}
