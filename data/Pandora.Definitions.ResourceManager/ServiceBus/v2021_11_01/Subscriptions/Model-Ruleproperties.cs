using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ServiceBus.v2021_11_01.Subscriptions;


internal class RulepropertiesModel
{
    [JsonPropertyName("action")]
    public ActionModel? Action { get; set; }

    [JsonPropertyName("correlationFilter")]
    public CorrelationFilterModel? CorrelationFilter { get; set; }

    [JsonPropertyName("filterType")]
    public FilterTypeConstant? FilterType { get; set; }

    [JsonPropertyName("sqlFilter")]
    public SqlFilterModel? SqlFilter { get; set; }
}
