using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DesktopVirtualization.v2022_02_10_preview.Application;


internal class ApplicationPropertiesModel
{
    [JsonPropertyName("applicationType")]
    public RemoteApplicationTypeConstant? ApplicationType { get; set; }

    [JsonPropertyName("commandLineArguments")]
    public string? CommandLineArguments { get; set; }

    [JsonPropertyName("commandLineSetting")]
    [Required]
    public CommandLineSettingConstant CommandLineSetting { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("filePath")]
    public string? FilePath { get; set; }

    [JsonPropertyName("friendlyName")]
    public string? FriendlyName { get; set; }

    [JsonPropertyName("iconContent")]
    public string? IconContent { get; set; }

    [JsonPropertyName("iconHash")]
    public string? IconHash { get; set; }

    [JsonPropertyName("iconIndex")]
    public int? IconIndex { get; set; }

    [JsonPropertyName("iconPath")]
    public string? IconPath { get; set; }

    [JsonPropertyName("msixPackageApplicationId")]
    public string? MsixPackageApplicationId { get; set; }

    [JsonPropertyName("msixPackageFamilyName")]
    public string? MsixPackageFamilyName { get; set; }

    [JsonPropertyName("objectId")]
    public string? ObjectId { get; set; }

    [JsonPropertyName("showInPortal")]
    public bool? ShowInPortal { get; set; }
}
