// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ProvisioningStepProvisioningStepTypeConstant
{
    [Description("Import")]
    @import,

    [Description("Scoping")]
    @scoping,

    [Description("Matching")]
    @matching,

    [Description("Processing")]
    @processing,

    [Description("ReferenceResolution")]
    @referenceResolution,

    [Description("Export")]
    @export,
}
