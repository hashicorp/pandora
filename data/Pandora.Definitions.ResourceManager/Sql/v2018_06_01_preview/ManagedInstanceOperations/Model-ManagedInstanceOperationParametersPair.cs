using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Sql.v2018_06_01_preview.ManagedInstanceOperations;


internal class ManagedInstanceOperationParametersPairModel
{
    [JsonPropertyName("currentParameters")]
    public UpsertManagedServerOperationParametersModel? CurrentParameters { get; set; }

    [JsonPropertyName("requestedParameters")]
    public UpsertManagedServerOperationParametersModel? RequestedParameters { get; set; }
}
