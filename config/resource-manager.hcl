
service "advisor" {
  name      = "Advisor"
  available = ["2020-01-01", "2022-10-01", "2023-01-01"]
  ignore    = ["2022-09-01"]
}
service "alertsmanagement" {
  name      = "AlertsManagement"
  available = ["2021-08-08", "2023-03-01"]
}
service "analysisservices" {
  name      = "AnalysisServices"
  available = ["2017-08-01"]
}
service "apimanagement" {
  name      = "ApiManagement"
  available = ["2021-08-01", "2022-08-01"]
}
service "app" {
  name      = "ContainerApps"
  available = ["2022-03-01", "2022-11-01-preview", "2023-05-01"]
  ignore    = ["2022-10-01"]
}
service "appconfiguration" {
  name      = "AppConfiguration"
  available = ["2023-03-01"]
}
service "applicationinsights" {
  name      = "ApplicationInsights"
  available = ["2020-11-20", "2022-04-01", "2022-06-15"]
}
service "appplatform" {
  name      = "AppPlatform"
  available = ["2022-09-01-preview", "2022-12-01"]
}
service "attestation" {
  name      = "Attestation"
  available = ["2020-10-01", "2021-06-01"]
}
service "authorization" {
  name      = "Authorization"
  available = ["2020-10-01", "2022-04-01"]
}
service "automation" {
  name      = "Automation"
  available = ["2015-10-31", "2019-06-01", "2020-01-13-preview", "2021-06-22", "2022-08-08"]
}
service "azure-kusto" {
  name      = "Kusto"
  available = ["2023-05-02"]
}
service "azureactivedirectory" {
  name      = "AzureActiveDirectory"
  available = ["2017-04-01", "2020-03-01"]
}
service "azurestackhci" {
  name      = "AzureStackHCI"
  available = ["2023-03-01"]
}
service "batch" {
  name      = "Batch"
  available = ["2023-05-01"]
}
service "blueprint" {
  name      = "Blueprints"
  available = ["2018-11-01-preview"]
}
service "chaos" {
  name      = "ChaosStudio"
  available = ["2023-04-15-preview"]
}
service "cognitiveservices" {
  name      = "Cognitive"
  available = ["2023-05-01"]
}
service "communication" {
  name      = "Communication"
  available = ["2023-03-31"]
}
service "compute" {
  name      = "Compute"
  available = ["2021-07-01", "2021-11-01", "2022-03-01", "2022-03-02", "2022-03-03", "2023-03-01"]
}
service "confidentialledger" {
  name      = "ConfidentialLedger"
  available = ["2022-05-13"]
}
service "connectedvmware" {
  name      = "ConnectedVmware"
  available = ["2022-01-10-preview"]
}
service "consumption" {
  name      = "Consumption"
  available = ["2019-10-01", "2021-10-01", "2022-09-01", "2023-05-01", "2023-11-01"]
  ignore    = ["2023-03-01"]
}
service "containerinstance" {
  name      = "ContainerInstance"
  available = ["2023-05-01"]
}
service "containerregistry" {
  name      = "ContainerRegistry"
  available = ["2019-06-01-preview", "2021-08-01-preview", "2022-12-01", "2023-07-01"]
}
service "containerservice" {
  name      = "ContainerService"
  available = ["2019-08-01", "2022-09-02-preview", "2023-03-02-preview", "2023-04-02-preview"]
}
service "cosmos-db" {
  name      = "CosmosDB"
  available = ["2021-10-15", "2022-05-15", "2022-11-15", "2023-04-15"]
}
service "cost-management" {
  name      = "CostManagement"
  available = ["2021-10-01", "2022-06-01-preview", "2022-10-01", "2023-03-01", "2023-08-01"]
}
service "customproviders" {
  name      = "CustomProviders"
  available = ["2018-09-01-preview"]
}
service "dashboard" {
  name      = "Dashboard"
  available = ["2022-08-01"]
}
service "databoxedge" {
  name      = "DataBoxEdge"
  available = ["2022-03-01", "2023-07-01"]
}
service "databricks" {
  name      = "Databricks"
  available = ["2022-04-01-preview", "2022-10-01-preview", "2023-02-01", "2023-05-01"]
}
service "datadog" {
  name      = "DataDog"
  available = ["2021-03-01", "2022-06-01"]
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
  available = ["2018-04-19", "2021-06-30"]
}
service "dataprotection" {
  name      = "DataProtection"
  available = ["2022-04-01", "2022-05-01", "2022-12-01", "2023-01-01", "2023-05-01"]
}
service "datashare" {
  name      = "DataShare"
  available = ["2019-11-01", "2021-08-01"]
}
service "desktopvirtualization" {
  name      = "DesktopVirtualization"
  available = ["2021-09-03-preview", "2022-02-10-preview", "2022-09-09"]
}
service "deviceprovisioningservices" {
  name      = "DeviceProvisioningServices"
  available = ["2022-02-05", "2022-12-12"]
}
service "deviceupdate" {
  name      = "DeviceUpdate"
  available = ["2022-10-01", "2023-07-01"]
}
service "devtestlabs" {
  name      = "DevTestLab"
  available = ["2018-09-15"]
}
service "digitaltwins" {
  name      = "DigitalTwins"
  available = ["2020-12-01", "2022-10-31", "2023-01-31"]
}
service "dns" {
  name      = "DNS"
  available = ["2018-05-01"]
}
service "dnsresolver" {
  name      = "DNSResolver"
  available = ["2022-07-01"]
}
service "domainservices" {
  name      = "AAD"
  available = ["2021-05-01"]
  ignore    = ["2022-09-01", "2022-12-01"]
}
service "dynatrace" {
  name      = "Dynatrace"
  available = ["2021-09-01", "2023-04-27"]
}
service "elastic" {
  name      = "Elastic"
  available = ["2023-06-01"]
}
service "elasticsan" {
  name      = "ElasticSan"
  available = ["2021-11-20-preview"]
}
service "eventgrid" {
  name      = "EventGrid"
  available = ["2022-06-15"]
}
service "eventhub" {
  name      = "EventHub"
  available = ["2021-11-01", "2022-01-01-preview"]
}
service "extendedlocation" {
  name      = "ExtendedLocation"
  available = ["2021-08-15"]
}
service "fluidrelay" {
  name      = "FluidRelay"
  available = ["2022-05-26", "2022-06-01"]
}
service "frontdoor" {
  name      = "FrontDoor"
  available = ["2020-04-01", "2020-05-01", "2022-05-01"]
}
service "graphservicesprod" {
  name      = "GraphServices"
  available = ["2023-04-13"]
}
service "guestconfiguration" {
  name      = "GuestConfiguration"
  available = ["2020-06-25", "2022-01-25"]
}
service "hardwaresecuritymodules" {
  name      = "HardwareSecurityModules"
  available = ["2021-11-30"]
}
service "hdinsight" {
  name      = "HDInsight"
  available = ["2018-06-01-preview", "2021-06-01"]
}
service "healthbot" {
  name      = "HealthBot"
  available = ["2022-08-08", "2023-05-01"]
}
service "healthcareapis" {
  name      = "HealthcareApis"
  available = ["2022-12-01", "2023-02-28"]
}
service "hybridcompute" {
  name      = "HybridCompute"
  available = ["2022-11-10", "2022-12-27"]
}
service "hybridkubernetes" {
  name      = "HybridKubernetes"
  available = ["2021-10-01"]
}
service "iotcentral" {
  name      = "IoTCentral"
  available = ["2021-11-01-preview"]
}
service "keyvault" {
  name      = "KeyVault"
  available = ["2021-10-01", "2022-11-01", "2023-02-01"]
}
service "kubernetesconfiguration" {
  name      = "KubernetesConfiguration"
  available = ["2022-03-01", "2022-11-01", "2023-05-01"]
}
service "labservices" {
  name      = "LabServices"
  available = ["2021-10-01-preview", "2022-08-01", "2023-06-07"]
}
service "liftrqumulo" {
  name      = "QumuloStorage"
  available = ["2022-10-12"]
}
service "loadtestservice" {
  name      = "LoadTestService"
  available = ["2022-12-01"]
}
service "logic" {
  name      = "Logic"
  available = ["2019-05-01"]
}
service "logz" {
  name      = "Logz"
  available = ["2020-10-01"]
}
service "machinelearningservices" {
  name      = "MachineLearningServices"
  available = ["2022-05-01", "2022-10-01", "2023-04-01", "2023-04-01-preview"]
}
service "maintenance" {
  name      = "Maintenance"
  available = ["2021-05-01", "2022-07-01-preview", "2023-04-01"]
}
service "managedservices" {
  name      = "ManagedServices"
  available = ["2019-06-01", "2022-10-01"]
}
service "managementgroups" {
  name      = "ManagementGroups"
  available = ["2020-05-01", "2021-04-01", "2023-04-01"]
}
service "maps" {
  name      = "Maps"
  available = ["2021-02-01", "2023-06-01"]
}
service "mariadb" {
  name      = "MariaDB"
  available = ["2018-06-01", "2018-06-01-preview", "2020-01-01"]
}
service "marketplaceordering" {
  name      = "MarketplaceOrdering"
  available = ["2015-06-01", "2021-01-01"]
}
service "mediaservices" {
  name      = "Media"
  available = ["2021-11-01", "2022-07-01", "2022-08-01"]
}
service "migrate" {
  name      = "Migrate"
  available = ["2020-01-01", "2020-07-07"]
}
service "mixedreality" {
  name      = "MixedReality"
  available = ["2021-01-01"]
}
service "mobilenetwork" {
  name      = "MobileNetwork"
  available = ["2022-11-01", "2023-06-01"]
}
service "monitor" {
  name      = "Insights"
  available = ["2015-04-01", "2016-03-01", "2018-03-01", "2018-04-16", "2019-10-17-preview", "2020-10-01", "2021-04-01", "2021-05-01-preview", "2021-08-01", "2021-09-01", "2022-06-01", "2022-10-01", "2023-01-01", "2023-04-03"]
}
service "msi" {
  name      = "ManagedIdentity"
  available = ["2023-01-31"]
}
service "mysql" {
  name      = "MySql"
  available = ["2017-12-01", "2020-01-01", "2021-05-01", "2021-12-01-preview", "2022-01-01"]
}
service "netapp" {
  name      = "NetApp"
  available = ["2022-05-01", "2022-09-01", "2022-11-01"]
}
service "network" {
  name      = "Network"
  available = ["2023-02-01", "2023-04-01", "2023-05-01"]
}
service "networkfunction" {
  name      = "NetworkFunction"
  available = ["2022-08-01", "2022-11-01"]
}
service "newrelic" {
  name      = "NewRelic"
  available = ["2022-07-01"]
}
service "nginx" {
  name      = "Nginx"
  available = ["2022-08-01"]
}
service "notificationhubs" {
  name      = "NotificationHubs"
  available = ["2017-04-01"]
}
service "operationalinsights" {
  name      = "OperationalInsights"
  available = ["2019-09-01", "2020-08-01", "2022-10-01"]
}
service "operationsmanagement" {
  name      = "OperationsManagement"
  available = ["2015-11-01-preview"]
}
service "orbital" {
  name      = "Orbital"
  available = ["2022-11-01"]
}
service "paloaltonetworks" {
  name      = "PaloAltoNetworks"
  available = ["2022-08-29"]
}
service "policyinsights" {
  name      = "PolicyInsights"
  available = ["2021-10-01", "2022-09-01", "2023-03-01"]
}
service "portal" {
  name      = "Portal"
  available = ["2019-01-01-preview"]
}
service "postgresql" {
  name      = "PostgreSql"
  available = ["2017-12-01", "2018-06-01", "2020-01-01", "2021-06-01", "2022-03-08-preview", "2022-12-01", "2023-03-01-preview"]
}
service "postgresqlhsc" {
  name      = "PostgreSqlHSC"
  available = ["2020-10-05-privatepreview", "2022-11-08"]
}
service "powerbidedicated" {
  name      = "PowerBIDedicated"
  available = ["2021-01-01"]
}
service "privatedns" {
  name      = "PrivateDNS"
  available = ["2020-06-01"]
}
service "purview" {
  name      = "Purview"
  available = ["2021-07-01", "2021-12-01"]
}
service "recoveryservices" {
  name      = "RecoveryServices"
  available = ["2021-08-01", "2021-12-01", "2022-03-01", "2022-08-01", "2022-09-10", "2022-10-01", "2023-02-01", "2023-04-01"]
  ignore    = ["2023-01-01"]
}
service "recoveryservicesbackup" {
  name      = "RecoveryServicesBackup"
  available = ["2023-01-15", "2023-02-01", "2023-04-01"]
}
service "recoveryservicessiterecovery" {
  name      = "RecoveryServicesSiteRecovery"
  available = ["2022-10-01", "2023-01-01", "2023-02-01", "2023-04-01", "2023-06-01"]
}
service "redhatopenshift" {
  name      = "RedHatOpenShift"
  available = ["2022-04-01", "2022-09-04", "2023-04-01"]
}
service "redis" {
  name      = "Redis"
  available = ["2022-06-01", "2023-04-01"]
}
service "redisenterprise" {
  name      = "RedisEnterprise"
  available = ["2022-01-01", "2023-07-01"]
}
service "relay" {
  name      = "Relay"
  available = ["2021-11-01"]
}
service "resourceconnector" {
  name      = "ResourceConnector"
  available = ["2022-10-27"]
}
service "resources" {
  name      = "Resources"
  available = ["2020-05-01", "2020-06-01", "2020-10-01", "2021-04-01", "2021-06-01", "2021-07-01", "2022-06-01", "2022-07-01-preview", "2022-09-01", "2022-12-01"]
}
service "search" {
  name      = "Search"
  available = ["2022-09-01"]
}
service "security" {
  name      = "Security"
  available = ["2017-08-01-preview", "2019-01-01", "2019-01-01-preview", "2020-01-01", "2021-06-01", "2022-03-01", "2022-05-01", "2023-01-01", "2023-05-01"]
}
service "securityinsights" {
  name      = "SecurityInsights"
  available = ["2021-09-01-preview", "2022-07-01-preview", "2022-08-01", "2022-10-01-preview", "2022-11-01", "2023-02-01"]
}
service "servicebus" {
  name      = "ServiceBus"
  available = ["2021-06-01-preview", "2021-11-01", "2022-01-01-preview"]
}
service "servicefabric" {
  name      = "ServiceFabric"
  available = ["2021-06-01"]
}
service "servicefabricmanagedclusters" {
  name      = "ServiceFabricManagedCluster"
  available = ["2021-05-01", "2022-01-01"]
}
service "servicelinker" {
  name      = "ServiceLinker"
  available = ["2022-05-01"]
}
service "servicenetworking" {
  name      = "ServiceNetworking"
  available = ["2023-05-01-preview"]
}
service "signalr" {
  name      = "SignalR"
  available = ["2023-02-01"]
}
service "solutions" {
  name      = "ManagedApplications"
  available = ["2019-07-01", "2021-07-01"]
}
service "sqlvirtualmachine" {
  name      = "SqlVirtualMachine"
  available = ["2022-02-01"]
}
service "storage" {
  name      = "Storage"
  available = ["2022-05-01", "2022-09-01", "2023-01-01"]
}
service "storagecache" {
  name      = "StorageCache"
  available = ["2023-01-01", "2023-05-01"]
}
service "storagemover" {
  name      = "StorageMover"
  available = ["2023-03-01"]
}
service "storagepool" {
  name      = "StoragePool"
  available = ["2021-08-01"]
}
service "storagesync" {
  name      = "StorageSync"
  available = ["2020-03-01"]
  ignore    = ["2020-09-01", "2022-06-01"]
}
service "streamanalytics" {
  name      = "StreamAnalytics"
  available = ["2020-03-01", "2021-10-01-preview"]
}
service "subscription" {
  name      = "Subscription"
  available = ["2021-10-01"]
}
service "timeseriesinsights" {
  name      = "TimeSeriesInsights"
  available = ["2020-05-15"]
}
service "trafficmanager" {
  name      = "TrafficManager"
  available = ["2018-08-01", "2022-04-01"]
}
service "videoanalyzer" {
  name      = "VideoAnalyzer"
  available = ["2021-05-01-preview"]
}
service "vmware" {
  name      = "VMware"
  available = ["2022-05-01", "2023-03-01"]
}
service "voiceservices" {
  name      = "VoiceServices"
  available = ["2023-04-03"]
}
service "web" {
  name      = "Web"
  available = ["2016-06-01", "2022-09-01"]
}
service "webpubsub" {
  name      = "WebPubSub"
  available = ["2023-02-01"]
}
service "workloads" {
  name      = "Workloads"
  available = ["2023-04-01"]
}
