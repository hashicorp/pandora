using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2023_04_01_preview.Datastore;

[ValueForType("KerberosPassword")]
internal class KerberosPasswordCredentialsModel : DatastoreCredentialsModel
{
    [JsonPropertyName("kerberosKdcAddress")]
    [Required]
    public string KerberosKdcAddress { get; set; }

    [JsonPropertyName("kerberosPrincipal")]
    [Required]
    public string KerberosPrincipal { get; set; }

    [JsonPropertyName("kerberosRealm")]
    [Required]
    public string KerberosRealm { get; set; }

    [JsonPropertyName("secrets")]
    [Required]
    public DatastoreSecretsModel Secrets { get; set; }
}
