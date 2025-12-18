// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package cmd

import (
	"context"
	"flag"
	"fmt"
	"log"
	"os"
	"path/filepath"
	"strings"

	v1 "github.com/hashicorp/pandora/tools/data-api-sdk/v1"
	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	"github.com/hashicorp/pandora/tools/generator-terraform/internal/generator"
	"github.com/hashicorp/pandora/tools/generator-terraform/internal/logging"
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

	apiServerEndpoint string
	providerPrefix    string
	outputDirectory   string
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
	ctx := context.Background()
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

	if err := i.run(ctx); err != nil {
		log.Printf("error: %+v", err)
		return 1
	}

	return 0
}

func (i *GenerateCommand) run(ctx context.Context) error {
	// ensure the output directory exists
	_ = os.MkdirAll(i.outputDirectory, 0755)

	client := v1.NewClient(i.apiServerEndpoint, i.sourceDataType)
	health, err := client.Health(ctx)
	if err != nil {
		return fmt.Errorf("checking if the Data API is available: %+v", err)
	}
	if !health.Available {
		return fmt.Errorf("the Data API was not available")
	}

	var servicesToLoad []string
	logging.Log.Info("Loading API Definitions from the Data API..")
	if i.serviceNamesRaw != "" {
		servicesToLoad = strings.Split(i.serviceNamesRaw, ",")
		logging.Log.Warn(fmt.Sprintf("Limiting the Services to [%s]..", i.serviceNamesRaw))
	}
	data, err := client.LoadAllData(ctx, servicesToLoad)
	if err != nil {
		return fmt.Errorf("loading API Definitions: %+v", err)
	}

	if err := generator.RunLegacy(*data, i.providerPrefix, i.outputDirectory); err != nil {
		return err
	}

	return nil
}

func (*GenerateCommand) Synopsis() string {
	return "Generates the Terraform Data Sources & Resources"
}
