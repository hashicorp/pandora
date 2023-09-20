// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ConnectionOperationStatusConstant
{
    [Description("Unspecified")]
    @unspecified,

    [Description("Inprogress")]
    @inprogress,

    [Description("Completed")]
    @completed,

    [Description("Failed")]
    @failed,
}
