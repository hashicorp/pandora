using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.AnalysisServices.v2017_08_01.Servers
{

    internal class AnalysisServicesServerProperties
    {
        [JsonPropertyName("asAdministrators")]
        public ServerAdministrators? AsAdministrators { get; set; }

        [JsonPropertyName("backupBlobContainerUri")]
        public string? BackupBlobContainerUri { get; set; }

        [JsonPropertyName("gatewayDetails")]
        public GatewayDetails? GatewayDetails { get; set; }

        [JsonPropertyName("ipV4FirewallSettings")]
        public IPv4FirewallSettings? IpV4FirewallSettings { get; set; }

        [JsonPropertyName("managedMode")]
        public ManagedMode? ManagedMode { get; set; }

        [JsonPropertyName("provisioningState")]
        public ProvisioningState? ProvisioningState { get; set; }

        [JsonPropertyName("querypoolConnectionMode")]
        public ConnectionMode? QuerypoolConnectionMode { get; set; }

        [JsonPropertyName("serverFullName")]
        public string? ServerFullName { get; set; }

        [JsonPropertyName("serverMonitorMode")]
        public ServerMonitorMode? ServerMonitorMode { get; set; }

        [JsonPropertyName("sku")]
        public ResourceSku? Sku { get; set; }

        [JsonPropertyName("state")]
        public State? State { get; set; }
    }
}
