// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum LanguageProficiencyReadingConstant
{
    [Description("Elementary")]
    @elementary,

    [Description("Conversational")]
    @conversational,

    [Description("LimitedWorking")]
    @limitedWorking,

    [Description("ProfessionalWorking")]
    @professionalWorking,

    [Description("FullProfessional")]
    @fullProfessional,

    [Description("NativeOrBilingual")]
    @nativeOrBilingual,
}
