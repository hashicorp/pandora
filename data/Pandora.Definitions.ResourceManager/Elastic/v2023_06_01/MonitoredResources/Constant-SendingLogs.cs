// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Elastic.v2023_06_01.MonitoredResources;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SendingLogsConstant
{
    [Description("False")]
    False,

    [Description("True")]
    True,
}
