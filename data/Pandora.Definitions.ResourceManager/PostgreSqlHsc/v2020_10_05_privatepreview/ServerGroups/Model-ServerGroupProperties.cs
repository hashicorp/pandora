using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.PostgreSqlHsc.v2020_10_05_privatepreview.ServerGroups
{

    internal class ServerGroupPropertiesModel
    {
        [JsonPropertyName("administratorLogin")]
        public string? AdministratorLogin { get; set; }

        [JsonPropertyName("administratorLoginPassword")]
        public string? AdministratorLoginPassword { get; set; }

        [JsonPropertyName("availabilityZone")]
        public string? AvailabilityZone { get; set; }

        [JsonPropertyName("backupRetentionDays")]
        public int? BackupRetentionDays { get; set; }

        [JsonPropertyName("citusVersion")]
        public CitusVersionConstant? CitusVersion { get; set; }

        [JsonPropertyName("createMode")]
        public CreateModeConstant? CreateMode { get; set; }

        [JsonPropertyName("delegatedSubnetArguments")]
        public ServerGroupPropertiesDelegatedSubnetArgumentsModel? DelegatedSubnetArguments { get; set; }

        [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
        [JsonPropertyName("earliestRestoreTime")]
        public DateTime? EarliestRestoreTime { get; set; }

        [JsonPropertyName("enableMx")]
        public bool? EnableMx { get; set; }

        [JsonPropertyName("enableShardsOnCoordinator")]
        public bool? EnableShardsOnCoordinator { get; set; }

        [JsonPropertyName("enableZfs")]
        public bool? EnableZfs { get; set; }

        [JsonPropertyName("maintenanceWindow")]
        public MaintenanceWindowModel? MaintenanceWindow { get; set; }

        [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
        [JsonPropertyName("pointInTimeUTC")]
        public DateTime? PointInTimeUTC { get; set; }

        [JsonPropertyName("postgresqlVersion")]
        public PostgreSQLVersionConstant? PostgresqlVersion { get; set; }

        [JsonPropertyName("privateDnsZoneArguments")]
        public ServerGroupPropertiesPrivateDnsZoneArgumentsModel? PrivateDnsZoneArguments { get; set; }

        [JsonPropertyName("readReplicas")]
        public List<string>? ReadReplicas { get; set; }

        [JsonPropertyName("resourceProviderType")]
        public ResourceProviderTypeConstant? ResourceProviderType { get; set; }

        [MinItems(1)]
        [MaxItems(2)]
        [JsonPropertyName("serverRoleGroups")]
        public List<ServerRoleGroupModel>? ServerRoleGroups { get; set; }

        [JsonPropertyName("sourceLocation")]
        public string? SourceLocation { get; set; }

        [JsonPropertyName("sourceResourceGroupName")]
        public string? SourceResourceGroupName { get; set; }

        [JsonPropertyName("sourceServerGroup")]
        public string? SourceServerGroup { get; set; }

        [JsonPropertyName("sourceServerGroupName")]
        public string? SourceServerGroupName { get; set; }

        [JsonPropertyName("sourceSubscriptionId")]
        public string? SourceSubscriptionId { get; set; }

        [JsonPropertyName("standbyAvailabilityZone")]
        public string? StandbyAvailabilityZone { get; set; }

        [JsonPropertyName("state")]
        public ServerStateConstant? State { get; set; }
    }
}
