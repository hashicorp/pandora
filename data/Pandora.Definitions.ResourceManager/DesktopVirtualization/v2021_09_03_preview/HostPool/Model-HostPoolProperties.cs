using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DesktopVirtualization.v2021_09_03_preview.HostPool;


internal class HostPoolPropertiesModel
{
    [JsonPropertyName("applicationGroupReferences")]
    public List<string>? ApplicationGroupReferences { get; set; }

    [JsonPropertyName("cloudPcResource")]
    public bool? CloudPcResource { get; set; }

    [JsonPropertyName("customRdpProperty")]
    public string? CustomRdpProperty { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("friendlyName")]
    public string? FriendlyName { get; set; }

    [JsonPropertyName("hostPoolType")]
    [Required]
    public HostPoolTypeConstant HostPoolType { get; set; }

    [JsonPropertyName("loadBalancerType")]
    [Required]
    public LoadBalancerTypeConstant LoadBalancerType { get; set; }

    [JsonPropertyName("maxSessionLimit")]
    public int? MaxSessionLimit { get; set; }

    [JsonPropertyName("migrationRequest")]
    public MigrationRequestPropertiesModel? MigrationRequest { get; set; }

    [JsonPropertyName("objectId")]
    public string? ObjectId { get; set; }

    [JsonPropertyName("personalDesktopAssignmentType")]
    public PersonalDesktopAssignmentTypeConstant? PersonalDesktopAssignmentType { get; set; }

    [JsonPropertyName("preferredAppGroupType")]
    [Required]
    public PreferredAppGroupTypeConstant PreferredAppGroupType { get; set; }

    [JsonPropertyName("publicNetworkAccess")]
    public PublicNetworkAccessConstant? PublicNetworkAccess { get; set; }

    [JsonPropertyName("registrationInfo")]
    public RegistrationInfoModel? RegistrationInfo { get; set; }

    [JsonPropertyName("ring")]
    public int? Ring { get; set; }

    [JsonPropertyName("ssoClientId")]
    public string? SsoClientId { get; set; }

    [JsonPropertyName("ssoClientSecretKeyVaultPath")]
    public string? SsoClientSecretKeyVaultPath { get; set; }

    [JsonPropertyName("ssoSecretType")]
    public SSOSecretTypeConstant? SsoSecretType { get; set; }

    [JsonPropertyName("ssoadfsAuthority")]
    public string? SsoadfsAuthority { get; set; }

    [JsonPropertyName("startVMOnConnect")]
    public bool? StartVMOnConnect { get; set; }

    [JsonPropertyName("vmTemplate")]
    public string? VMTemplate { get; set; }

    [JsonPropertyName("validationEnvironment")]
    public bool? ValidationEnvironment { get; set; }
}
