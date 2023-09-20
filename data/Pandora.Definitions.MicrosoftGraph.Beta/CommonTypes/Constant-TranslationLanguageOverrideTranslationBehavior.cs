// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum TranslationLanguageOverrideTranslationBehaviorConstant
{
    [Description("Ask")]
    @Ask,

    [Description("Yes")]
    @Yes,

    [Description("No")]
    @No,
}
