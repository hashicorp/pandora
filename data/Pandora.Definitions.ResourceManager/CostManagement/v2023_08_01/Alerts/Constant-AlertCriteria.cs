// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.CostManagement.v2023_08_01.Alerts;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AlertCriteriaConstant
{
    [Description("CostThresholdExceeded")]
    CostThresholdExceeded,

    [Description("CreditThresholdApproaching")]
    CreditThresholdApproaching,

    [Description("CreditThresholdReached")]
    CreditThresholdReached,

    [Description("CrossCloudCollectionError")]
    CrossCloudCollectionError,

    [Description("CrossCloudNewDataAvailable")]
    CrossCloudNewDataAvailable,

    [Description("ForecastCostThresholdExceeded")]
    ForecastCostThresholdExceeded,

    [Description("ForecastUsageThresholdExceeded")]
    ForecastUsageThresholdExceeded,

    [Description("GeneralThresholdError")]
    GeneralThresholdError,

    [Description("InvoiceDueDateApproaching")]
    InvoiceDueDateApproaching,

    [Description("InvoiceDueDateReached")]
    InvoiceDueDateReached,

    [Description("MultiCurrency")]
    MultiCurrency,

    [Description("QuotaThresholdApproaching")]
    QuotaThresholdApproaching,

    [Description("QuotaThresholdReached")]
    QuotaThresholdReached,

    [Description("UsageThresholdExceeded")]
    UsageThresholdExceeded,
}
