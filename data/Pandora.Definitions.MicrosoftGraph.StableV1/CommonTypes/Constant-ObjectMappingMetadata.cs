// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ObjectMappingMetadataConstant
{
    [Description("EscrowBehavior")]
    @EscrowBehavior,

    [Description("DisableMonitoringForChanges")]
    @DisableMonitoringForChanges,

    [Description("OriginalJoiningProperty")]
    @OriginalJoiningProperty,

    [Description("Disposition")]
    @Disposition,

    [Description("IsCustomerDefined")]
    @IsCustomerDefined,

    [Description("ExcludeFromReporting")]
    @ExcludeFromReporting,

    [Description("Unsynchronized")]
    @Unsynchronized,
}
