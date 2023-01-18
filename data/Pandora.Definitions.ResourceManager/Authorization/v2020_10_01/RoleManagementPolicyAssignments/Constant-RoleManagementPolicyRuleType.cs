using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Authorization.v2020_10_01.RoleManagementPolicyAssignments;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum RoleManagementPolicyRuleTypeConstant
{
    [Description("RoleManagementPolicyApprovalRule")]
    RoleManagementPolicyApprovalRule,

    [Description("RoleManagementPolicyAuthenticationContextRule")]
    RoleManagementPolicyAuthenticationContextRule,

    [Description("RoleManagementPolicyEnablementRule")]
    RoleManagementPolicyEnablementRule,

    [Description("RoleManagementPolicyExpirationRule")]
    RoleManagementPolicyExpirationRule,

    [Description("RoleManagementPolicyNotificationRule")]
    RoleManagementPolicyNotificationRule,
}
