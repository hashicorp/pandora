// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum Windows10EditionTypeConstant
{
    [Description("Windows10Enterprise")]
    @windows10Enterprise,

    [Description("Windows10EnterpriseN")]
    @windows10EnterpriseN,

    [Description("Windows10Education")]
    @windows10Education,

    [Description("Windows10EducationN")]
    @windows10EducationN,

    [Description("Windows10MobileEnterprise")]
    @windows10MobileEnterprise,

    [Description("Windows10HolographicEnterprise")]
    @windows10HolographicEnterprise,

    [Description("Windows10Professional")]
    @windows10Professional,

    [Description("Windows10ProfessionalN")]
    @windows10ProfessionalN,

    [Description("Windows10ProfessionalEducation")]
    @windows10ProfessionalEducation,

    [Description("Windows10ProfessionalEducationN")]
    @windows10ProfessionalEducationN,

    [Description("Windows10ProfessionalWorkstation")]
    @windows10ProfessionalWorkstation,

    [Description("Windows10ProfessionalWorkstationN")]
    @windows10ProfessionalWorkstationN,
}
