// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class EducationSynchronizationProfileModel
{
    [JsonPropertyName("dataProvider")]
    public EducationSynchronizationDataProviderModel? DataProvider { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("errors")]
    public List<EducationSynchronizationErrorModel>? Errors { get; set; }

    [JsonPropertyName("expirationDate")]
    public DateTime? ExpirationDate { get; set; }

    [JsonPropertyName("handleSpecialCharacterConstraint")]
    public bool? HandleSpecialCharacterConstraint { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("identitySynchronizationConfiguration")]
    public EducationIdentitySynchronizationConfigurationModel? IdentitySynchronizationConfiguration { get; set; }

    [JsonPropertyName("licensesToAssign")]
    public List<EducationSynchronizationLicenseAssignmentModel>? LicensesToAssign { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("profileStatus")]
    public EducationSynchronizationProfileStatusModel? ProfileStatus { get; set; }

    [JsonPropertyName("state")]
    public EducationSynchronizationProfileStateConstant? State { get; set; }
}
