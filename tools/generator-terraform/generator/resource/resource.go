package resource

import (
	"bytes"
	"fmt"
	"os"

	"github.com/hashicorp/pandora/tools/generator-terraform/generator/models"
	"github.com/hashicorp/pandora/tools/generator-terraform/generator/resource/docs"
)

func Resource(input models.ResourceInput) error {
	// ensure the service directory exists
	serviceDirectory := fmt.Sprintf("%s/internal/services/%s", input.RootDirectory, input.ServicePackageName)
	os.MkdirAll(serviceDirectory, 0755)

	// Generate the Resource
	resourceFilePath := fmt.Sprintf("%s/%s_resource_gen.go", serviceDirectory, input.ResourceLabel)
	os.Remove(resourceFilePath)
	resourceCode, err := codeForResource(input)
	if err != nil {
		return fmt.Errorf("building code for resource: %+v", err)
	}
	writeToPath(resourceFilePath, *resourceCode)

	// then generate the Tests
	// skip overwrite if test file exists because auto-generated test configuration cannot work most time,
	// they need to be updated manually
	testFilePath := fmt.Sprintf("%s/%s_resource_gen_test.go", serviceDirectory, input.ResourceLabel)
	if !shouldSkipGenFile(testFilePath) {
		_ = os.Remove(testFilePath)
		testFileContents, err := componentsForResourceTest(input)
		if err != nil {
			return fmt.Errorf("building test code for resource: %+v", err)
		}
		writeToPath(testFilePath, *testFileContents)
	}

	// then generate the documentation
	websiteResourcesDirectory := fmt.Sprintf("%s/website/docs/r/", input.RootDirectory)
	documentationFilePath := fmt.Sprintf("%s/%s.html.markdown", websiteResourcesDirectory, input.ResourceLabel)
	if !shouldSkipGenFile(documentationFilePath) {
		os.MkdirAll(websiteResourcesDirectory, 0755)
		os.Remove(documentationFilePath)
		documentationForResource, err := docs.ComponentsForResource(input)
		if err != nil {
			return fmt.Errorf("building documentation for resource: %+v", err)
		}
		writeToPath(documentationFilePath, *documentationForResource)
	}

	return nil
}

// skip generate file if NOT CONTAINS 'manual changes will be overwritten' in file content
func shouldSkipGenFile(file string) bool {
	if f, err := os.Open(file); err == nil {
		var buf = make([]byte, 512)
		if _, err := f.Read(buf); err == nil {
			return !bytes.Contains(buf, []byte("manual changes will be overwritten"))
		}
	}
	return false
}
