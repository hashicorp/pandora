// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AccessPackageAssignmentPolicyAllowedTargetScopeConstant
{
    [Description("NotSpecified")]
    @notSpecified,

    [Description("SpecificDirectoryUsers")]
    @specificDirectoryUsers,

    [Description("SpecificConnectedOrganizationUsers")]
    @specificConnectedOrganizationUsers,

    [Description("SpecificDirectoryServicePrincipals")]
    @specificDirectoryServicePrincipals,

    [Description("AllMemberUsers")]
    @allMemberUsers,

    [Description("AllDirectoryUsers")]
    @allDirectoryUsers,

    [Description("AllDirectoryServicePrincipals")]
    @allDirectoryServicePrincipals,

    [Description("AllConfiguredConnectedOrganizationUsers")]
    @allConfiguredConnectedOrganizationUsers,

    [Description("AllExternalUsers")]
    @allExternalUsers,
}
