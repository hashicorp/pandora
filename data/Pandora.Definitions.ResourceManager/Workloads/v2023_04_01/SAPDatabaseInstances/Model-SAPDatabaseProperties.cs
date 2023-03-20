using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Workloads.v2023_04_01.SAPDatabaseInstances;


internal class SAPDatabasePropertiesModel
{
    [JsonPropertyName("databaseSid")]
    public string? DatabaseSid { get; set; }

    [JsonPropertyName("databaseType")]
    public string? DatabaseType { get; set; }

    [JsonPropertyName("errors")]
    public SAPVirtualInstanceErrorModel? Errors { get; set; }

    [JsonPropertyName("ipAddress")]
    public string? IPAddress { get; set; }

    [JsonPropertyName("loadBalancerDetails")]
    public LoadBalancerDetailsModel? LoadBalancerDetails { get; set; }

    [JsonPropertyName("provisioningState")]
    public SapVirtualInstanceProvisioningStateConstant? ProvisioningState { get; set; }

    [JsonPropertyName("status")]
    public SAPVirtualInstanceStatusConstant? Status { get; set; }

    [JsonPropertyName("subnet")]
    public string? Subnet { get; set; }

    [JsonPropertyName("vmDetails")]
    public List<DatabaseVMDetailsModel>? VMDetails { get; set; }
}
