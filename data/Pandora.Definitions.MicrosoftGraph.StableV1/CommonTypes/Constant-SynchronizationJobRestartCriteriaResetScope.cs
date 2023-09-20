// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SynchronizationJobRestartCriteriaResetScopeConstant
{
    [Description("None")]
    @None,

    [Description("ConnectorDataStore")]
    @ConnectorDataStore,

    [Description("Escrows")]
    @Escrows,

    [Description("Watermark")]
    @Watermark,

    [Description("QuarantineState")]
    @QuarantineState,

    [Description("Full")]
    @Full,

    [Description("ForceDeletes")]
    @ForceDeletes,
}
