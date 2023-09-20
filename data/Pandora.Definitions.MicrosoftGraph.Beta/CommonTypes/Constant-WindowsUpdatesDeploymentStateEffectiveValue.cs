// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum WindowsUpdatesDeploymentStateEffectiveValueConstant
{
    [Description("Scheduled")]
    @scheduled,

    [Description("Offering")]
    @offering,

    [Description("Paused")]
    @paused,

    [Description("Faulted")]
    @faulted,

    [Description("Archived")]
    @archived,
}
