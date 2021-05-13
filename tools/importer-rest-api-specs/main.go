package main

import (
	"fmt"
	"log"
	"os"
	"strings"

	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/generator"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/parser"
)

func main() {
	apiSpecsPath := os.Getenv("AZURE_API_SPECS_PATH") // i.e. where to find github.com/Azure/azure-rest-api-specs
	if apiSpecsPath == "" {                           // or make a best guess based on home dir...
		apiSpecsPath, _ = os.UserHomeDir()
		apiSpecsPath = apiSpecsPath + "/code/go"
	}
	//"/Users/steve/code/go/src/github.com/Azure/azure-rest-api-specs/"
	input := []RunInput{
		//{
		//	RootNamespace:    "Pandora.Definitions.DataPlane",
		//	OutputDirectory:  "../../generated/pandora-definitions",
		//	ServiceName:      "Synapse",
		//	ApiVersion:       "2020-08-01-preview",
		//	SwaggerDirectory: apiSpecsPath + "/github.com/Azure/azure-rest-api-specs/specification/web/resource-manager/Microsoft.Web/stable/2020-12-01",
		//	SwaggerFilePath:  "example-dp-synapse-roleDefinitions.json",
		//},
		//{
		//	RootNamespace:   "Pandora.Definitions.DataPlane",
		//	OutputDirectory: "../../generated/pandora-definitions",
		//	ServiceName:     "AppConfiguration",
		//	ApiVersion:      "1.0",
		//	SwaggerFilePath: "example-dp-appconfiguration.json",
		//},

		// Attestation
		{
			RootNamespace:    "Pandora.Definitions.ResourceManager",
			ServiceName:      "Attestation",
			ApiVersion:       "2020-10-01",
			OutputDirectory:  "../../generated/pandora-definitions",
			SwaggerDirectory: apiSpecsPath + "/github.com/Azure/azure-rest-api-specs/specification/attestation/resource-manager/Microsoft.Attestation/stable/2020-10-01",
			SwaggerFiles: []string{
				"attestation.json",
			},
		},

		// AppConfiguration
		//{
		//	RootNamespace:    "Pandora.Definitions.ResourceManager",
		//	ServiceName:      "AppConfiguration",
		//	ApiVersion:       "2020-06-01",
		//	OutputDirectory:  "../../generated/pandora-definitions",
		//	SwaggerDirectory: apiSpecsPath + "/github.com/Azure/azure-rest-api-specs/specification/appconfiguration/resource-manager/Microsoft.AppConfiguration/stable/2020-06-01",
		//	SwaggerFiles: []string{
		//		"appconfiguration.json",
		//	},
		//},

		// Batch
		//{
		//	RootNamespace:    "Pandora.Definitions.ResourceManager",
		//	ServiceName:      "Batch",
		//	ApiVersion:       "2020-03-01",
		//	OutputDirectory:  "../../generated/pandora-definitions",
		//	SwaggerDirectory: apiSpecsPath + "/github.com/Azure/azure-rest-api-specs/specification/batch/resource-manager/Microsoft.Batch/stable/2020-03-01/",
		//	SwaggerFiles: []string{
		//		"BatchManagement.json",
		//	},
		//},

		// Billing
		//{
		//	RootNamespace:    "Pandora.Definitions.ResourceManager",
		//	ServiceName:      "Billing",
		//	ApiVersion:       "2018-11-01-preview",
		//	OutputDirectory:  "../../generated/pandora-definitions",
		//	SwaggerDirectory: apiSpecsPath + "/github.com/Azure/azure-rest-api-specs/specification/billing/resource-manager/Microsoft.Billing/preview/2018-11-01-preview/",
		//	SwaggerFiles: []string{
		//		"billing.json",
		//	},
		//},

		// Compute
		//{
		//	RootNamespace:    "Pandora.Definitions.ResourceManager",
		//	ServiceName:      "Compute",
		//	ApiVersion:       "2020-12-01",
		//	OutputDirectory:  "../../generated/pandora-definitions",
		//	SwaggerDirectory: apiSpecsPath + "/github.com/Azure/azure-rest-api-specs/specification/compute/resource-manager/Microsoft.Compute/stable/2020-12-01",
		//	SwaggerFiles: []string{
		//		"compute.json",
		//		"disk.json",
		//		"runCommands.json",
		//	},
		//},

		// Data Protection (PSql)
		{
			RootNamespace:    "Pandora.Definitions.ResourceManager",
			ServiceName:      "DataProtection",
			ApiVersion:       "2021-01-01",
			OutputDirectory:  "../../generated/pandora-definitions",
			SwaggerDirectory: apiSpecsPath + "/github.com/Azure/azure-rest-api-specs/specification/dataprotection/resource-manager/Microsoft.DataProtection/stable/2021-01-01",
			SwaggerFiles: []string{
				"dataprotection.json",
			},
		},

		// Network (old)
		{
			RootNamespace:    "Pandora.Definitions.ResourceManager",
			ServiceName:      "Network",
			ApiVersion:       "2017-11-01",
			OutputDirectory:  "../../generated/pandora-definitions",
			SwaggerDirectory: apiSpecsPath + "/github.com/Azure/azure-rest-api-specs/specification/network/resource-manager/Microsoft.Network/stable/2017-11-01",
			SwaggerFiles: []string{
				"publicIpAddress.json",
			},
		},

		// Media
		//{
		//	RootNamespace:    "Pandora.Definitions.ResourceManager",
		//	ServiceName:      "MediaServices",
		//	ApiVersion:       "2021-05-01",
		//	OutputDirectory:  "../../generated/pandora-definitions",
		//	SwaggerDirectory: apiSpecsPath + "/github.com/Azure/azure-rest-api-specs/specification/mediaservices/resource-manager/Microsoft.Media/stable/2021-05-01",
		//	SwaggerFiles: []string{
		//		"Accounts.json",
		//	},
		//},

		// Web
		//{
		//	RootNamespace:    "Pandora.Definitions.ResourceManager",
		//	ServiceName:      "Web",
		//	ApiVersion:       "2020-12-01",
		//	OutputDirectory:  "../../generated/pandora-definitions",
		//	SwaggerDirectory: apiSpecsPath + "/github.com/Azure/azure-rest-api-specs/specification/web/resource-manager/Microsoft.Web/stable/2020-12-01",
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
		//	OutputDirectory:  "../../generated/pandora-definitions",
		//	SwaggerDirectory: apiSpecsPath + "/github.com/Azure/azure-rest-api-specs/specification/network/resource-manager/Microsoft.Network/stable/2020-08-01",
		//	SwaggerFiles: []string{
		//		"applicationGateway.json",
		//		"applicationSecurityGroup.json",
		//		"availableDelegations.json",
		//		"availableServiceAliases.json",
		//		"azureFirewall.json",
		//		"azureFirewallFqdnTag.json",
		//		"azureWebCategory.json",
		//		"bastionHost.json",
		//		"checkDnsAvailability.json",
		//		"cloudServiceNetworkInterface.json",
		//		"cloudServicePublicIpAddress.json",
		//		"customIpPrefix.json",
		//		"ddosCustomPolicy.json",
		//		"ddosProtectionPlan.json",
		//		"dscpConfiguration.json",
		//		"endpointService.json",
		//		"expressRouteCircuit.json",
		//		"expressRouteCrossConnection.json",
		//		"expressRoutePort.json",
		//		"firewallPolicy.json",
		//		"ipAllocation.json",
		//		"ipGroups.json",
		//		"loadBalancer.json",
		//		"natGateway.json",
		//		"network.json",
		//		"networkInterface.json",
		//		"networkProfile.json",
		//		"networkSecurityGroup.json",
		//		"networkVirtualAppliance.json",
		//		"networkWatcher.json",
		//		"operation.json",
		//		"privateEndpoint.json",
		//		"privateLinkService.json",
		//		"publicIpAddress.json",
		//		"publicIpPrefix.json",
		//		"routeFilter.json",
		//		"routeTable.json",
		//		"securityPartnerProvider.json",
		//		"serviceCommunity.json",
		//		"serviceEndpointPolicy.json",
		//		"serviceTags.json",
		//		"usage.json",
		//		"virtualNetwork.json",
		//		"virtualNetworkGateway.json",
		//		"virtualNetworkTap.json",
		//		"virtualRouter.json",
		//		"virtualWan.json",
		//		"vmssNetworkInterface.json",
		//		"vmssPublicIpAddress.json",
		//		"webapplicationfirewall.json",
		//	},
		//},
	}

	for _, v := range input {
		if err := run(v); err != nil {
			log.Printf("error: %+v", err)
			os.Exit(1)
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
	permissions := os.FileMode(0777)
	if err := os.MkdirAll(input.OutputDirectory, permissions); os.IsExist(err) {
		if debug {
			log.Printf("Removing existing Directory at %q", input.OutputDirectory)
		}
		os.RemoveAll(input.OutputDirectory)
	}
	if debug {
		log.Printf("Creating Directory at %q", input.OutputDirectory)
	}
	os.MkdirAll(input.OutputDirectory, permissions)

	for _, file := range input.SwaggerFiles {
		swaggerFile, err := parser.Load(input.SwaggerDirectory, file, debug)
		if err != nil {
			return fmt.Errorf("parsing file %q: %+v", file, err)
		}

		definition, err := swaggerFile.Parse(input.ServiceName, input.ApiVersion)
		if err != nil {
			return fmt.Errorf("parsing definition: %+v", err)
		}

		for resourceName, resource := range definition.Resources {
			if debug {
				log.Printf("Generating Resource at %q", resourceName)
			}
			generator := generator.NewPandoraDefinitionGenerator(input.RootNamespace, input.ServiceName, input.ApiVersion, debug)
			outputDirectory := generator.RecommendedWorkingDirectory(input.OutputDirectory, resourceName)
			os.MkdirAll(outputDirectory, permissions)
			if err := generator.Generate(resourceName, resource, outputDirectory); err != nil {
				return fmt.Errorf("generating %s: %+v", resourceName, err)
			}
		}
	}

	log.Printf("Generated into: %s", input.OutputDirectory)

	return nil
}
