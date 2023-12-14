// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Users.StableV1.UserChatInstalledApp;

internal class CreateUserByIdChatByIdInstalledAppByIdUpgradeRequestModel
{
    [JsonPropertyName("consentedPermissionSet")]
    public TeamsAppPermissionSetModel? ConsentedPermissionSet { get; set; }
}
