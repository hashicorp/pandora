// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package main

import (
	"flag"
	"fmt"
	"log"
	"os"
	"path"
	"path/filepath"
	"strings"
	"sync"

	"github.com/hashicorp/pandora/tools/generator-go-sdk/generator"
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
	"github.com/hashicorp/pandora/tools/sdk/services"
)

type GeneratorInput struct {
	apiServerEndpoint string
	outputDirectory   string
	services          []string
	settings          generator.Settings
}

func main() {
	input := GeneratorInput{
		settings: generator.Settings{},
	}

	input.settings.UseOldBaseLayerFor(
		// @tombuildsstuff: New Services should now use the `hashicorp/go-azure-sdk` base layer by default
		// instead of the base layer from `Azure/go-autorest` - as such this list is for compatibility purposes
		// with services already used in `terraform-provider-azurerm`. These services will be gradually removed
		// from this list to ensure they're migrated across to using `hashicorp/go-azure-sdk`s base layer.

		"ContainerInstance",
		"CosmosDB",
		"FrontDoor",
		"Insights",
		"RecoveryServicesBackup", // error: generating Service "RecoveryServicesBackup" / Version "2023-04-01" / Resource "Operation": generating methods: templating methods (using hashicorp/go-azure-sdk): templating: building methods: building response struct template: existing model "ValidateOperationResponse" conflicts with the operation response model for "Validate"
		"Security",
		"SecurityInsights",
		"ServiceFabric",
		"SqlVirtualMachine",
		"Subscription",
		"TimeSeriesInsights",

		// @tombuildsstuff: The Key Vault API has an issue where it requires that the EXACT casing returned in the Response
		// is sent in the Request to update or remove a Key Vault Access Policy - and using other casings mean the update
		// or removal fails - which is tracked in https://github.com/hashicorp/pandora/issues/3229.
		//
		// After testing it appears that `2023-07-01` doesn't suffer from this problem - as such we're going to leave
		// `2023-02-01` on the older base layer and use the newer API Version as a divide to give us a clear migration path.
		"KeyVault@2023-02-01",
	)

	var serviceNames string

	f := flag.NewFlagSet("generator-go-sdk", flag.ExitOnError)
	f.StringVar(&input.apiServerEndpoint, "data-api", "http://localhost:5000", "-data-api=http://localhost:5000")
	f.StringVar(&input.outputDirectory, "output-dir", "", "-output-dir=../generated-sdk-dev")
	f.StringVar(&serviceNames, "services", "", "A list of comma separated Service named from the Data API to import")
	if err := f.Parse(os.Args[1:]); err != nil {
		log.Fatalf("parsing arguments: %+v", err)
	}

	if serviceNames != "" {
		input.services = strings.Split(serviceNames, ",")
	}

	if input.outputDirectory == "" {
		homeDir, _ := os.UserHomeDir()
		input.outputDirectory = filepath.Join(homeDir, "/Desktop/generated-sdk-dev")
	}

	if err := run(input); err != nil {
		log.Printf("error: %+v", err)
		os.Exit(1)
		return
	}

	os.Exit(0)
}

func run(input GeneratorInput) error {
	client := resourcemanager.NewResourceManagerClient(input.apiServerEndpoint)

	// resource manager items should be output into the folder ./resource-manager
	input.outputDirectory = path.Join(input.outputDirectory, "resource-manager")

	var loadedServices services.ResourceManagerServices
	if len(input.services) > 0 {
		log.Printf("[DEBUG] Loading the Services from the Data API %q..", strings.Join(input.services, " / "))
		services, err := services.GetResourceManagerServicesByName(client, input.services)
		if err != nil {
			return fmt.Errorf("retrieving resource manager services: %+v", err)
		}
		loadedServices = *services
	} else {
		log.Printf("[DEBUG] Loading All Services..")
		services, err := services.GetResourceManagerServices(client)
		if err != nil {
			return fmt.Errorf("retrieving resource manager services: %+v", err)
		}
		loadedServices = *services
	}

	errCh := make(chan error, 1)
	waitDone := make(chan struct{}, 1)
	var wg sync.WaitGroup
	addErr := func(err error) {
		// only put one err to channel
		select {
		case errCh <- err:
		default:
		}
	}

	generatorService := generator.NewServiceGenerator(input.settings)
	for serviceName, service := range loadedServices.Services {
		log.Printf("[DEBUG] Service %q..", serviceName)
		if !service.Details.Generate {
			log.Printf("[DEBUG] .. is opted out of generation, skipping..")
			continue
		}

		wg.Add(1)
		go func(serviceName string, service services.ResourceManagerService, input GeneratorInput) {
			defer wg.Done()
			log.Printf("[DEBUG] Service %q", serviceName)
			for versionNumber, versionDetails := range service.Versions {
				log.Printf("[DEBUG]   Version %q", versionNumber)
				for resourceName, resourceDetails := range versionDetails.Resources {
					log.Printf("[DEBUG]      Resource %q..", resourceName)
					generatorData := generator.ServiceGeneratorInput{
						ServiceName:     serviceName,
						ServiceDetails:  service,
						VersionName:     versionNumber,
						VersionDetails:  versionDetails,
						ResourceName:    resourceName,
						ResourceDetails: resourceDetails,
						OutputDirectory: input.outputDirectory,
						Source:          versionDetails.Details.Source,
					}
					log.Printf("[DEBUG] Generating Service %q / Version %q / Resource %q..", serviceName, versionNumber, resourceName)
					if err := generatorService.Generate(generatorData); err != nil {
						addErr(fmt.Errorf("generating Service %q / Version %q / Resource %q: %+v", serviceName, versionNumber, resourceName, err))
						return
					}
					log.Printf("[DEBUG] Generated Service %q / Version %q / Resource %q..", serviceName, versionNumber, resourceName)
				}

				// then output the Meta Client
				generatorData := generator.VersionInput{
					OutputDirectory: input.outputDirectory,
					ServiceName:     serviceName,
					VersionName:     versionNumber,
					Resources:       versionDetails.Resources,
					Source:          versionDetails.Details.Source,
				}
				generatorData.UseNewBaseLayer = false
				if input.settings.ShouldUseNewBaseLayer(serviceName, versionNumber) {
					generatorData.UseNewBaseLayer = true
				}
				log.Printf("[DEBUG] Generating Service %q / Version %q..", serviceName, versionNumber)
				if err := generatorService.GenerateForVersion(generatorData); err != nil {
					addErr(fmt.Errorf("generating Service %q / Version %q: %+v", serviceName, versionNumber, err))
					return
				}
				log.Printf("[DEBUG] Generated Service %q / Version %q..", serviceName, versionNumber)
			}
		}(serviceName, service, input)
	}

	go func() {
		wg.Wait()
		waitDone <- struct{}{}
	}()

	select {
	case <-waitDone:
		break
	case err := <-errCh:
		return err
	}

	return nil
}
