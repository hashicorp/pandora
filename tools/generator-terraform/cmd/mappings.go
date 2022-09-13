package cmd

import (
	"log"

	"github.com/hashicorp/pandora/tools/sdk/services"

	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"

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

	client := resourcemanager.NewClient("http://localhost:5000")
	result, err := services.GetResourceManagerServicesByName(client, []string{"Resources"})
	if err != nil {
		log.Printf("error: %+v", err)
		return 1
	}

	for serviceName, serviceDetails := range result.Services {
		log.Printf("[DEBUG] Service %q", serviceName)
		for resourceName, resourceDetails := range serviceDetails.Terraform.Resources {
			log.Printf("[DEBUG] Resource Name %q", resourceName)

			for _, mapping := range resourceDetails.Mappings.Create {
				log.Printf("mapping: %+v", mapping)
			}
		}
	}

	return 0
}

func (m MappingsCommand) Synopsis() string {
	return "Outputs Mappings for Development"
}
