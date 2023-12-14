// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SecurityEmailUrlThreatSubmissionOriginalCategoryConstant
{
    [Description("NotJunk")]
    @notJunk,

    [Description("Spam")]
    @spam,

    [Description("Phishing")]
    @phishing,

    [Description("Malware")]
    @malware,
}
