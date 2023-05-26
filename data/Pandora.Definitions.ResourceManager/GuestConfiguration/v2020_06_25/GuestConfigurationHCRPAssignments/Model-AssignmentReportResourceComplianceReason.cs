using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.GuestConfiguration.v2020_06_25.GuestConfigurationHCRPAssignments;


internal class AssignmentReportResourceComplianceReasonModel
{
    [JsonPropertyName("code")]
    public string? Code { get; set; }

    [JsonPropertyName("phrase")]
    public string? Phrase { get; set; }
}
