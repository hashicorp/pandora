// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum TrainingAvailabilityStatusConstant
{
    [Description("Unknown")]
    @unknown,

    [Description("NotAvailable")]
    @notAvailable,

    [Description("Available")]
    @available,

    [Description("Archive")]
    @archive,

    [Description("Delete")]
    @delete,
}
