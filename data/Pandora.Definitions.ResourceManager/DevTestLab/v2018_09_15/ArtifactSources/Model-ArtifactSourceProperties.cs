using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DevTestLab.v2018_09_15.ArtifactSources;


internal class ArtifactSourcePropertiesModel
{
    [JsonPropertyName("armTemplateFolderPath")]
    public string? ArmTemplateFolderPath { get; set; }

    [JsonPropertyName("branchRef")]
    public string? BranchRef { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("createdDate")]
    public DateTime? CreatedDate { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("folderPath")]
    public string? FolderPath { get; set; }

    [JsonPropertyName("provisioningState")]
    public string? ProvisioningState { get; set; }

    [JsonPropertyName("securityToken")]
    public string? SecurityToken { get; set; }

    [JsonPropertyName("sourceType")]
    public SourceControlTypeConstant? SourceType { get; set; }

    [JsonPropertyName("status")]
    public EnableStatusConstant? Status { get; set; }

    [JsonPropertyName("uniqueIdentifier")]
    public string? UniqueIdentifier { get; set; }

    [JsonPropertyName("uri")]
    public string? Uri { get; set; }
}
