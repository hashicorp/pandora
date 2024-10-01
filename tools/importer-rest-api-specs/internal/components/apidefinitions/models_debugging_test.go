package apidefinitions

import (
	"testing"

	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	discoveryModels "github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/components/discovery/models"
)

func TestDebugSingleSwaggerFile(t *testing.T) {
	t.Skipf("This is intended to be used for debugging a single API Definition")
	input := discoveryModels.AvailableDataSetForAPIVersion{
		APIVersion:               "2023-05-01",
		ContainsStableAPIVersion: false,
		FilePathsContainingAPIDefinitions: []string{
			"/path/to/submodules/rest-api-specs/specification/storagecache/resource-manager/Microsoft.StorageCache/stable/2023-05-01/amlfilesystem.json",
		},
	}
	result, err := parseAPIVersion("StorageCache", input, pointer.To("Microsoft.StorageCache"))
	if err != nil {
		t.Fatalf(err.Error())
	}
	t.Logf("Got %d APIResources", len(result.Resources))
}
