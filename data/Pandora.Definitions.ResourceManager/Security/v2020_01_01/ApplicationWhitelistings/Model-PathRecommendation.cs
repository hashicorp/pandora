using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Security.v2020_01_01.ApplicationWhitelistings;


internal class PathRecommendationModel
{
    [JsonPropertyName("action")]
    public ActionConstant? Action { get; set; }

    [JsonPropertyName("common")]
    public bool? Common { get; set; }

    [JsonPropertyName("configurationStatus")]
    public ConfigurationStatusConstant? ConfigurationStatus { get; set; }

    [JsonPropertyName("fileType")]
    public FileTypeConstant? FileType { get; set; }

    [JsonPropertyName("path")]
    public string? Path { get; set; }

    [JsonPropertyName("publisherInfo")]
    public PublisherInfoModel? PublisherInfo { get; set; }

    [JsonPropertyName("type")]
    public TypeConstant? Type { get; set; }

    [JsonPropertyName("userSids")]
    public List<string>? UserSids { get; set; }

    [JsonPropertyName("usernames")]
    public List<UserRecommendationModel>? Usernames { get; set; }
}
