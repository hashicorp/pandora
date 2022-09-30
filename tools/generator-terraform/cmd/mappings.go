package cmd

import (
	"fmt"
	"log"

	"github.com/hashicorp/pandora/tools/generator-terraform/generator/mappings"
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
	"github.com/hashicorp/pandora/tools/sdk/services"
	"github.com/mitchellh/cli"
)

var _ cli.Command = MappingsCommand{}

func NewMappingsCommand() func() (cli.Command, error) {
	return func() (command cli.Command, err error) {
		return MappingsCommand{}, nil
	}
}

type MappingsCommand struct {
}

func (m MappingsCommand) Help() string {
	return "Outputs Mappings for Development"
}

func (m MappingsCommand) Run(args []string) int {
	/*
		Both Expand and Flatten should ultimately use the same function, just with a different means of getting the arguments
		* Use consistent variable names for input and output (e.g. `output.Foo = input.Bar` / `output.Foo = SomeMappingFunction(input.Bar)`)
		* Where a flatten function is involved

		* A struct for each of the "mapping types" (e.g. direct assignment) which has two methods, codeForExpand(topLevel bool)
	*/
	log.Printf("nada")

	if err := m.run(); err != nil {
		log.Printf("error: %+v", err)
		return 1
	}

	return 0
}

func (m MappingsCommand) Synopsis() string {
	return "Outputs Mappings for Development"
}

func (m MappingsCommand) run() error {
	client := resourcemanager.NewClient("http://localhost:5000")
	result, err := services.GetResourceManagerServicesByName(client, []string{"ChaosStudio"})
	if err != nil {
		return fmt.Errorf("retrieving Resource Manager Services: %+v", err)
	}

	for serviceName, serviceDetails := range result.Services {
		log.Printf("[DEBUG] Service %q", serviceName)
		for resourceName, resourceDetails := range serviceDetails.Terraform.Resources {
			log.Printf("[DEBUG] Resource Name %q", resourceName)

			apiVersionDetails, ok := serviceDetails.Versions[resourceDetails.ApiVersion]
			if !ok {
				return fmt.Errorf("API Version %q was not found for Service %q", resourceDetails.ApiVersion, serviceName)
			}

			apiResourceDetails, ok := apiVersionDetails.Resources[resourceDetails.Resource]
			if !ok {
				return fmt.Errorf("API Resource %q was not found within API Version %q / Service %q", resourceDetails.Resource, resourceDetails.ApiVersion, serviceName)
			}

			/*
				The Create/Update/Read models should call a single method: map{SchemaModelName}To{SdkModelName} (and the inverse)
				Two components:
					1. Defines the method itself, for example `func mapFooToBar(input Foo, output *Bar) error {}`
					2. Maps the value from A to B

				For update we may need to patch a field on an existing model, however?
			*/

			helper := mappings.NewResourceMappings(resourceDetails, apiResourceDetails.Schema.Constants, apiResourceDetails.Schema.Models)
			for _, item := range resourceDetails.Mappings.ModelToModels {
				mappingsForThisModel, err := mappings.FindMappingsBetween(item, resourceDetails.Mappings.Fields)
				if err != nil {
					return fmt.Errorf("finding mappings between Schema Model %q and Sdk Model %q: %+v", item.SchemaModelName, item.SdkModelName, err)
				}
				if err != nil {
					return fmt.Errorf("building mappings for Resource %q: %+v", resourceName, err)
				}

				log.Printf("Schema Model %q <-> SDK Model %q", item.SchemaModelName, item.SdkModelName)
				schemaToSdkMappingLines, err := helper.SchemaModelToSdkModelAssignmentLine(*mappingsForThisModel)
				if err != nil {
					return fmt.Errorf("building schema - sdk mapping lines: %+v", err)
				}
				log.Printf("Schema <-> SDK Mappings:\n\n%s", *schemaToSdkMappingLines)

				sdkToSchemaMappingLines, err := helper.SdkModelToSchemaModelAssignmentLine(*mappingsForThisModel)
				if err != nil {
					return fmt.Errorf("building schema - sdk mapping lines: %+v", err)
				}
				log.Printf("SDK <-> Schema Mappings:\n\n%s", *sdkToSchemaMappingLines)
			}
		}
	}

	return nil
}
