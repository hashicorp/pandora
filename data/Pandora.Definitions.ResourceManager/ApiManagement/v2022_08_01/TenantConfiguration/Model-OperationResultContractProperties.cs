using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ApiManagement.v2022_08_01.TenantConfiguration;


internal class OperationResultContractPropertiesModel
{
    [JsonPropertyName("actionLog")]
    public List<OperationResultLogItemContractModel>? ActionLog { get; set; }

    [JsonPropertyName("error")]
    public ErrorResponseBodyModel? Error { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("resultInfo")]
    public string? ResultInfo { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("started")]
    public DateTime? Started { get; set; }

    [JsonPropertyName("status")]
    public AsyncOperationStatusConstant? Status { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("updated")]
    public DateTime? Updated { get; set; }
}
