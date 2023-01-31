using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DataBoxEdge.v2022_03_01.Users;


internal class UserPropertiesModel
{
    [JsonPropertyName("encryptedPassword")]
    public AsymmetricEncryptedSecretModel? EncryptedPassword { get; set; }

    [JsonPropertyName("shareAccessRights")]
    public List<ShareAccessRightModel>? ShareAccessRights { get; set; }

    [JsonPropertyName("userType")]
    [Required]
    public UserTypeConstant UserType { get; set; }
}
