// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum DeviceManagementApplicabilityRuleOsEditionOsEditionTypesConstant
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

    [Description("NotConfigured")]
    @notConfigured,

    [Description("Windows10Home")]
    @windows10Home,

    [Description("Windows10HomeChina")]
    @windows10HomeChina,

    [Description("Windows10HomeN")]
    @windows10HomeN,

    [Description("Windows10HomeSingleLanguage")]
    @windows10HomeSingleLanguage,

    [Description("Windows10Mobile")]
    @windows10Mobile,

    [Description("Windows10IoTCore")]
    @windows10IoTCore,

    [Description("Windows10IoTCoreCommercial")]
    @windows10IoTCoreCommercial,
}
