using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ApiManagement.v2022_08_01.User;


internal class UserCreateParameterPropertiesModel
{
    [JsonPropertyName("appType")]
    public AppTypeConstant? AppType { get; set; }

    [JsonPropertyName("confirmation")]
    public ConfirmationConstant? Confirmation { get; set; }

    [JsonPropertyName("email")]
    [Required]
    public string Email { get; set; }

    [JsonPropertyName("firstName")]
    [Required]
    public string FirstName { get; set; }

    [JsonPropertyName("identities")]
    public List<UserIdentityContractModel>? Identities { get; set; }

    [JsonPropertyName("lastName")]
    [Required]
    public string LastName { get; set; }

    [JsonPropertyName("note")]
    public string? Note { get; set; }

    [JsonPropertyName("password")]
    public string? Password { get; set; }

    [JsonPropertyName("state")]
    public UserStateConstant? State { get; set; }
}
