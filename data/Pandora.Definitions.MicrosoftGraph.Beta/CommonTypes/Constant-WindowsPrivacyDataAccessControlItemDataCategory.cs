// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum WindowsPrivacyDataAccessControlItemDataCategoryConstant
{
    [Description("NotConfigured")]
    @notConfigured,

    [Description("AccountInfo")]
    @accountInfo,

    [Description("AppsRunInBackground")]
    @appsRunInBackground,

    [Description("Calendar")]
    @calendar,

    [Description("CallHistory")]
    @callHistory,

    [Description("Camera")]
    @camera,

    [Description("Contacts")]
    @contacts,

    [Description("DiagnosticsInfo")]
    @diagnosticsInfo,

    [Description("Email")]
    @email,

    [Description("Location")]
    @location,

    [Description("Messaging")]
    @messaging,

    [Description("Microphone")]
    @microphone,

    [Description("Motion")]
    @motion,

    [Description("Notifications")]
    @notifications,

    [Description("Phone")]
    @phone,

    [Description("Radios")]
    @radios,

    [Description("Tasks")]
    @tasks,

    [Description("SyncWithDevices")]
    @syncWithDevices,

    [Description("TrustedDevices")]
    @trustedDevices,
}
