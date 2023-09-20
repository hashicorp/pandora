// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SkillProficiencyProficiencyConstant
{
    [Description("Elementary")]
    @elementary,

    [Description("LimitedWorking")]
    @limitedWorking,

    [Description("GeneralProfessional")]
    @generalProfessional,

    [Description("AdvancedProfessional")]
    @advancedProfessional,

    [Description("Expert")]
    @expert,
}
