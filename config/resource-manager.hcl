# Copyright (c) HashiCorp, Inc.
# SPDX-License-Identifier: MPL-2.0

service "advisor" {
  name      = "Advisor"
  available = ["2023-01-01", "2025-01-01"]
  ignore    = ["2022-09-01"]
}
service "alertsmanagement" {
  name      = "AlertsManagement"
  available = ["2019-06-01", "2021-08-08", "2023-03-01"]
}
service "analysisservices" {
  name      = "AnalysisServices"
  available = ["2017-08-01"]
}
service "apicenter" {
  name      = "ApiCenter"
  available = ["2024-03-01", "2024-03-15-preview"]
}
service "apimanagement" {
  name      = "ApiManagement"
  available = ["2022-08-01", "2024-05-01"]
}
service "app" {
  name      = "ContainerApps"
  available = ["2023-05-01", "2025-01-01"]
}
service "appconfiguration" {
  name      = "AppConfiguration"
  available = ["2024-05-01", "2024-06-01"]
}
service "applicationinsights" {
  name      = "ApplicationInsights"
  available = ["2015-05-01", "2020-02-02", "2020-11-20", "2022-04-01", "2022-06-15", "2023-06-01"]
}
service "appplatform" {
  name      = "AppPlatform"
  available = ["2024-01-01-preview", "2024-05-01-preview"]
}
service "attestation" {
  name      = "Attestation"
  available = ["2020-10-01", "2021-06-01"]
}
service "authorization" {
  name      = "Authorization"
  available = ["2020-10-01", "2022-04-01", "2022-05-01-preview"]
}
service "automanage" {
  name      = "AutoManage"
  available = ["2022-05-04"]
}
service "automation" {
  name      = "Automation"
  available = ["2015-10-31", "2019-06-01", "2020-01-13-preview", "2022-08-08", "2023-11-01"]
  ignore    = ["2024-10-23"]
}
service "azure-kusto" {
  name      = "Kusto"
  available = ["2024-04-13"]
}
service "azureactivedirectory" {
  name      = "AzureActiveDirectory"
  available = ["2017-04-01", "2020-03-01"]
}
service "azurefleet" {
  name      = "AzureFleet"
  available = ["2024-11-01"]
}
service "azurestackhci" {
  name      = "AzureStackHCI"
  available = ["2024-01-01"]
}
service "batch" {
  name      = "Batch"
  available = ["2024-07-01"]
}
service "billing" {
  name      = "Billing"
  available = ["2024-04-01"]
}
service "blueprint" {
  name      = "Blueprints"
  available = ["2018-11-01-preview"]
}
service "botservice" {
  name      = "BotService"
  available = ["2022-09-15"]
}
service "cdn" {
  name      = "CDN"
  available = ["2024-02-01", "2024-09-01", "2025-04-15", "2025-06-01"]
}
service "chaos" {
  name      = "ChaosStudio"
  available = ["2023-11-01", "2025-01-01"]
}
service "codesigning" {
  name      = "CodeSigning"
  available = ["2024-09-30-preview"]
}
service "cognitiveservices" {
  name      = "Cognitive"
  available = ["2024-10-01", "2025-06-01"]
}
service "communication" {
  name      = "Communication"
  available = ["2023-03-31", "2023-04-01", "2025-05-01"]
}
service "compute" {
  name      = "Compute"
  available = ["2021-07-01", "2022-03-01", "2022-03-02", "2022-03-03", "2023-03-01", "2023-04-02", "2023-07-03", "2024-03-01", "2024-11-01"]
}
service "confidentialledger" {
  name      = "ConfidentialLedger"
  available = ["2022-05-13"]
}
service "connectedvmware" {
  name      = "ConnectedVmware"
  available = ["2023-12-01"]
}
service "consumption" {
  name      = "Consumption"
  available = ["2019-10-01", "2024-08-01"]
  ignore    = ["2023-03-01"]
}
service "containerinstance" {
  name      = "ContainerInstance"
  available = ["2023-05-01"]
}
service "containerregistry" {
  name      = "ContainerRegistry"
  available = ["2019-06-01-preview", "2023-07-01", "2023-11-01-preview", "2025-04-01"]
}
service "containerservice" {
  name      = "ContainerService"
  available = ["2019-08-01", "2024-04-01", "2025-02-01", "2025-05-01"]
}
service "cosmos-db" {
  name      = "CosmosDB"
  available = ["2022-05-15", "2022-11-15", "2023-04-15", "2024-08-15", "2025-04-15"]
}
service "cost-management" {
  name      = "CostManagement"
  available = ["2023-08-01", "2025-03-01"]
}
service "customproviders" {
  name      = "CustomProviders"
  available = ["2018-09-01-preview"]
}
service "dashboard" {
  name      = "Dashboard"
  available = ["2023-09-01", "2024-10-01"]
}
service "databoxedge" {
  name      = "DataBoxEdge"
  available = ["2022-03-01", "2023-12-01"]
}
service "databricks" {
  name      = "Databricks"
  available = ["2022-04-01-preview", "2022-10-01-preview", "2024-05-01"]
}
service "datadog" {
  name      = "DataDog"
  available = ["2021-03-01", "2023-10-20"]
}
service "datafactory" {
  name      = "DataFactory"
  available = ["2018-06-01"]
}
service "datalake-analytics" {
  name      = "DataLakeAnalytics"
  available = ["2016-11-01"]
}
service "datalake-store" {
  name      = "DataLakeStore"
  available = ["2016-11-01"]
}
service "datamigration" {
  name      = "DataMigration"
  available = ["2021-06-30", "2025-06-30"]
}
service "dataprotection" {
  name      = "DataProtection"
  available = ["2024-04-01", "2025-07-01"]
}
service "datashare" {
  name      = "DataShare"
  available = ["2019-11-01", "2021-08-01"]
}
service "desktopvirtualization" {
  name      = "DesktopVirtualization"
  available = ["2024-04-03"]
  ignore    = ["2023-09-05"]
}
service "devcenter" {
  name      = "DevCenter"
  available = ["2025-02-01"]
}
service "deviceprovisioningservices" {
  name      = "DeviceProvisioningServices"
  available = ["2022-02-05", "2022-12-12"]
}
service "deviceregistry" {
  name      = "DeviceRegistry"
  available = ["2024-09-01-preview", "2024-11-01"]
}
service "deviceupdate" {
  name      = "DeviceUpdate"
  available = ["2022-10-01", "2023-07-01"]
}
service "devopsinfrastructure" {
  name      = "DevOpsInfrastructure"
  available = ["2025-01-21"]
}
service "devtestlabs" {
  name      = "DevTestLab"
  available = ["2018-09-15"]
}
service "digitaltwins" {
  name      = "DigitalTwins"
  available = ["2023-01-31"]
}
service "dns" {
  name      = "DNS"
  available = ["2018-05-01"]
}
service "dnsresolver" {
  name      = "DNSResolver"
  available = ["2022-07-01", "2025-05-01"]
}
service "domainservices" {
  name      = "AAD"
  available = ["2021-05-01", "2025-06-01"]
  ignore    = ["2022-09-01", "2022-12-01"]
}
service "dynatrace" {
  name      = "Dynatrace"
  available = ["2023-04-27", "2024-04-24"]
}
service "elastic" {
  name      = "Elastic"
  available = ["2023-06-01", "2024-03-01", "2025-06-01"]
}
service "elasticsan" {
  name      = "ElasticSan"
  available = ["2023-01-01", "2024-05-01"]
}
service "eventgrid" {
  name      = "EventGrid"
  available = ["2022-06-15", "2023-12-15-preview", "2025-02-15"]
}
service "eventhub" {
  name      = "EventHub"
  available = ["2021-11-01", "2022-01-01-preview", "2024-01-01"]
}
service "extendedlocation" {
  name      = "ExtendedLocation"
  available = ["2021-08-15"]
}
service "fabric" {
  name      = "Fabric"
  available = ["2023-11-01"]
}
service "fluidrelay" {
  name      = "FluidRelay"
  available = ["2022-05-26", "2022-06-01"]
}
service "frontdoor" {
  name      = "FrontDoor"
  available = ["2020-04-01", "2020-05-01", "2024-02-01", "2025-03-01"]
}
service "graphservicesprod" {
  name      = "GraphServices"
  available = ["2023-04-13"]
}
service "guestconfiguration" {
  name      = "GuestConfiguration"
  available = ["2020-06-25", "2024-04-05"]
}
service "hardwaresecuritymodules" {
  name      = "HardwareSecurityModules"
  available = ["2021-11-30", "2025-03-31"]
}
service "hdinsight" {
  name      = "HDInsight"
  available = ["2021-06-01"]
}
service "healthbot" {
  name      = "HealthBot"
  available = ["2022-08-08", "2023-05-01", "2024-02-01", "2025-05-25"]
}
service "healthcareapis" {
  name      = "HealthcareApis"
  available = ["2022-12-01", "2024-03-31"]
}
service "hybridaks" {
  name      = "HybridAzureKubernetesService"
  available = ["2024-01-01"]
}
service "hybridcompute" {
  name      = "HybridCompute"
  available = ["2022-11-10", "2024-07-10", "2025-01-13"]
}
service "hybridkubernetes" {
  name      = "HybridKubernetes"
  available = ["2021-10-01", "2024-01-01"]
}
service "informatica" {
  name      = "Informatica"
  available = ["2024-05-08"]
}
service "iotcentral" {
  name      = "IoTCentral"
  available = ["2021-11-01-preview"]
}
service "keyvault" {
  name      = "KeyVault"
  available = ["2023-02-01", "2023-07-01", "2024-11-01"]
}
service "kubernetesconfiguration" {
  name      = "KubernetesConfiguration"
  available = ["2022-11-01", "2023-05-01", "2024-11-01"]
}
service "labservices" {
  name      = "LabServices"
  available = ["2023-06-07"]
}
service "liftrastronomer" {
  name      = "Astronomer"
  available = ["2024-08-27"]
}
service "liftrqumulo" {
  name      = "QumuloStorage"
  available = ["2024-06-19"]
}
service "loadtestservice" {
  name      = "LoadTestService"
  available = ["2022-12-01"]
}
service "logic" {
  name      = "Logic"
  available = ["2019-05-01"]
}
service "machinelearningservices" {
  name      = "MachineLearningServices"
  available = ["2024-04-01", "2025-06-01"]
}
service "maintenance" {
  name      = "Maintenance"
  available = ["2023-04-01"]
}
service "managedservices" {
  name      = "ManagedServices"
  available = ["2022-10-01"]
}
service "managementgroups" {
  name      = "ManagementGroups"
  available = ["2020-05-01", "2023-04-01"]
}
service "maps" {
  name      = "Maps"
  available = ["2023-06-01"]
}
service "mariadb" {
  name      = "MariaDB"
  available = ["2018-06-01"]
  ignore    = ["2020-01-01"]
}
service "marketplaceordering" {
  name      = "MarketplaceOrdering"
  available = ["2015-06-01", "2021-01-01"]
}
service "migrate" {
  name      = "Migrate"
  available = ["2020-01-01", "2020-07-07"]
  ignore    = ["2023-06-06"]
}
service "mixedreality" {
  name      = "MixedReality"
  available = ["2021-01-01", "2025-01-01"]
}
service "mobilenetwork" {
  name      = "MobileNetwork"
  available = ["2022-11-01", "2024-04-01"]
}
service "mongocluster" {
  name      = "MongoCluster"
  available = ["2024-07-01"]
}
service "monitor" {
  name      = "Insights"
  available = ["2015-04-01", "2018-03-01", "2018-04-16", "2019-10-17-preview", "2020-10-01", "2021-05-01-preview", "2021-07-01-preview", "2022-10-01", "2023-01-01", "2023-03-11", "2023-03-15-preview", "2023-04-03", "2024-02-01"]
}
service "msi" {
  name      = "ManagedIdentity"
  available = ["2023-01-31", "2024-11-30"]
}
service "mysql" {
  name      = "MySql"
  available = ["2017-12-01", "2023-12-30"]
}
service "netapp" {
  name      = "NetApp"
  available = ["2025-01-01", "2025-03-01", "2025-06-01"]
}
service "network" {
  name      = "Network"
  available = ["2023-09-01", "2023-11-01", "2024-01-01", "2024-05-01", "2024-07-01"]
}
service "networkcloud" {
  name      = "NetworkCloud"
  available = ["2025-02-01"]
}
service "networkfunction" {
  name      = "NetworkFunction"
  available = ["2022-11-01"]
}
service "newrelic" {
  name      = "NewRelic"
  available = ["2024-03-01", "2024-10-01"]
  ignore    = ["2024-01-01"]
}
service "nginx" {
  name      = "Nginx"
  available = ["2024-11-01-preview"]
}
service "notificationhubs" {
  name      = "NotificationHubs"
  available = ["2023-09-01"]
}
service "operationalinsights" {
  name      = "OperationalInsights"
  available = ["2019-09-01", "2020-08-01", "2022-10-01", "2023-09-01", "2025-02-01"]
}
service "operationsmanagement" {
  name      = "OperationsManagement"
  available = ["2015-11-01-preview"]
}
service "oracle" {
  name      = "OracleDatabase"
  available = ["2025-03-01"]
}
service "orbital" {
  name      = "Orbital"
  available = ["2022-11-01"]
}
service "paloaltonetworks" {
  name      = "PaloAltoNetworks"
  available = ["2022-08-29", "2023-09-01", "2025-05-23"]
}
service "policyinsights" {
  name      = "PolicyInsights"
  available = ["2021-10-01", "2024-10-01"]
}
service "portal" {
  name      = "Portal"
  available = ["2019-01-01-preview", "2020-09-01-preview"]
}
service "postgresql" {
  name      = "PostgreSql"
  available = ["2017-12-01", "2020-01-01", "2024-08-01"]
}
service "postgresqlhsc" {
  name      = "PostgreSqlHSC"
  available = ["2022-11-08"]
}
service "powerbidedicated" {
  name      = "PowerBIDedicated"
  available = ["2021-01-01"]
}
service "privatedns" {
  name      = "PrivateDNS"
  available = ["2024-06-01"]
}
service "purview" {
  name      = "Purview"
  available = ["2021-07-01", "2021-12-01"]
}
service "quota" {
  name      = "Quota"
  available = ["2025-07-15"]
}
service "recoveryservices" {
  name      = "RecoveryServices"
  available = ["2024-01-01", "2024-04-01", "2025-02-01"]
}
service "recoveryservicesbackup" {
  name      = "RecoveryServicesBackup"
  available = ["2023-02-01", "2024-10-01", "2025-02-01"]
}
service "recoveryservicessiterecovery" {
  name      = "RecoveryServicesSiteRecovery"
  available = ["2024-04-01", "2025-02-01"]
}
service "redhatopenshift" {
  name      = "RedHatOpenShift"
  available = ["2023-09-04", "2023-11-22"]
}
service "redis" {
  name      = "Redis"
  available = ["2024-03-01", "2024-11-01"]
}
service "redisenterprise" {
  name      = "RedisEnterprise"
  available = ["2024-10-01", "2025-04-01"]
}
service "relay" {
  name      = "Relay"
  available = ["2021-11-01", "2024-01-01"]
}
service "resourceconnector" {
  name      = "ResourceConnector"
  available = ["2022-10-27"]
}
service "resourcegraph" {
  name      = "ResourceGraph"
  available = ["2024-04-01"]
}
service "resources" {
  name      = "Resources"
  available = ["2015-11-01", "2020-05-01", "2020-10-01", "2021-07-01", "2022-02-01", "2022-06-01", "2022-09-01", "2022-12-01", "2023-07-01", "2025-01-01", "2025-04-01"]
  ignore    = ["2023-11-01"]
}
service "scvmm" {
  name      = "SystemCenterVirtualMachineManager"
  available = ["2023-10-07", "2025-03-13"]
}
service "search" {
  name      = "Search"
  available = ["2024-06-01-preview", "2025-05-01"]
}
service "security" {
  name      = "Security"
  available = ["2019-01-01-preview", "2021-06-01", "2022-05-01", "2022-12-01-preview", "2023-01-01", "2023-05-01", "2025-03-01"]
}
service "securityinsights" {
  name      = "SecurityInsights"
  available = ["2022-10-01-preview", "2022-11-01", "2023-12-01-preview", "2024-09-01", "2025-06-01"]
}
service "servicebus" {
  name      = "ServiceBus"
  available = ["2024-01-01"]
}
service "servicefabric" {
  name      = "ServiceFabric"
  available = ["2021-06-01"]
}
service "servicefabricmanagedclusters" {
  name      = "ServiceFabricManagedCluster"
  available = ["2024-04-01"]
}
service "servicelinker" {
  name      = "ServiceLinker"
  available = ["2022-05-01", "2024-04-01"]
}
service "servicenetworking" {
  name      = "ServiceNetworking"
  available = ["2025-01-01"]
}
service "signalr" {
  name      = "SignalR"
  available = ["2024-03-01"]
}
service "solutions" {
  name      = "ManagedApplications"
  available = ["2021-07-01"]
}
service "sql" {
  name      = "Sql"
  available = ["2023-08-01", "2023-08-01-preview"]
}
service "sqlvirtualmachine" {
  name      = "SqlVirtualMachine"
  available = ["2023-10-01"]
}
service "standbypool" {
  name      = "StandbyPool"
  available = ["2025-03-01"]
}
service "storage" {
  name      = "Storage"
  available = ["2023-01-01", "2023-05-01", "2025-01-01"]
  ignore    = ["2023-04-01"]
}
service "storagecache" {
  name      = "StorageCache"
  available = ["2023-05-01", "2024-07-01"]
}
service "storagemover" {
  name      = "StorageMover"
  available = ["2023-03-01", "2024-07-01"]
}
service "storagepool" {
  name      = "StoragePool"
  available = ["2021-08-01"]
}
service "storagesync" {
  name      = "StorageSync"
  available = ["2020-03-01", "2022-09-01"]
}
service "streamanalytics" {
  name      = "StreamAnalytics"
  available = ["2020-03-01", "2021-10-01-preview"]
}
service "subscription" {
  name      = "Subscription"
  available = ["2021-10-01"]
}
service "synapse" {
  name      = "Synapse"
  available = ["2021-06-01"]
}
service "trafficmanager" {
  name      = "TrafficManager"
  available = ["2022-04-01"]
}
service "vi" {
  name      = "VideoIndexer"
  available = ["2025-04-01"]
}
service "videoanalyzer" {
  name      = "VideoAnalyzer"
  available = ["2021-05-01-preview"]
}
service "vmware" {
  name      = "VMware"
  available = ["2022-05-01", "2024-09-01"]
}
service "voiceservices" {
  name      = "VoiceServices"
  available = ["2023-04-03", "2023-09-01"]
}
service "web" {
  name      = "Web"
  available = ["2016-06-01", "2023-01-01", "2023-12-01", "2024-11-01"]
}
service "webpubsub" {
  name      = "WebPubSub"
  available = ["2024-03-01"]
}
service "workloads" {
  name      = "Workloads"
  available = ["2024-09-01"]
}