// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.SignalR.v2023_02_01.SignalR;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum FeatureFlagsConstant
{
    [Description("EnableConnectivityLogs")]
    EnableConnectivityLogs,

    [Description("EnableLiveTrace")]
    EnableLiveTrace,

    [Description("EnableMessagingLogs")]
    EnableMessagingLogs,

    [Description("ServiceMode")]
    ServiceMode,
}
