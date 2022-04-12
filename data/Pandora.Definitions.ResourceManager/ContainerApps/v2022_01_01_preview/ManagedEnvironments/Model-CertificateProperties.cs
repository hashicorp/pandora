using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.ContainerApps.v2022_01_01_preview.ManagedEnvironments;


internal class CertificatePropertiesModel
{
    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("expirationDate")]
    public DateTime? ExpirationDate { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("issueDate")]
    public DateTime? IssueDate { get; set; }

    [JsonPropertyName("issuer")]
    public string? Issuer { get; set; }

    [JsonPropertyName("password")]
    public string? Password { get; set; }

    [JsonPropertyName("provisioningState")]
    public CertificateProvisioningStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("publicKeyHash")]
    public string? PublicKeyHash { get; set; }

    [JsonPropertyName("subjectName")]
    public string? SubjectName { get; set; }

    [JsonPropertyName("thumbprint")]
    public string? Thumbprint { get; set; }

    [JsonPropertyName("valid")]
    public bool? Valid { get; set; }

    [JsonPropertyName("value")]
    public string? Value { get; set; }
}
