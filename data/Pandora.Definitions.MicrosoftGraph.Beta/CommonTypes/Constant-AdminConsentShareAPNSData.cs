// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AdminConsentShareAPNSDataConstant
{
    [Description("NotConfigured")]
    @notConfigured,

    [Description("Granted")]
    @granted,

    [Description("NotGranted")]
    @notGranted,
}
