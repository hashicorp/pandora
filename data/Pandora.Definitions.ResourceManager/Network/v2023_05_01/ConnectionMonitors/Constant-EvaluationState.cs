// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Network.v2023_05_01.ConnectionMonitors;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum EvaluationStateConstant
{
    [Description("Completed")]
    Completed,

    [Description("InProgress")]
    InProgress,

    [Description("NotStarted")]
    NotStarted,
}
