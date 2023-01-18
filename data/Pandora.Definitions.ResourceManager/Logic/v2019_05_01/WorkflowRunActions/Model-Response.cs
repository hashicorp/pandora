using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Logic.v2019_05_01.WorkflowRunActions;


internal class ResponseModel
{
    [JsonPropertyName("bodyLink")]
    public ContentLinkModel? BodyLink { get; set; }

    [JsonPropertyName("headers")]
    public object? Headers { get; set; }

    [JsonPropertyName("statusCode")]
    public int? StatusCode { get; set; }
}
