// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ContainerApps.v2022_11_01_preview.ManagedEnvironments;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ManagedCertificateDomainControlValidationConstant
{
    [Description("CNAME")]
    CNAME,

    [Description("HTTP")]
    HTTP,

    [Description("TXT")]
    TXT,
}
