// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum CloudPcReportNameConstant
{
    [Description("RemoteConnectionHistoricalReports")]
    @remoteConnectionHistoricalReports,

    [Description("DailyAggregatedRemoteConnectionReports")]
    @dailyAggregatedRemoteConnectionReports,

    [Description("TotalAggregatedRemoteConnectionReports")]
    @totalAggregatedRemoteConnectionReports,

    [Description("SharedUseLicenseUsageReport")]
    @sharedUseLicenseUsageReport,

    [Description("SharedUseLicenseUsageRealTimeReport")]
    @sharedUseLicenseUsageRealTimeReport,
}
