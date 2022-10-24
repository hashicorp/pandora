using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.SecurityInsights.v2022_07_01_preview.SourceControls;


internal class RepositoryResourceInfoModel
{
    [JsonPropertyName("azureDevOpsResourceInfo")]
    public AzureDevOpsResourceInfoModel? AzureDevOpsResourceInfo { get; set; }

    [JsonPropertyName("gitHubResourceInfo")]
    public GitHubResourceInfoModel? GitHubResourceInfo { get; set; }

    [JsonPropertyName("webhook")]
    public WebhookModel? Webhook { get; set; }
}
