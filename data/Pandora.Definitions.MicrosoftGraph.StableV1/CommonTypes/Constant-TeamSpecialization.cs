// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum TeamSpecializationConstant
{
    [Description("None")]
    @none,

    [Description("EducationStandard")]
    @educationStandard,

    [Description("EducationClass")]
    @educationClass,

    [Description("EducationProfessionalLearningCommunity")]
    @educationProfessionalLearningCommunity,

    [Description("EducationStaff")]
    @educationStaff,

    [Description("HealthcareStandard")]
    @healthcareStandard,

    [Description("HealthcareCareCoordination")]
    @healthcareCareCoordination,
}
