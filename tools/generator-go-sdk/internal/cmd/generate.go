// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package cmd

import (
	"context"
	"flag"
	"fmt"
	"log"
	"os"
	"path"
	"path/filepath"
	"strings"
	"sync"

	v1 "github.com/hashicorp/pandora/tools/data-api-sdk/v1"
	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	"github.com/hashicorp/pandora/tools/generator-go-sdk/internal/generator"
	"github.com/hashicorp/pandora/tools/generator-go-sdk/internal/logging"
	"github.com/mitchellh/cli"
)

var _ cli.Command = GenerateCommand{}

type GenerateCommand struct {
	sourceDataType models.SourceDataType
}

type GeneratorInput struct {
	apiServerEndpoint string
	outputDirectory   string
	services          []string
	settings          generator.Settings
}

const commonTypesPackageName = "common-types"

func NewGenerateCommand(sourceDataType models.SourceDataType) func() (cli.Command, error) {
	return func() (cli.Command, error) {
		return GenerateCommand{
			sourceDataType: sourceDataType,
		}, nil
	}
}

func (g GenerateCommand) Help() string {
	// TODO: expand with commands
	return "Generates a Go SDK based on the API Definitions from the Data API"
}

func (g GenerateCommand) Run(args []string) int {
	ctx := context.Background()

	input := GeneratorInput{
		settings: generator.Settings{
			CommonTypesPackageName: commonTypesPackageName,
		},
	}

	if g.sourceDataType == models.MicrosoftGraphSourceDataType {
		input.settings.AllowOmittingDiscriminatedValue = true
		input.settings.DeleteExistingResourcesForVersion = true
		input.settings.GenerateDescriptionsForModels = true
		input.settings.RecurseParentModels = false

		input.settings.CanonicalApiVersions = map[string]string{
			"stable": "v1.0",
		}

		input.settings.VersionsToGenerateCommonTypes = map[string]models.SourceDataOrigin{
			"stable": models.MicrosoftGraphMetaDataSourceDataOrigin,
			"beta":   models.MicrosoftGraphMetaDataSourceDataOrigin,
		}
	} else if g.sourceDataType == models.ResourceManagerSourceDataType {
		input.settings.AllowOmittingDiscriminatedValue = false
		input.settings.DeleteExistingResourcesForVersion = false
		input.settings.GenerateDescriptionsForModels = false
		input.settings.RecurseParentModels = true

		input.settings.UseOldBaseLayerFor(
			// @tombuildsstuff: New Services should now use the `hashicorp/go-azure-sdk` base layer by default
			// instead of the base layer from `Azure/go-autorest` - as such this list is for compatibility purposes
			// with services already used in `terraform-provider-azurerm`. These services will be gradually removed
			// from this list to ensure they're migrated across to using `hashicorp/go-azure-sdk`s base layer.

			"FrontDoor",
			"RecoveryServicesBackup", // error: generating Service "RecoveryServicesBackup" / Version "2023-04-01" / Resource "Operation": generating methods: templating methods (using hashicorp/go-azure-sdk): templating: building methods: building response struct template: existing model "ValidateOperationResponse" conflicts with the operation response model for "Validate"
			"Subscription",

			// @tombuildsstuff: The Key Vault API has an issue where it requires that the EXACT casing returned in the Response
			// is sent in the Request to update or remove a Key Vault Access Policy - and using other casings mean the update
			// or removal fails - which is tracked in https://github.com/hashicorp/pandora/issues/3229.
			//
			// After testing, it appears that `2023-07-01` doesn't suffer from this problem - as such we're going to leave
			// `2023-02-01` on the older base layer and use the newer API Version as a divide to give us a clear migration path.
			"KeyVault@2023-02-01",
		)
	}

	var serviceNames string

	f := flag.NewFlagSet("generator-go-sdk", flag.ExitOnError)
	f.StringVar(&input.apiServerEndpoint, "data-api", "http://localhost:8080", "-data-api=http://localhost:8080")
	f.StringVar(&input.outputDirectory, "output-dir", "", "-output-dir=../generated-sdk-dev")
	f.StringVar(&serviceNames, "services", "", "A list of comma separated Service named from the Data API to generate")
	if err := f.Parse(args); err != nil {
		log.Fatalf("parsing arguments: %+v", err)
	}

	if serviceNames != "" {
		input.services = strings.Split(serviceNames, ",")
	}

	if input.outputDirectory == "" {
		homeDir, _ := os.UserHomeDir()
		input.outputDirectory = filepath.Join(homeDir, "/Desktop/generated-sdk-dev")
	}

	if err := g.run(ctx, input); err != nil {
		log.Fatalf("running generator: %+v", err)
	}

	return 0
}

func (g GenerateCommand) Synopsis() string {
	return "Generates a Go SDK based on the API Definitions from the Data API"
}

func (g GenerateCommand) run(ctx context.Context, input GeneratorInput) error {
	// output into a directory named after the source data type (e.g. `{dir}/resource-manager`)
	input.outputDirectory = path.Join(input.outputDirectory, string(g.sourceDataType))

	client := v1.NewClient(input.apiServerEndpoint, g.sourceDataType)
	data, err := client.LoadAllData(ctx, input.services)
	if err != nil {
		return fmt.Errorf("retrieving API Definitions: %+v", err)
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

	gen := generator.NewGenerator(input.settings)

	for serviceName, service := range data.Services {
		logging.Debugf("Service %q", serviceName)
		if !service.Generate {
			logging.Debug(".. is opted out of generation, skipping..")
			continue
		}

		wg.Add(1)
		go func(serviceName string, service models.Service, input GeneratorInput) {
			defer wg.Done()
			var err error

			logging.Debugf("Service %q", serviceName)
			for versionNumber, versionDetails := range service.APIVersions {
				logging.Debugf("   Version %q", versionNumber)

				var commonTypes models.CommonTypes
				if v, ok := data.CommonTypes[versionNumber]; ok {
					commonTypes = v
				}

				if input.settings.DeleteExistingResourcesForVersion {
					logging.Debugf("Deleting existing definitions for Service %q / Version %q", serviceName, versionNumber)
					servicePackageName := strings.ToLower(serviceName)
					versionDirectoryName := strings.ToLower(versionNumber)
					versionOutputPath := filepath.Join(input.outputDirectory, servicePackageName, versionDirectoryName)
					if err = generator.CleanAndRecreateWorkingDirectory(versionOutputPath); err != nil {
						addErr(fmt.Errorf("cleaning/recreating working directory %q: %+v", versionOutputPath, err))
						return
					}
				}

				for resourceName, resourceDetails := range versionDetails.Resources {
					logging.Debugf("      Resource %q", resourceName)
					serviceGeneratorInput := generator.ServiceGeneratorInput{
						CommonTypes:     commonTypes,
						OutputDirectory: input.outputDirectory,
						ResourceDetails: resourceDetails,
						ResourceName:    resourceName,
						ServiceDetails:  service,
						ServiceName:     serviceName,
						Source:          versionDetails.Source,
						Type:            g.sourceDataType,
						VersionDetails:  versionDetails,
						VersionName:     versionNumber,
					}
					logging.Debugf("Generating Service %q / Version %q / Resource %q", serviceName, versionNumber, resourceName)
					if err = gen.Generate(serviceGeneratorInput); err != nil {
						addErr(fmt.Errorf("generating Service %q / Version %q / Resource %q: %+v", serviceName, versionNumber, resourceName, err))
						return
					}
					logging.Debugf("Generated Service %q / Version %q / Resource %q", serviceName, versionNumber, resourceName)
				}

				// then output the Meta Client
				versionGeneratorInput := generator.VersionGeneratorInput{
					OutputDirectory: input.outputDirectory,
					CommonTypes:     commonTypes,
					ServiceName:     serviceName,
					VersionName:     versionNumber,
					Resources:       versionDetails.Resources,
					Source:          versionDetails.Source,
					Type:            g.sourceDataType,
				}
				versionGeneratorInput.UseNewBaseLayer = false
				if input.settings.ShouldUseNewBaseLayer(serviceName, versionNumber) {
					versionGeneratorInput.UseNewBaseLayer = true
				}
				logging.Debugf("Generating Service %q / Version %q", serviceName, versionNumber)
				if err = gen.GenerateForVersion(versionGeneratorInput); err != nil {
					addErr(fmt.Errorf("generating Service %q / Version %q: %+v", serviceName, versionNumber, err))
					return
				}
				logging.Debugf("Generated Service %q / Version %q", serviceName, versionNumber)
			}
		}(serviceName, service, input)
	}

	for versionNumber, source := range input.settings.VersionsToGenerateCommonTypes {
		wg.Add(1)
		go func(versionNumber string, source models.SourceDataOrigin, input GeneratorInput) {
			defer wg.Done()
			var err error

			commonTypes, ok := data.CommonTypes[versionNumber]
			if !ok {
				logging.Debugf("No Common Types Found / Version %q", versionNumber)
				return
			}

			// then output Common Types
			generatorData := generator.VersionGeneratorInput{
				OutputDirectory: input.outputDirectory,
				CommonTypes:     commonTypes,
				VersionName:     versionNumber,
				Source:          source,
				Type:            g.sourceDataType,
				UseNewBaseLayer: true,
			}
			logging.Debugf("Generating Common Types / Version %q", versionNumber)
			if err = gen.GenerateCommonTypes(generatorData); err != nil {
				addErr(fmt.Errorf("generating Common Types / Version %q: %+v", versionNumber, err))
				return
			}
			logging.Debugf("Generated Common Types / Version %q", versionNumber)
		}(versionNumber, source, input)
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
