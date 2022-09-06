using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ApplicationInsights.v2020_11_20.WorkbookTemplatesAPIS;


internal class WorkbookTemplateLocalizedGalleryModel
{
    [JsonPropertyName("galleries")]
    public List<WorkbookTemplateGalleryModel>? Galleries { get; set; }

    [JsonPropertyName("templateData")]
    public object? TemplateData { get; set; }
}
