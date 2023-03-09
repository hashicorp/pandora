using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.PostgreSqlHSC.v2022_11_08.Servers;


internal class ClusterServerPropertiesModel
{
    [JsonPropertyName("administratorLogin")]
    public string? AdministratorLogin { get; set; }

    [JsonPropertyName("availabilityZone")]
    public CustomTypes.Zone? AvailabilityZone { get; set; }

    [JsonPropertyName("citusVersion")]
    public string? CitusVersion { get; set; }

    [JsonPropertyName("enableHa")]
    public bool? EnableHa { get; set; }

    [JsonPropertyName("enablePublicIpAccess")]
    public bool? EnablePublicIPAccess { get; set; }

    [JsonPropertyName("fullyQualifiedDomainName")]
    public string? FullyQualifiedDomainName { get; set; }

    [JsonPropertyName("haState")]
    public string? HaState { get; set; }

    [JsonPropertyName("isReadOnly")]
    public bool? IsReadOnly { get; set; }

    [JsonPropertyName("postgresqlVersion")]
    public string? PostgresqlVersion { get; set; }

    [JsonPropertyName("role")]
    public ServerRoleConstant? Role { get; set; }

    [JsonPropertyName("serverEdition")]
    public string? ServerEdition { get; set; }

    [JsonPropertyName("state")]
    public string? State { get; set; }

    [JsonPropertyName("storageQuotaInMb")]
    public int? StorageQuotaInMb { get; set; }

    [JsonPropertyName("vCores")]
    public int? VCores { get; set; }
}
