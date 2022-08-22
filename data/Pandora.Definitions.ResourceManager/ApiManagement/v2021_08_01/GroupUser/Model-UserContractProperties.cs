using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ApiManagement.v2021_08_01.GroupUser;


internal class UserContractPropertiesModel
{
    [JsonPropertyName("email")]
    public string? Email { get; set; }

    [JsonPropertyName("firstName")]
    public string? FirstName { get; set; }

    [JsonPropertyName("groups")]
    public List<GroupContractPropertiesModel>? Groups { get; set; }

    [JsonPropertyName("identities")]
    public List<UserIdentityContractModel>? Identities { get; set; }

    [JsonPropertyName("lastName")]
    public string? LastName { get; set; }

    [JsonPropertyName("note")]
    public string? Note { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("registrationDate")]
    public DateTime? RegistrationDate { get; set; }

    [JsonPropertyName("state")]
    public UserStateConstant? State { get; set; }
}
