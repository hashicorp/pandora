// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum DeviceManagementConfigurationPolicyTemplateLifecycleStateConstant
{
    [Description("Invalid")]
    @invalid,

    [Description("Draft")]
    @draft,

    [Description("Active")]
    @active,

    [Description("Superseded")]
    @superseded,

    [Description("Deprecated")]
    @deprecated,

    [Description("Retired")]
    @retired,
}
