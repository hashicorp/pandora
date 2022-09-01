using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.PostgreSqlHSC.v2020_10_05_privatepreview.Servers;


internal class ServerGroupServerPropertiesModel
{
    [JsonPropertyName("administratorLogin")]
    public string? AdministratorLogin { get; set; }

    [JsonPropertyName("availabilityZone")]
    public string? AvailabilityZone { get; set; }

    [JsonPropertyName("citusVersion")]
    public CitusVersionConstant? CitusVersion { get; set; }

    [JsonPropertyName("enableHa")]
    public bool? EnableHa { get; set; }

    [JsonPropertyName("enablePublicIp")]
    public bool? EnablePublicIP { get; set; }

    [JsonPropertyName("fullyQualifiedDomainName")]
    public string? FullyQualifiedDomainName { get; set; }

    [JsonPropertyName("haState")]
    public ServerHaStateConstant? HaState { get; set; }

    [JsonPropertyName("postgresqlVersion")]
    public PostgreSQLVersionConstant? PostgresqlVersion { get; set; }

    [JsonPropertyName("role")]
    public ServerRoleConstant? Role { get; set; }

    [JsonPropertyName("serverEdition")]
    public ServerEditionConstant? ServerEdition { get; set; }

    [JsonPropertyName("standbyAvailabilityZone")]
    public string? StandbyAvailabilityZone { get; set; }

    [JsonPropertyName("state")]
    public ServerStateConstant? State { get; set; }

    [JsonPropertyName("storageQuotaInMb")]
    public int? StorageQuotaInMb { get; set; }

    [JsonPropertyName("vCores")]
    public int? VCores { get; set; }
}
