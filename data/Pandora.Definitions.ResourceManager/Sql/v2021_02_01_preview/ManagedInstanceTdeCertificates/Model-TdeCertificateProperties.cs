using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Sql.v2021_02_01_preview.ManagedInstanceTdeCertificates;


internal class TdeCertificatePropertiesModel
{
    [JsonPropertyName("certPassword")]
    public string? CertPassword { get; set; }

    [JsonPropertyName("privateBlob")]
    [Required]
    public string PrivateBlob { get; set; }
}
