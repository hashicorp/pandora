// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SecurityRunDetailsErrorCodeConstant
{
    [Description("QueryExecutionFailed")]
    @queryExecutionFailed,

    [Description("QueryExecutionThrottling")]
    @queryExecutionThrottling,

    [Description("QueryExceededResultSize")]
    @queryExceededResultSize,

    [Description("QueryLimitsExceeded")]
    @queryLimitsExceeded,

    [Description("QueryTimeout")]
    @queryTimeout,

    [Description("AlertCreationFailed")]
    @alertCreationFailed,

    [Description("AlertReportNotFound")]
    @alertReportNotFound,

    [Description("PartialRowsFailed")]
    @partialRowsFailed,
}
