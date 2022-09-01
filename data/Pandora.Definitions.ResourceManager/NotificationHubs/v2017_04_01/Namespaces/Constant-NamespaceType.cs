using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.NotificationHubs.v2017_04_01.Namespaces;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum NamespaceTypeConstant
{
    [Description("Messaging")]
    Messaging,

    [Description("NotificationHub")]
    NotificationHub,
}
