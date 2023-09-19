// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum DeviceComplianceScriptErrorCodeConstant
{
    [Description("None")]
    @none,

    [Description("JsonFileInvalid")]
    @jsonFileInvalid,

    [Description("JsonFileMissing")]
    @jsonFileMissing,

    [Description("JsonFileTooLarge")]
    @jsonFileTooLarge,

    [Description("RulesMissing")]
    @rulesMissing,

    [Description("DuplicateRules")]
    @duplicateRules,

    [Description("TooManyRulesSpecified")]
    @tooManyRulesSpecified,

    [Description("OperatorMissing")]
    @operatorMissing,

    [Description("OperatorNotSupported")]
    @operatorNotSupported,

    [Description("DatatypeMissing")]
    @datatypeMissing,

    [Description("DatatypeNotSupported")]
    @datatypeNotSupported,

    [Description("OperatorDataTypeCombinationNotSupported")]
    @operatorDataTypeCombinationNotSupported,

    [Description("MoreInfoUriMissing")]
    @moreInfoUriMissing,

    [Description("MoreInfoUriInvalid")]
    @moreInfoUriInvalid,

    [Description("MoreInfoUriTooLarge")]
    @moreInfoUriTooLarge,

    [Description("DescriptionMissing")]
    @descriptionMissing,

    [Description("DescriptionInvalid")]
    @descriptionInvalid,

    [Description("DescriptionTooLarge")]
    @descriptionTooLarge,

    [Description("TitleMissing")]
    @titleMissing,

    [Description("TitleInvalid")]
    @titleInvalid,

    [Description("TitleTooLarge")]
    @titleTooLarge,

    [Description("OperandMissing")]
    @operandMissing,

    [Description("OperandInvalid")]
    @operandInvalid,

    [Description("OperandTooLarge")]
    @operandTooLarge,

    [Description("SettingNameMissing")]
    @settingNameMissing,

    [Description("SettingNameInvalid")]
    @settingNameInvalid,

    [Description("SettingNameTooLarge")]
    @settingNameTooLarge,

    [Description("EnglishLocaleMissing")]
    @englishLocaleMissing,

    [Description("DuplicateLocales")]
    @duplicateLocales,

    [Description("UnrecognizedLocale")]
    @unrecognizedLocale,

    [Description("Unknown")]
    @unknown,

    [Description("RemediationStringsMissing")]
    @remediationStringsMissing,
}
