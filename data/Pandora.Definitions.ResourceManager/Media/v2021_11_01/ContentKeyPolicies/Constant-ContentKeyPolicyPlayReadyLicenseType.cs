// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Media.v2021_11_01.ContentKeyPolicies;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ContentKeyPolicyPlayReadyLicenseTypeConstant
{
    [Description("NonPersistent")]
    NonPersistent,

    [Description("Persistent")]
    Persistent,

    [Description("Unknown")]
    Unknown,
}
