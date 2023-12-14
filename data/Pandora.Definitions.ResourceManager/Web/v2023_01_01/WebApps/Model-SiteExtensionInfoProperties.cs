using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Web.v2023_01_01.WebApps;


internal class SiteExtensionInfoPropertiesModel
{
    [JsonPropertyName("authors")]
    public List<string>? Authors { get; set; }

    [JsonPropertyName("comment")]
    public string? Comment { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("download_count")]
    public int? DownloadCount { get; set; }

    [JsonPropertyName("extension_id")]
    public string? ExtensionId { get; set; }

    [JsonPropertyName("extension_type")]
    public SiteExtensionTypeConstant? ExtensionType { get; set; }

    [JsonPropertyName("extension_url")]
    public string? ExtensionUrl { get; set; }

    [JsonPropertyName("feed_url")]
    public string? FeedUrl { get; set; }

    [JsonPropertyName("icon_url")]
    public string? IconUrl { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("installed_date_time")]
    public DateTime? InstalledDateTime { get; set; }

    [JsonPropertyName("installer_command_line_params")]
    public string? InstallerCommandLineParams { get; set; }

    [JsonPropertyName("license_url")]
    public string? LicenseUrl { get; set; }

    [JsonPropertyName("local_is_latest_version")]
    public bool? LocalIsLatestVersion { get; set; }

    [JsonPropertyName("local_path")]
    public string? LocalPath { get; set; }

    [JsonPropertyName("project_url")]
    public string? ProjectUrl { get; set; }

    [JsonPropertyName("provisioningState")]
    public string? ProvisioningState { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("published_date_time")]
    public DateTime? PublishedDateTime { get; set; }

    [JsonPropertyName("summary")]
    public string? Summary { get; set; }

    [JsonPropertyName("title")]
    public string? Title { get; set; }

    [JsonPropertyName("version")]
    public string? Version { get; set; }
}
