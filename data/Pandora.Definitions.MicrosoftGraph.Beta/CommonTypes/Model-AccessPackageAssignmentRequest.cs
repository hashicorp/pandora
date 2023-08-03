// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class AccessPackageAssignmentRequestModel
{
    [JsonPropertyName("accessPackage")]
    public AccessPackageModel? AccessPackage { get; set; }

    [JsonPropertyName("accessPackageAssignment")]
    public AccessPackageAssignmentModel? AccessPackageAssignment { get; set; }

    [JsonPropertyName("answers")]
    public List<AccessPackageAnswerModel>? Answers { get; set; }

    [JsonPropertyName("completedDate")]
    public DateTime? CompletedDate { get; set; }

    [JsonPropertyName("createdDateTime")]
    public DateTime? CreatedDateTime { get; set; }

    [JsonPropertyName("customExtensionCalloutInstances")]
    public List<CustomExtensionCalloutInstanceModel>? CustomExtensionCalloutInstances { get; set; }

    [JsonPropertyName("customExtensionHandlerInstances")]
    public List<CustomExtensionHandlerInstanceModel>? CustomExtensionHandlerInstances { get; set; }

    [JsonPropertyName("expirationDateTime")]
    public DateTime? ExpirationDateTime { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("isValidationOnly")]
    public bool? IsValidationOnly { get; set; }

    [JsonPropertyName("justification")]
    public string? Justification { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("requestState")]
    public string? RequestState { get; set; }

    [JsonPropertyName("requestStatus")]
    public string? RequestStatus { get; set; }

    [JsonPropertyName("requestType")]
    public string? RequestType { get; set; }

    [JsonPropertyName("requestor")]
    public AccessPackageSubjectModel? Requestor { get; set; }

    [JsonPropertyName("schedule")]
    public RequestScheduleModel? Schedule { get; set; }

    [JsonPropertyName("verifiedCredentialsData")]
    public List<VerifiedCredentialDataModel>? VerifiedCredentialsData { get; set; }
}
