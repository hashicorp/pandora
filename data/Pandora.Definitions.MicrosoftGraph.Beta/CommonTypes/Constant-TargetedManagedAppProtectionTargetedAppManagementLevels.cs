// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum TargetedManagedAppProtectionTargetedAppManagementLevelsConstant
{
    [Description("Unspecified")]
    @unspecified,

    [Description("Unmanaged")]
    @unmanaged,

    [Description("Mdm")]
    @mdm,

    [Description("AndroidEnterprise")]
    @androidEnterprise,

    [Description("AndroidEnterpriseDedicatedDevicesWithAzureAdSharedMode")]
    @androidEnterpriseDedicatedDevicesWithAzureAdSharedMode,

    [Description("AndroidOpenSourceProjectUserAssociated")]
    @androidOpenSourceProjectUserAssociated,

    [Description("AndroidOpenSourceProjectUserless")]
    @androidOpenSourceProjectUserless,
}
