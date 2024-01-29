// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ApiManagement.v2021_08_01.Logger;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum LoggerTypeConstant
{
    [Description("applicationInsights")]
    ApplicationInsights,

    [Description("azureEventHub")]
    AzureEventHub,

    [Description("azureMonitor")]
    AzureMonitor,
}
