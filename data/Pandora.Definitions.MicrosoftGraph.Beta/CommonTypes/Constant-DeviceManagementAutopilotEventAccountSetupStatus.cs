// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum DeviceManagementAutopilotEventAccountSetupStatusConstant
{
    [Description("Unknown")]
    @unknown,

    [Description("Success")]
    @success,

    [Description("InProgress")]
    @inProgress,

    [Description("Failure")]
    @failure,

    [Description("SuccessWithTimeout")]
    @successWithTimeout,

    [Description("NotAttempted")]
    @notAttempted,

    [Description("Disabled")]
    @disabled,

    [Description("SuccessOnRetry")]
    @successOnRetry,
}
