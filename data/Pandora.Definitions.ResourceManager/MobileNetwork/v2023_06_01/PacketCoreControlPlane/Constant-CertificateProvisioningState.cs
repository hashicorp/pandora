// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.MobileNetwork.v2023_06_01.PacketCoreControlPlane;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum CertificateProvisioningStateConstant
{
    [Description("Failed")]
    Failed,

    [Description("NotProvisioned")]
    NotProvisioned,

    [Description("Provisioned")]
    Provisioned,
}
