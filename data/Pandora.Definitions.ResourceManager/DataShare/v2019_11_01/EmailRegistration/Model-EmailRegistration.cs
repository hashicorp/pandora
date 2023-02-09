using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DataShare.v2019_11_01.EmailRegistration;


internal class EmailRegistrationModel
{
    [JsonPropertyName("activationCode")]
    public string? ActivationCode { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("activationExpirationDate")]
    public DateTime? ActivationExpirationDate { get; set; }

    [JsonPropertyName("email")]
    public string? Email { get; set; }

    [JsonPropertyName("registrationStatus")]
    public RegistrationStatusConstant? RegistrationStatus { get; set; }

    [JsonPropertyName("tenantId")]
    public string? TenantId { get; set; }
}
