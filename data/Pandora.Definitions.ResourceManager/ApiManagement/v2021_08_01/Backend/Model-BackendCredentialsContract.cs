using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ApiManagement.v2021_08_01.Backend;


internal class BackendCredentialsContractModel
{
    [JsonPropertyName("authorization")]
    public BackendAuthorizationHeaderCredentialsModel? Authorization { get; set; }

    [MaxItems(32)]
    [JsonPropertyName("certificate")]
    public List<string>? Certificate { get; set; }

    [MaxItems(32)]
    [JsonPropertyName("certificateIds")]
    public List<string>? CertificateIds { get; set; }

    [JsonPropertyName("header")]
    public Dictionary<string, List<string>>? Header { get; set; }

    [JsonPropertyName("query")]
    public Dictionary<string, List<string>>? Query { get; set; }
}
