using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Sql.v2021_11_01.ServerTrustGroups;


internal class ServerTrustGroupPropertiesModel
{
    [JsonPropertyName("groupMembers")]
    [Required]
    public List<ServerInfoModel> GroupMembers { get; set; }

    [JsonPropertyName("trustScopes")]
    [Required]
    public List<TrustScopesConstant> TrustScopes { get; set; }
}
