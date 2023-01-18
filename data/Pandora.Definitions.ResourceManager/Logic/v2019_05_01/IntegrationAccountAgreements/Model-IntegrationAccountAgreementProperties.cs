using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Logic.v2019_05_01.IntegrationAccountAgreements;


internal class IntegrationAccountAgreementPropertiesModel
{
    [JsonPropertyName("agreementType")]
    [Required]
    public AgreementTypeConstant AgreementType { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("changedTime")]
    public DateTime? ChangedTime { get; set; }

    [JsonPropertyName("content")]
    [Required]
    public AgreementContentModel Content { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("createdTime")]
    public DateTime? CreatedTime { get; set; }

    [JsonPropertyName("guestIdentity")]
    [Required]
    public BusinessIdentityModel GuestIdentity { get; set; }

    [JsonPropertyName("guestPartner")]
    [Required]
    public string GuestPartner { get; set; }

    [JsonPropertyName("hostIdentity")]
    [Required]
    public BusinessIdentityModel HostIdentity { get; set; }

    [JsonPropertyName("hostPartner")]
    [Required]
    public string HostPartner { get; set; }

    [JsonPropertyName("metadata")]
    public object? Metadata { get; set; }
}
