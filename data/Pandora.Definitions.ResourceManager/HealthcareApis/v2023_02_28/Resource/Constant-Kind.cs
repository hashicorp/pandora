// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.HealthcareApis.v2023_02_28.Resource;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum KindConstant
{
    [Description("fhir")]
    Fhir,

    [Description("fhir-R4")]
    FhirNegativeRFour,

    [Description("fhir-Stu3")]
    FhirNegativeStuThree,
}
