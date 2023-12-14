using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Web.v2023_01_01.WebApps;


internal class SiteConfigModel
{
    [JsonPropertyName("acrUseManagedIdentityCreds")]
    public bool? AcrUseManagedIdentityCreds { get; set; }

    [JsonPropertyName("acrUserManagedIdentityID")]
    public string? AcrUserManagedIdentityID { get; set; }

    [JsonPropertyName("alwaysOn")]
    public bool? AlwaysOn { get; set; }

    [JsonPropertyName("apiDefinition")]
    public ApiDefinitionInfoModel? ApiDefinition { get; set; }

    [JsonPropertyName("apiManagementConfig")]
    public ApiManagementConfigModel? ApiManagementConfig { get; set; }

    [JsonPropertyName("appCommandLine")]
    public string? AppCommandLine { get; set; }

    [JsonPropertyName("appSettings")]
    public List<NameValuePairModel>? AppSettings { get; set; }

    [JsonPropertyName("autoHealEnabled")]
    public bool? AutoHealEnabled { get; set; }

    [JsonPropertyName("autoHealRules")]
    public AutoHealRulesModel? AutoHealRules { get; set; }

    [JsonPropertyName("autoSwapSlotName")]
    public string? AutoSwapSlotName { get; set; }

    [JsonPropertyName("azureStorageAccounts")]
    public Dictionary<string, AzureStorageInfoValueModel>? AzureStorageAccounts { get; set; }

    [JsonPropertyName("connectionStrings")]
    public List<ConnStringInfoModel>? ConnectionStrings { get; set; }

    [JsonPropertyName("cors")]
    public CorsSettingsModel? Cors { get; set; }

    [JsonPropertyName("defaultDocuments")]
    public List<string>? DefaultDocuments { get; set; }

    [JsonPropertyName("detailedErrorLoggingEnabled")]
    public bool? DetailedErrorLoggingEnabled { get; set; }

    [JsonPropertyName("documentRoot")]
    public string? DocumentRoot { get; set; }

    [JsonPropertyName("elasticWebAppScaleLimit")]
    public int? ElasticWebAppScaleLimit { get; set; }

    [JsonPropertyName("experiments")]
    public ExperimentsModel? Experiments { get; set; }

    [JsonPropertyName("ftpsState")]
    public FtpsStateConstant? FtpsState { get; set; }

    [JsonPropertyName("functionAppScaleLimit")]
    public int? FunctionAppScaleLimit { get; set; }

    [JsonPropertyName("functionsRuntimeScaleMonitoringEnabled")]
    public bool? FunctionsRuntimeScaleMonitoringEnabled { get; set; }

    [JsonPropertyName("http20Enabled")]
    public bool? HTTP20Enabled { get; set; }

    [JsonPropertyName("httpLoggingEnabled")]
    public bool? HTTPLoggingEnabled { get; set; }

    [JsonPropertyName("handlerMappings")]
    public List<HandlerMappingModel>? HandlerMappings { get; set; }

    [JsonPropertyName("healthCheckPath")]
    public string? HealthCheckPath { get; set; }

    [JsonPropertyName("ipSecurityRestrictions")]
    public List<IPSecurityRestrictionModel>? IPSecurityRestrictions { get; set; }

    [JsonPropertyName("ipSecurityRestrictionsDefaultAction")]
    public DefaultActionConstant? IPSecurityRestrictionsDefaultAction { get; set; }

    [JsonPropertyName("javaContainer")]
    public string? JavaContainer { get; set; }

    [JsonPropertyName("javaContainerVersion")]
    public string? JavaContainerVersion { get; set; }

    [JsonPropertyName("javaVersion")]
    public string? JavaVersion { get; set; }

    [JsonPropertyName("keyVaultReferenceIdentity")]
    public string? KeyVaultReferenceIdentity { get; set; }

    [JsonPropertyName("limits")]
    public SiteLimitsModel? Limits { get; set; }

    [JsonPropertyName("linuxFxVersion")]
    public string? LinuxFxVersion { get; set; }

    [JsonPropertyName("loadBalancing")]
    public SiteLoadBalancingConstant? LoadBalancing { get; set; }

    [JsonPropertyName("localMySqlEnabled")]
    public bool? LocalMySqlEnabled { get; set; }

    [JsonPropertyName("logsDirectorySizeLimit")]
    public int? LogsDirectorySizeLimit { get; set; }

    [JsonPropertyName("machineKey")]
    public SiteMachineKeyModel? MachineKey { get; set; }

    [JsonPropertyName("managedPipelineMode")]
    public ManagedPipelineModeConstant? ManagedPipelineMode { get; set; }

    [JsonPropertyName("managedServiceIdentityId")]
    public int? ManagedServiceIdentityId { get; set; }

    [JsonPropertyName("metadata")]
    public List<NameValuePairModel>? Metadata { get; set; }

    [JsonPropertyName("minTlsCipherSuite")]
    public TlsCipherSuitesConstant? MinTlsCipherSuite { get; set; }

    [JsonPropertyName("minTlsVersion")]
    public SupportedTlsVersionsConstant? MinTlsVersion { get; set; }

    [JsonPropertyName("minimumElasticInstanceCount")]
    public int? MinimumElasticInstanceCount { get; set; }

    [JsonPropertyName("netFrameworkVersion")]
    public string? NetFrameworkVersion { get; set; }

    [JsonPropertyName("nodeVersion")]
    public string? NodeVersion { get; set; }

    [JsonPropertyName("numberOfWorkers")]
    public int? NumberOfWorkers { get; set; }

    [JsonPropertyName("phpVersion")]
    public string? PhpVersion { get; set; }

    [JsonPropertyName("powerShellVersion")]
    public string? PowerShellVersion { get; set; }

    [JsonPropertyName("preWarmedInstanceCount")]
    public int? PreWarmedInstanceCount { get; set; }

    [JsonPropertyName("publicNetworkAccess")]
    public string? PublicNetworkAccess { get; set; }

    [JsonPropertyName("publishingUsername")]
    public string? PublishingUsername { get; set; }

    [JsonPropertyName("push")]
    public PushSettingsModel? Push { get; set; }

    [JsonPropertyName("pythonVersion")]
    public string? PythonVersion { get; set; }

    [JsonPropertyName("remoteDebuggingEnabled")]
    public bool? RemoteDebuggingEnabled { get; set; }

    [JsonPropertyName("remoteDebuggingVersion")]
    public string? RemoteDebuggingVersion { get; set; }

    [JsonPropertyName("requestTracingEnabled")]
    public bool? RequestTracingEnabled { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("requestTracingExpirationTime")]
    public DateTime? RequestTracingExpirationTime { get; set; }

    [JsonPropertyName("scmIpSecurityRestrictions")]
    public List<IPSecurityRestrictionModel>? ScmIPSecurityRestrictions { get; set; }

    [JsonPropertyName("scmIpSecurityRestrictionsDefaultAction")]
    public DefaultActionConstant? ScmIPSecurityRestrictionsDefaultAction { get; set; }

    [JsonPropertyName("scmIpSecurityRestrictionsUseMain")]
    public bool? ScmIPSecurityRestrictionsUseMain { get; set; }

    [JsonPropertyName("scmMinTlsVersion")]
    public SupportedTlsVersionsConstant? ScmMinTlsVersion { get; set; }

    [JsonPropertyName("scmType")]
    public ScmTypeConstant? ScmType { get; set; }

    [JsonPropertyName("tracingOptions")]
    public string? TracingOptions { get; set; }

    [JsonPropertyName("use32BitWorkerProcess")]
    public bool? Use32BitWorkerProcess { get; set; }

    [JsonPropertyName("virtualApplications")]
    public List<VirtualApplicationModel>? VirtualApplications { get; set; }

    [JsonPropertyName("vnetName")]
    public string? VnetName { get; set; }

    [JsonPropertyName("vnetPrivatePortsCount")]
    public int? VnetPrivatePortsCount { get; set; }

    [JsonPropertyName("vnetRouteAllEnabled")]
    public bool? VnetRouteAllEnabled { get; set; }

    [JsonPropertyName("webSocketsEnabled")]
    public bool? WebSocketsEnabled { get; set; }

    [JsonPropertyName("websiteTimeZone")]
    public string? WebsiteTimeZone { get; set; }

    [JsonPropertyName("windowsFxVersion")]
    public string? WindowsFxVersion { get; set; }

    [JsonPropertyName("xManagedServiceIdentityId")]
    public int? XManagedServiceIdentityId { get; set; }
}
