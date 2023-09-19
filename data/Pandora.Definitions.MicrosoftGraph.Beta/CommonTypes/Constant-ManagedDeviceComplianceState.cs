// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ManagedDeviceComplianceStateConstant
{
    [Description("Unknown")]
    @unknown,

    [Description("Compliant")]
    @compliant,

    [Description("Noncompliant")]
    @noncompliant,

    [Description("Conflict")]
    @conflict,

    [Description("Error")]
    @error,

    [Description("InGracePeriod")]
    @inGracePeriod,

    [Description("ConfigManager")]
    @configManager,
}
