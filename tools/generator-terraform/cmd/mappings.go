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
	result, err := services.GetResourceManagerServicesByName(client, []string{"Resources"})
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
			mappings, err := mappings.NewResourceMappings(resourceDetails, apiResourceDetails.Schema)
			if err != nil {
				return fmt.Errorf("building mappings for Resource %q: %+v", resourceName, err)
			}

			createMappings := mappings.CodeForCreateMappings()
			log.Printf("Create Mappings:\n\n%s", createMappings)

			readMappings := mappings.CodeForReadMappings()
			log.Printf("Read Mappings:\n\n%s", readMappings)
		}
	}

	return nil
}
