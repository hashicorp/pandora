using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.StreamAnalytics.v2020_03_01.StreamingJobs;


internal class OutputPropertiesModel
{
    [JsonPropertyName("datasource")]
    public OutputDataSourceModel? Datasource { get; set; }

    [JsonPropertyName("diagnostics")]
    public DiagnosticsModel? Diagnostics { get; set; }

    [JsonPropertyName("etag")]
    public string? Etag { get; set; }

    [JsonPropertyName("serialization")]
    public SerializationModel? Serialization { get; set; }

    [JsonPropertyName("sizeWindow")]
    public int? SizeWindow { get; set; }

    [JsonPropertyName("timeWindow")]
    public string? TimeWindow { get; set; }
}
