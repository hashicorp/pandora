// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum MobileAppAssignmentIntentConstant
{
    [Description("Available")]
    @available,

    [Description("Required")]
    @required,

    [Description("Uninstall")]
    @uninstall,

    [Description("AvailableWithoutEnrollment")]
    @availableWithoutEnrollment,
}
