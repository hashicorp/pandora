// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum IosKioskModeAppTypeConstant
{
    [Description("NotConfigured")]
    @notConfigured,

    [Description("AppStoreApp")]
    @appStoreApp,

    [Description("ManagedApp")]
    @managedApp,

    [Description("BuiltInApp")]
    @builtInApp,
}
