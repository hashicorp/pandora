// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Sql.v2023_02_01_preview.DatabaseAutomaticTuning;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AutomaticTuningDisabledReasonConstant
{
    [Description("AutoConfigured")]
    AutoConfigured,

    [Description("Default")]
    Default,

    [Description("Disabled")]
    Disabled,

    [Description("InheritedFromServer")]
    InheritedFromServer,

    [Description("NotSupported")]
    NotSupported,

    [Description("QueryStoreOff")]
    QueryStoreOff,

    [Description("QueryStoreReadOnly")]
    QueryStoreReadOnly,
}
