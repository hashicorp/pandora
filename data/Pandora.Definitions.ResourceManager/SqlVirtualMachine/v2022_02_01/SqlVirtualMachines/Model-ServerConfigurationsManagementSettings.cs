using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.SqlVirtualMachine.v2022_02_01.SqlVirtualMachines;


internal class ServerConfigurationsManagementSettingsModel
{
    [JsonPropertyName("additionalFeaturesServerConfigurations")]
    public AdditionalFeaturesServerConfigurationsModel? AdditionalFeaturesServerConfigurations { get; set; }

    [JsonPropertyName("sqlConnectivityUpdateSettings")]
    public SqlConnectivityUpdateSettingsModel? SqlConnectivityUpdateSettings { get; set; }

    [JsonPropertyName("sqlInstanceSettings")]
    public SQLInstanceSettingsModel? SqlInstanceSettings { get; set; }

    [JsonPropertyName("sqlStorageUpdateSettings")]
    public SqlStorageUpdateSettingsModel? SqlStorageUpdateSettings { get; set; }

    [JsonPropertyName("sqlWorkloadTypeUpdateSettings")]
    public SqlWorkloadTypeUpdateSettingsModel? SqlWorkloadTypeUpdateSettings { get; set; }
}
