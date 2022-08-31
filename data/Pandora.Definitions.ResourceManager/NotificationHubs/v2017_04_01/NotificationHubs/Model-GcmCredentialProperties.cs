using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.NotificationHubs.v2017_04_01.NotificationHubs;


internal class GcmCredentialPropertiesModel
{
    [JsonPropertyName("gcmEndpoint")]
    public string? GcmEndpoint { get; set; }

    [JsonPropertyName("googleApiKey")]
    public string? GoogleApiKey { get; set; }
}
