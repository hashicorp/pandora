// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Web.v2022_09_01.CertificateOrdersDiagnostics;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum DetectorTypeConstant
{
    [Description("Analysis")]
    Analysis,

    [Description("CategoryOverview")]
    CategoryOverview,

    [Description("Detector")]
    Detector,
}
