// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ManagedDeviceSummarizedAppStateSummarizedAppStateConstant
{
    [Description("Unknown")]
    @unknown,

    [Description("Success")]
    @success,

    [Description("Fail")]
    @fail,

    [Description("ScriptError")]
    @scriptError,

    [Description("Pending")]
    @pending,

    [Description("NotApplicable")]
    @notApplicable,
}
