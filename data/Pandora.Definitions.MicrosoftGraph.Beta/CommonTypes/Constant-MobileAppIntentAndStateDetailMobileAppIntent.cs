// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum MobileAppIntentAndStateDetailMobileAppIntentConstant
{
    [Description("Available")]
    @available,

    [Description("NotAvailable")]
    @notAvailable,

    [Description("RequiredInstall")]
    @requiredInstall,

    [Description("RequiredUninstall")]
    @requiredUninstall,

    [Description("RequiredAndAvailableInstall")]
    @requiredAndAvailableInstall,

    [Description("AvailableInstallWithoutEnrollment")]
    @availableInstallWithoutEnrollment,

    [Description("Exclude")]
    @exclude,
}
