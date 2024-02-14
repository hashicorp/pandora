// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package cmd

import (
	"flag"
	"fmt"
	"log"
	"os"
	"path/filepath"
	"strings"

	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	"github.com/hashicorp/pandora/tools/generator-terraform/internal/generator"
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
	"github.com/hashicorp/pandora/tools/sdk/services"
	"github.com/mitchellh/cli"
)

var _ cli.Command = &GenerateCommand{}

func NewGenerateCommand(sourceDataType models.SourceDataType) func() (cli.Command, error) {
	return func() (cli.Command, error) {
		return &GenerateCommand{
			sourceDataType: sourceDataType,
		}, nil
	}
}

type GenerateCommand struct {
	sourceDataType models.SourceDataType

	providerPrefix    string
	outputDirectory   string
	apiServerEndpoint string
	serviceNamesRaw   string
}

func (*GenerateCommand) Help() string {
	return strings.ReplaceAll(`Generates the Terraform Data Sources & Resources using the Data from the Data API

Flags:

* '--data-api=https://example.com'
  Specifies the path to the Data API.
* '--output-dir=../generated-tf-dev'
  Specifies the path where the generated files should be output
* '--services=Example1,Example2'
  Specifies a comma-separated list of services to import, rather than the full set.
`, "'", "`")
}

func (i *GenerateCommand) Run(args []string) int {
	// no point making this configurable (right now anyway)
	i.providerPrefix = "azurerm"

	f := flag.NewFlagSet("generator-terraform", flag.ExitOnError)
	f.StringVar(&i.apiServerEndpoint, "data-api", "http://localhost:8080", "-data-api=http://localhost:8080")
	f.StringVar(&i.outputDirectory, "output-dir", "", "-output-dir=../generated-tf-dev")
	f.StringVar(&i.serviceNamesRaw, "services", "", "A list of comma separated Service named from the Data API to import")
	if err := f.Parse(args); err != nil {
		log.Fatalf("parsing arguments: %+v", err)
	}

	if i.outputDirectory == "" {
		homeDir, _ := os.UserHomeDir()
		i.outputDirectory = filepath.Join(homeDir, "/Desktop/generated-tf-dev")
	}

	if err := i.run(); err != nil {
		log.Printf("error: %+v", err)
		return 1
	}

	return 0
}

func (i *GenerateCommand) run() error {
	// ensure the output directory exists
	_ = os.MkdirAll(i.outputDirectory, 0755)

	log.Printf("[DEBUG] Retrieving Services from Data API..")
	client := resourcemanager.NewResourceManagerClient(i.apiServerEndpoint)
	var loadedServices services.ResourceManagerServices
	servicesToLoad := strings.Split(i.serviceNamesRaw, ",")
	if i.serviceNamesRaw != "" && len(servicesToLoad) > 0 {
		log.Printf("[DEBUG] Loading the Services %q..", strings.Join(servicesToLoad, " / "))
		services, err := services.GetResourceManagerServicesByName(client, servicesToLoad)
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

	if err := generator.RunLegacy(loadedServices, i.providerPrefix, i.outputDirectory); err != nil {
		return err
	}

	return nil
}

func (*GenerateCommand) Synopsis() string {
	return "Generates the Terraform Data Sources & Resources"
}
