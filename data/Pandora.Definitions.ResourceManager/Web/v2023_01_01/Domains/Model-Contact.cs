using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Web.v2023_01_01.Domains;


internal class ContactModel
{
    [JsonPropertyName("addressMailing")]
    public AddressModel? AddressMailing { get; set; }

    [JsonPropertyName("email")]
    [Required]
    public string Email { get; set; }

    [JsonPropertyName("fax")]
    public string? Fax { get; set; }

    [JsonPropertyName("jobTitle")]
    public string? JobTitle { get; set; }

    [JsonPropertyName("nameFirst")]
    [Required]
    public string NameFirst { get; set; }

    [JsonPropertyName("nameLast")]
    [Required]
    public string NameLast { get; set; }

    [JsonPropertyName("nameMiddle")]
    public string? NameMiddle { get; set; }

    [JsonPropertyName("organization")]
    public string? Organization { get; set; }

    [JsonPropertyName("phone")]
    [Required]
    public string Phone { get; set; }
}
