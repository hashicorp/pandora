// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.HybridCompute.v2022_12_27.Machines;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum LastAttemptStatusEnumConstant
{
    [Description("Failed")]
    Failed,

    [Description("Success")]
    Success,
}
