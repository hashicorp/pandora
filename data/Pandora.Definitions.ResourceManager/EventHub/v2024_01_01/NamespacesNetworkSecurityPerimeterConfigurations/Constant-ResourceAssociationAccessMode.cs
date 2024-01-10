using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.EventHub.v2024_01_01.NamespacesNetworkSecurityPerimeterConfigurations;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ResourceAssociationAccessModeConstant
{
    [Description("AuditMode")]
    AuditMode,

    [Description("EnforcedMode")]
    EnforcedMode,

    [Description("LearningMode")]
    LearningMode,

    [Description("NoAssociationMode")]
    NoAssociationMode,

    [Description("UnspecifiedMode")]
    UnspecifiedMode,
}
