using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Cognitive.v2022_12_01.CognitiveServicesAccounts;


internal class CommitmentPlanAssociationModel
{
    [JsonPropertyName("commitmentPlanId")]
    public string? CommitmentPlanId { get; set; }

    [JsonPropertyName("commitmentPlanLocation")]
    public string? CommitmentPlanLocation { get; set; }
}
