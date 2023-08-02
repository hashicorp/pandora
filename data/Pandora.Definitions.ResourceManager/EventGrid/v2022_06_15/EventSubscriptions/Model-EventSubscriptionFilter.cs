using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.EventGrid.v2022_06_15.EventSubscriptions;


internal class EventSubscriptionFilterModel
{
    [JsonPropertyName("advancedFilters")]
    public List<AdvancedFilterModel>? AdvancedFilters { get; set; }

    [JsonPropertyName("enableAdvancedFilteringOnArrays")]
    public bool? EnableAdvancedFilteringOnArrays { get; set; }

    [JsonPropertyName("includedEventTypes")]
    public List<string>? IncludedEventTypes { get; set; }

    [JsonPropertyName("isSubjectCaseSensitive")]
    public bool? IsSubjectCaseSensitive { get; set; }

    [JsonPropertyName("subjectBeginsWith")]
    public string? SubjectBeginsWith { get; set; }

    [JsonPropertyName("subjectEndsWith")]
    public string? SubjectEndsWith { get; set; }
}
