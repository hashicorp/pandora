using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.CostManagement.v2023_03_01.BenefitUtilizationSummariesAsync;


internal class AsyncOperationStatusPropertiesModel
{
    [JsonPropertyName("reportUrl")]
    public BenefitUtilizationSummaryReportSchemaConstant? ReportUrl { get; set; }

    [JsonPropertyName("secondaryReportUrl")]
    public BenefitUtilizationSummaryReportSchemaConstant? SecondaryReportUrl { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("validUntil")]
    public DateTime? ValidUntil { get; set; }
}
