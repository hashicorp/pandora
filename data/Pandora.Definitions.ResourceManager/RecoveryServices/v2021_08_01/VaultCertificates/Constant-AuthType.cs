// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.RecoveryServices.v2021_08_01.VaultCertificates;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AuthTypeConstant
{
    [Description("AAD")]
    AAD,

    [Description("ACS")]
    ACS,

    [Description("AccessControlService")]
    AccessControlService,

    [Description("AzureActiveDirectory")]
    AzureActiveDirectory,

    [Description("Invalid")]
    Invalid,
}
