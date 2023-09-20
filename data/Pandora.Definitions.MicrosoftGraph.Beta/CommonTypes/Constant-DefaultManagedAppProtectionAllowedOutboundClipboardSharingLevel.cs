// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum DefaultManagedAppProtectionAllowedOutboundClipboardSharingLevelConstant
{
    [Description("AllApps")]
    @allApps,

    [Description("ManagedAppsWithPasteIn")]
    @managedAppsWithPasteIn,

    [Description("ManagedApps")]
    @managedApps,

    [Description("Blocked")]
    @blocked,
}
