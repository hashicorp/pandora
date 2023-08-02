// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum WindowsAutopilotEnrollmentTypeConstant
{
    [Description("Unknown")]
    @unknown,

    [Description("AzureADJoinedWithAutopilotProfile")]
    @azureADJoinedWithAutopilotProfile,

    [Description("OfflineDomainJoined")]
    @offlineDomainJoined,

    [Description("AzureADJoinedUsingDeviceAuthWithAutopilotProfile")]
    @azureADJoinedUsingDeviceAuthWithAutopilotProfile,

    [Description("AzureADJoinedUsingDeviceAuthWithoutAutopilotProfile")]
    @azureADJoinedUsingDeviceAuthWithoutAutopilotProfile,

    [Description("AzureADJoinedWithOfflineAutopilotProfile")]
    @azureADJoinedWithOfflineAutopilotProfile,

    [Description("AzureADJoinedWithWhiteGlove")]
    @azureADJoinedWithWhiteGlove,

    [Description("OfflineDomainJoinedWithWhiteGlove")]
    @offlineDomainJoinedWithWhiteGlove,

    [Description("OfflineDomainJoinedWithOfflineAutopilotProfile")]
    @offlineDomainJoinedWithOfflineAutopilotProfile,
}
