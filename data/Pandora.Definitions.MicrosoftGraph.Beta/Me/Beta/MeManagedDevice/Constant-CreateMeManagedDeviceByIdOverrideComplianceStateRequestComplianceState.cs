// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Me.Beta.MeManagedDevice;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum CreateMeManagedDeviceByIdOverrideComplianceStateRequestComplianceStateConstant
{
    [Description("BasedOnDeviceCompliancePolicy")]
    @basedOnDeviceCompliancePolicy,

    [Description("NonCompliant")]
    @nonCompliant,
}
