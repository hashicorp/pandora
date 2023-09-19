using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.NotificationHubs.v2023_09_01.Namespaces;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ZoneRedundancyPreferenceConstant
{
    [Description("Disabled")]
    Disabled,

    [Description("Enabled")]
    Enabled,
}
