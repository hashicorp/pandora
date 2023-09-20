// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SecurityEdiscoveryIndexOperationActionConstant
{
    [Description("ContentExport")]
    @contentExport,

    [Description("ApplyTags")]
    @applyTags,

    [Description("ConvertToPdf")]
    @convertToPdf,

    [Description("Index")]
    @index,

    [Description("EstimateStatistics")]
    @estimateStatistics,

    [Description("AddToReviewSet")]
    @addToReviewSet,

    [Description("HoldUpdate")]
    @holdUpdate,

    [Description("PurgeData")]
    @purgeData,
}
