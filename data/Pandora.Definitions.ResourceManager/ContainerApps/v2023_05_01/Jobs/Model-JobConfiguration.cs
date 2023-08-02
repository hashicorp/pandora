using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ContainerApps.v2023_05_01.Jobs;


internal class JobConfigurationModel
{
    [JsonPropertyName("eventTriggerConfig")]
    public JobConfigurationEventTriggerConfigModel? EventTriggerConfig { get; set; }

    [JsonPropertyName("manualTriggerConfig")]
    public JobConfigurationManualTriggerConfigModel? ManualTriggerConfig { get; set; }

    [JsonPropertyName("registries")]
    public List<RegistryCredentialsModel>? Registries { get; set; }

    [JsonPropertyName("replicaRetryLimit")]
    public int? ReplicaRetryLimit { get; set; }

    [JsonPropertyName("replicaTimeout")]
    [Required]
    public int ReplicaTimeout { get; set; }

    [JsonPropertyName("scheduleTriggerConfig")]
    public JobConfigurationScheduleTriggerConfigModel? ScheduleTriggerConfig { get; set; }

    [JsonPropertyName("secrets")]
    public List<SecretModel>? Secrets { get; set; }

    [JsonPropertyName("triggerType")]
    [Required]
    public TriggerTypeConstant TriggerType { get; set; }
}
