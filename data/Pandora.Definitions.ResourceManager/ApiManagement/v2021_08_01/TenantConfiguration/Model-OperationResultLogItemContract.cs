using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ApiManagement.v2021_08_01.TenantConfiguration;


internal class OperationResultLogItemContractModel
{
    [JsonPropertyName("action")]
    public string? Action { get; set; }

    [JsonPropertyName("objectKey")]
    public string? ObjectKey { get; set; }

    [JsonPropertyName("objectType")]
    public string? ObjectType { get; set; }
}
