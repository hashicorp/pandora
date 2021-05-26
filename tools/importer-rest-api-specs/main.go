package main

import (
	"fmt"
	"log"
	"os"
	"strings"

	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/generator"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/parser"
)

const (
	outputDirectory  = "../../generated/pandora-definitions"
	swaggerDirectory = "../../swagger"
	RootNamespace    = "Pandora.Definitions.ResourceManager"
	permissions      = os.FileMode(0755)
)

// Use: `PANDORA_GEN_FOR_REALSIES=true go run main.go`
// or, for redirecting to a file: `PANDORA_GEN_FOR_REALSIES=true go run main.go > ~/tmp/pandora_gen.log 2>&1`

func main() {
	input := []RunInput{
		//{
		//	RootNamespace:    "Pandora.Definitions.DataPlane",
		//	OutputDirectory:  outputDirectory,
		//	ServiceName:      "Synapse",
		//	ApiVersion:       "2020-08-01-preview",
		//	SwaggerDirectory: swaggerDirectory + "/specification/web/resource-manager/Microsoft.Web/stable/2020-12-01",
		//	SwaggerFilePath:  "example-dp-synapse-roleDefinitions.json",
		//},
		//{
		//	RootNamespace:   "Pandora.Definitions.DataPlane",
		//	OutputDirectory: outputDirectory,
		//	ServiceName:     "AppConfiguration",
		//	ApiVersion:      "1.0",
		//	SwaggerFilePath: "example-dp-appconfiguration.json",
		//},

		// Attestation
		//{
		//	RootNamespace:    "Pandora.Definitions.ResourceManager",
		//	ServiceName:      "Attestation",
		//	ApiVersion:       "2020-10-01",
		//	OutputDirectory:  outputDirectory,
		//	SwaggerDirectory: swaggerDirectory + "/specification/attestation/resource-manager/Microsoft.Attestation/stable/2020-10-01",
		//	SwaggerFiles: []string{
		//		"attestation.json",
		//	},
		//},

		// AppConfiguration
		{
			RootNamespace:    RootNamespace,
			ServiceName:      "AppConfiguration",
			ApiVersion:       "2020-06-01",
			OutputDirectory:  outputDirectory,
			SwaggerDirectory: swaggerDirectory + "/specification/appconfiguration/resource-manager/Microsoft.AppConfiguration/stable/2020-06-01",
			SwaggerFiles: []string{
				"appconfiguration.json",
			},
		},

		// EventHubs (2018-01-01-preview and 2017-04-01)
		{
			RootNamespace:    RootNamespace,
			ServiceName:      "EventHub",
			ApiVersion:       "2017-04-01",
			OutputDirectory:  outputDirectory,
			SwaggerDirectory: swaggerDirectory + "/specification/eventhub/resource-manager/Microsoft.EventHub/stable/2017-04-01",
			SwaggerFiles: []string{
				"AuthorizationRules.json",
				"CheckNameAvailability.json",
				"consumergroups.json",
				"disasterRecoveryConfigs.json",
				"eventhubs.json",
				"namespaces.json",
				"networkRuleSets.json",
				"operations.json",
				"sku.json",
			},
		},
		{
			RootNamespace:    RootNamespace,
			ServiceName:      "EventHub",
			ApiVersion:       "2018-01-01-preview",
			OutputDirectory:  outputDirectory,
			SwaggerDirectory: swaggerDirectory + "/specification/eventhub/resource-manager/Microsoft.EventHub/preview/2018-01-01-preview",
			SwaggerFiles: []string{
				"AuthorizationRules.json",
				"AvailableClusterRegions-preview.json",
				"CheckNameAvailability.json",
				"Clusters-preview.json",
				"consumergroups.json",
				"disasterRecoveryConfigs.json",
				"eventhubs.json",
				"ipfilterrules-preview.json",
				"namespaces-preview.json",
				"networkrulessets-preview.json",
				"operations-preview.json",
				"operations.json",
				"quotaConfiguration-preview.json",
				"sku.json",
				"virtualnetworkrules-preview.json",
			},
		},

		// Batch
		//{
		//	RootNamespace:    "Pandora.Definitions.ResourceManager",
		//	ServiceName:      "Batch",
		//	ApiVersion:       "2020-03-01",
		//	OutputDirectory:  outputDirectory,
		//	SwaggerDirectory: swaggerDirectory + "/specification/batch/resource-manager/Microsoft.Batch/stable/2020-03-01/",
		//	SwaggerFiles: []string{
		//		"BatchManagement.json",
		//	},
		//},

		// Billing
		//{
		//	RootNamespace:    "Pandora.Definitions.ResourceManager",
		//	ServiceName:      "Billing",
		//	ApiVersion:       "2018-11-01-preview",
		//	OutputDirectory:  outputDirectory,
		//	SwaggerDirectory: swaggerDirectory + "/specification/billing/resource-manager/Microsoft.Billing/preview/2018-11-01-preview/",
		//	SwaggerFiles: []string{
		//		"billing.json",
		//	},
		//},

		// Compute
		//{
		//	RootNamespace:    "Pandora.Definitions.ResourceManager",
		//	ServiceName:      "Compute",
		//	ApiVersion:       "2020-12-01",
		//	OutputDirectory:  outputDirectory,
		//	SwaggerDirectory: swaggerDirectory + "/specification/compute/resource-manager/Microsoft.Compute/stable/2020-12-01",
		//	SwaggerFiles: []string{
		//		"compute.json",
		//		"disk.json",
		//		"runCommands.json",
		//	},
		//},

		// Cosmos
		//{
		//	RootNamespace:    "Pandora.Definitions.ResourceManager",
		//	ServiceName:      "Cosmosdb",
		//	ApiVersion:       "2020-12-01",
		//	OutputDirectory:  outputDirectory,
		//	// swagger/specification/cosmos-db/resource-manager/Microsoft.DocumentDB/stable/2021-01-15/cosmos-db.json
		//	SwaggerDirectory: swaggerDirectory + "/specification/cosmos-db/resource-manager/Microsoft.DocumentDB/stable/2021-01-15",
		//	SwaggerFiles: []string{
		//		"cosmos-db.json",
		//		"notebook.json",
		//		"privateEndpointConnection.json",
		//		"privateLinkResources.json",
		//	},
		//},

		// Data Protection (PSql)
		{
			RootNamespace:    "Pandora.Definitions.ResourceManager",
			ServiceName:      "DataProtection",
			ApiVersion:       "2021-01-01",
			OutputDirectory:  outputDirectory,
			SwaggerDirectory: swaggerDirectory + "/specification/dataprotection/resource-manager/Microsoft.DataProtection/stable/2021-01-01",
			SwaggerFiles: []string{
				"dataprotection.json",
			},
		},

		// Healthcare APIS
		//{
		//	RootNamespace:    "Pandora.Definitions.ResourceManager",
		//	ServiceName:      "HealthcareApis",
		//	ApiVersion:       "2021-01-01",
		//	OutputDirectory:  outputDirectory,
		//	SwaggerDirectory: swaggerDirectory + "/specification/healthcareapis/resource-manager/Microsoft.HealthcareApis/stable/2021-01-11",
		//	SwaggerFiles: []string{
		//		"healthcare-apis.json",
		//	},
		//},

		// Logic
		//{
		//	RootNamespace:    "Pandora.Definitions.ResourceManager",
		//	ServiceName:      "Logic",
		//	ApiVersion:       "2021-01-01",
		//	OutputDirectory:  outputDirectory,
		//	SwaggerDirectory: swaggerDirectory + "/specification/logic/resource-manager/Microsoft.Logic/stable/2019-05-01",
		//	SwaggerFiles: []string{
		//		"logic.json",
		//	},
		//},

		// Network (old)
		//{
		//	RootNamespace:    "Pandora.Definitions.ResourceManager",
		//	ServiceName:      "Network",
		//	ApiVersion:       "2017-11-01",
		//	OutputDirectory:  outputDirectory,
		//	SwaggerDirectory: swaggerDirectory + "/specification/network/resource-manager/Microsoft.Network/stable/2017-11-01",
		//	SwaggerFiles: []string{
		//		"publicIpAddress.json",
		//	},
		//},

		// Media
		//{
		//	RootNamespace:    "Pandora.Definitions.ResourceManager",
		//	ServiceName:      "MediaServices",
		//	ApiVersion:       "2021-05-01",
		//	OutputDirectory:  outputDirectory,
		//	SwaggerDirectory: swaggerDirectory + "/specification/mediaservices/resource-manager/Microsoft.Media/stable/2021-05-01",
		//	SwaggerFiles: []string{
		//		"Accounts.json",
		//	},
		//},

		// Web
		//{
		//	RootNamespace:    "Pandora.Definitions.ResourceManager",
		//	ServiceName:      "Web",
		//	ApiVersion:       "2020-12-01",
		//	OutputDirectory:  outputDirectory,
		//	SwaggerDirectory: swaggerDirectory + "/specification/web/resource-manager/Microsoft.Web/stable/2020-12-01",
		//	SwaggerFiles: []string{
		//		// NOTE: stripped out CommonDefinitions.json
		//		"AppServiceEnvironments.json",
		//		"AppServicePlans.json",
		//		"Certificates.json",
		//		"DeletedWebApps.json",
		//		"Diagnostics.json",
		//		"Global.json",
		//		"Provider.json",
		//		"Recommendations.json",
		//		"ResourceHealthMetadata.json",
		//		"ResourceProvider.json",
		//		"StaticSites.json",
		//		"WebApps.json",
		//	},
		//},

		//Network
		//{
		//	RootNamespace:    "Pandora.Definitions.ResourceManager",
		//	ServiceName:      "Network",
		//	ApiVersion:       "2020-08-01",
		//	OutputDirectory:  outputDirectory,
		//	SwaggerDirectory: swaggerDirectory + "/specification/network/resource-manager/Microsoft.Network/stable/2020-08-01",
		//	SwaggerFiles: []string{
		//		//"applicationGateway.json",
		//		//"applicationSecurityGroup.json",
		//		//"availableDelegations.json",
		//		//"availableServiceAliases.json",
		//		//"azureFirewall.json",
		//		//"azureFirewallFqdnTag.json",
		//		//"azureWebCategory.json",
		//		//"bastionHost.json",
		//		//"checkDnsAvailability.json",
		//		//"cloudServiceNetworkInterface.json",
		//		//"cloudServicePublicIpAddress.json",
		//		//"customIpPrefix.json",
		//		//"ddosCustomPolicy.json",
		//		//"ddosProtectionPlan.json",
		//		//"dscpConfiguration.json",
		//		//"endpointService.json",
		//		//"expressRouteCircuit.json",
		//		//"expressRouteCrossConnection.json",
		//		//"expressRoutePort.json",
		//		//"firewallPolicy.json",
		//		//"ipAllocation.json",
		//		//"ipGroups.json",
		//		//"loadBalancer.json",
		//		//"natGateway.json",
		//		//"network.json",
		//		"networkInterface.json",
		//		//"networkProfile.json",
		//		//"networkSecurityGroup.json",
		//		//"networkVirtualAppliance.json",
		//		//"networkWatcher.json",
		//		//"operation.json",
		//		//"privateEndpoint.json",
		//		//"privateLinkService.json",
		//		//"publicIpAddress.json",
		//		//"publicIpPrefix.json",
		//		//"routeFilter.json",
		//		//"routeTable.json",
		//		//"securityPartnerProvider.json",
		//		//"serviceCommunity.json",
		//		//"serviceEndpointPolicy.json",
		//		//"serviceTags.json",
		//		//"usage.json",
		//		//"virtualNetwork.json",
		//		//"virtualNetworkGateway.json",
		//		//"virtualNetworkTap.json",
		//		//"virtualRouter.json",
		//		//"virtualWan.json",
		//		//"vmssNetworkInterface.json",
		//		//"vmssPublicIpAddress.json",
		//		//"webapplicationfirewall.json",
		//	},
		//},
	}

	if !strings.EqualFold(os.Getenv("PANDORA_GEN_FOR_REALSIES"), "true") {
		for _, v := range input {
			if err := run(v); err != nil {
				log.Printf("error: %+v", err)
				os.Exit(1)
			}
		}
	} else {
		permissions := os.FileMode(0755)
		services, err := parser.FindResourceManagerServices(swaggerDirectory + "/specification")
		if err != nil {
			fmt.Printf("%s", err)
			os.Exit(1)
		}
		loadFailures := make([]string, 0)
		genFailures := make([]string, 0)
		parseFailures := make([]string, 0)
		for _, service := range *services {
			for apiVersion, versionPath := range service.ApiVersionPaths {
				swaggerFiles, err := parser.SwaggerFilesInDirectory(versionPath)
				if err != nil {
					fmt.Println(err.Error())
				}

				for _, f := range *swaggerFiles {
					fileName := strings.TrimPrefix(f, versionPath)
					fmt.Println(fmt.Sprintf("[DEBUG] loading %s%s (API Version: %s)", service.Name, fileName, apiVersion))
					parsed, erl := parser.Load(versionPath, fileName, false)
					if erl != nil {
						loadAttempt := 0
						MaxLoadFails := 5
						for loadAttempt < MaxLoadFails {
							parsed, erl = parser.Load(versionPath, fileName, false)
							if erl != nil {
								fmt.Println(fmt.Sprintf("failed loading %q (%s), attempt %d, error was: %s", fileName, service.Name, loadAttempt+1, erl.Error()))
								loadAttempt++
							}
						}
						if loadAttempt >= MaxLoadFails {
							loadFailures = append(loadFailures, fmt.Sprintf("failed loading %q (%s) after %d attempts, giving up: %s", fileName, service.Name, loadAttempt, erl))
							break
						} else {
							fmt.Println(fmt.Sprintf("succeeded loading %q (%s) on attempt %d", fileName, service.Name, loadAttempt))
						}

					}
					fmt.Println(fmt.Sprintf("[DEBUG] parsing %s%s (API Version: %s)", service.Name, fileName, apiVersion))
					def, erp := parsed.Parse(service.Name, apiVersion)
					if erp != nil {
						fmt.Println(erp.Error())
						parseFailures = append(parseFailures, fmt.Sprintf("failed parsing %s: %s", service.Name, erp))
						break
					}

					data := generator.GenerationDataForServiceAndApiVersion(service.Name, apiVersion, outputDirectory, RootNamespace)
					generator := generator.NewPackageDefinitionGenerator(data, false)
					for resourceName, resource := range def.Resources {
						apiOutputDirectory := data.WorkingDirectoryForResource(resourceName)
						os.MkdirAll(apiOutputDirectory, permissions)
						fmt.Println(fmt.Sprintf("[DEBUG] Generating resource %s in service %s (API version: %s)", resourceName, def.ServiceName, def.ApiVersion))
						namespace := data.NamespaceForResource(resourceName)
						if err := generator.GenerateResources(resourceName, namespace, resource, apiOutputDirectory); err != nil {
							fmt.Printf("generating %s: %+v", resourceName, err)
							genFailures = append(genFailures, fmt.Sprintf("%s in %s", resourceName, apiOutputDirectory))
						}
					}
				}
			}
		}
		if len(loadFailures) > 0 {
			for _, l := range loadFailures {
				fmt.Println(fmt.Sprintf("Failed to load: %s", l))
			}
		}
		if len(parseFailures) > 0 {
			for _, p := range parseFailures {
				fmt.Println(fmt.Sprintf("Failed to parse: %s", p))
			}
		}
		if len(genFailures) > 0 {
			for _, g := range genFailures {
				fmt.Println(fmt.Sprintf("Failed to generate: %s", g))
			}
		}
	}

	os.Exit(0)
}

type RunInput struct {
	RootNamespace    string
	ServiceName      string
	ApiVersion       string
	OutputDirectory  string
	SwaggerDirectory string
	SwaggerFiles     []string
}

func run(input RunInput) error {
	debug := strings.TrimSpace(os.ExpandEnv("DEBUG")) != ""

	if debug {
		log.Printf("[STAGE] Parsing Swagger Files..")
	}
	data, err := parseSwaggerFiles(input, debug)
	if err != nil {
		return fmt.Errorf("parsing Swagger files: %+v", err)
	}

	if debug {
		log.Printf("[STAGE] Generating Swagger Definitions..")
	}
	if err := generateServiceDefinitions(*data, input.OutputDirectory, input.RootNamespace, debug); err != nil {
		return fmt.Errorf("generating Service Definitions: %+v", err)
	}

	if debug {
		log.Printf("[STAGE] Generating API Definitions..")
	}
	if err := generateApiVersions(*data, input.OutputDirectory, input.RootNamespace, debug); err != nil {
		return fmt.Errorf("generating API Versions: %+v", err)
	}

	return nil
}
