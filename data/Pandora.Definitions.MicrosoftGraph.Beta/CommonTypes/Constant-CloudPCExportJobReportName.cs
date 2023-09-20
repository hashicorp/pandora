// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum CloudPCExportJobReportNameConstant
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

    [Description("NoLicenseAvailableConnectivityFailureReport")]
    @noLicenseAvailableConnectivityFailureReport,

    [Description("FrontlineLicenseUsageReport")]
    @frontlineLicenseUsageReport,

    [Description("FrontlineLicenseUsageRealTimeReport")]
    @frontlineLicenseUsageRealTimeReport,

    [Description("RemoteConnectionQualityReports")]
    @remoteConnectionQualityReports,

    [Description("InaccessibleCloudPCReports")]
    @inaccessibleCloudPcReports,

    [Description("RawRemoteConnectionReports")]
    @rawRemoteConnectionReports,
}
