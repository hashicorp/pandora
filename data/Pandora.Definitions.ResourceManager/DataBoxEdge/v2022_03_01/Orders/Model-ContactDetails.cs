using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DataBoxEdge.v2022_03_01.Orders;


internal class ContactDetailsModel
{
    [JsonPropertyName("companyName")]
    [Required]
    public string CompanyName { get; set; }

    [JsonPropertyName("contactPerson")]
    [Required]
    public string ContactPerson { get; set; }

    [JsonPropertyName("emailList")]
    [Required]
    public List<string> EmailList { get; set; }

    [JsonPropertyName("phone")]
    [Required]
    public string Phone { get; set; }
}
