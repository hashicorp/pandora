// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Users.Beta.UserManagedDevice;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum CreateUserByIdManagedDeviceByIdOverrideComplianceStateRequestComplianceStateConstant
{
    [Description("BasedOnDeviceCompliancePolicy")]
    @basedOnDeviceCompliancePolicy,

    [Description("NonCompliant")]
    @nonCompliant,
}
