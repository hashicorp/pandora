package pipeline

import (
	"fmt"
	"os"
	"testing"

	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/components/discovery"

	"github.com/hashicorp/go-hclog"
	"github.com/hashicorp/pandora/tools/sdk/config/definitions"
)

const (
	outputDirectory       = "../../../data/"
	swaggerDirectory      = "../../../swagger"
	resourceManagerConfig = "../../../config/resource-manager.hcl"
)

func TestExistingDataCanBeGenerated(t *testing.T) {
	// works around the OAIGen bug
	os.Setenv("OAIGEN_DEDUPE", "false")

	resources := definitions.Config{
		Services: map[string]definitions.ServiceDefinition{},
	}
	input := discovery.FindServiceInput{
		SwaggerDirectory: swaggerDirectory,
		ConfigFilePath:   resourceManagerConfig,
		OutputDirectory:  outputDirectory,
		Logger:           hclog.New(hclog.DefaultOptions),
	}
	generationData, err := discovery.FindServices(input, resources)
	if err != nil {
		t.Fatalf("building generation data: %+v", err)
	}

	for _, data := range *generationData {
		t.Run(fmt.Sprintf("%s-%s", data.ServiceName, data.ApiVersion), func(t *testing.T) {
			generationData := data

			task := pipelineTask{}
			if _, err := task.parseDataForApiVersion(generationData, hclog.New(hclog.DefaultOptions)); err != nil {
				t.Fatalf("error: %+v", err)
			}
		})
	}
}
