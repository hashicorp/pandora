// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ContainerRegistry.v2022_12_01.WebHooks;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum WebhookActionConstant
{
    [Description("chart_delete")]
    ChartDelete,

    [Description("chart_push")]
    ChartPush,

    [Description("delete")]
    Delete,

    [Description("push")]
    Push,

    [Description("quarantine")]
    Quarantine,
}
