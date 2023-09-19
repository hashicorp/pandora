// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ImportedDeviceIdentityEnrollmentStateConstant
{
    [Description("Unknown")]
    @unknown,

    [Description("Enrolled")]
    @enrolled,

    [Description("PendingReset")]
    @pendingReset,

    [Description("Failed")]
    @failed,

    [Description("NotContacted")]
    @notContacted,

    [Description("Blocked")]
    @blocked,
}
