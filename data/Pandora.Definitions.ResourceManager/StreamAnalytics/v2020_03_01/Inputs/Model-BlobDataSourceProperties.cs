using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.StreamAnalytics.v2020_03_01.Inputs;


internal class BlobDataSourcePropertiesModel
{
    [JsonPropertyName("authenticationMode")]
    public AuthenticationModeConstant? AuthenticationMode { get; set; }

    [JsonPropertyName("container")]
    public string? Container { get; set; }

    [JsonPropertyName("dateFormat")]
    public string? DateFormat { get; set; }

    [JsonPropertyName("pathPattern")]
    public string? PathPattern { get; set; }

    [JsonPropertyName("storageAccounts")]
    public List<StorageAccountModel>? StorageAccounts { get; set; }

    [JsonPropertyName("timeFormat")]
    public string? TimeFormat { get; set; }
}
