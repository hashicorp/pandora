using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DesktopVirtualization.v2022_02_10_preview.MSIXPackage;


internal class MSIXPackagePropertiesModel
{
    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("imagePath")]
    public string? ImagePath { get; set; }

    [JsonPropertyName("isActive")]
    public bool? IsActive { get; set; }

    [JsonPropertyName("isRegularRegistration")]
    public bool? IsRegularRegistration { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("lastUpdated")]
    public DateTime? LastUpdated { get; set; }

    [JsonPropertyName("packageApplications")]
    public List<MsixPackageApplicationsModel>? PackageApplications { get; set; }

    [JsonPropertyName("packageDependencies")]
    public List<MsixPackageDependenciesModel>? PackageDependencies { get; set; }

    [JsonPropertyName("packageFamilyName")]
    public string? PackageFamilyName { get; set; }

    [JsonPropertyName("packageName")]
    public string? PackageName { get; set; }

    [JsonPropertyName("packageRelativePath")]
    public string? PackageRelativePath { get; set; }

    [JsonPropertyName("version")]
    public string? Version { get; set; }
}
