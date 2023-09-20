// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum EdiscoveryCaseHoldOperationActionConstant
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
