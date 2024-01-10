package repositories

import (
	"fmt"
	"io"
	"log"
	"os"
	"strconv"
	"strings"
)

func listSubDirectories(path string) (*[]string, error) {
	directories := make([]string, 0)

	contents, err := os.ReadDir(path)
	if err != nil {
		return nil, fmt.Errorf("retrieving list of sub directories under %q: %+v", path, err)
	}

	for _, c := range contents {
		if c.IsDir() {
			directories = append(directories, c.Name())
		}
	}

	return &directories, nil
}

func loadJson(path string) (*[]byte, error) {
	contents, err := os.Open(path)
	if err != nil {
		return nil, fmt.Errorf("loading %q: %+v", path, err)
	}
	defer contents.Close()

	byteValue, err := io.ReadAll(contents)
	if err != nil {
		return nil, fmt.Errorf("reading contents of %q: %+v", path, err)
	}

	return &byteValue, nil
}

func loadHcl(path string) (string, error) {
	contents, err := os.Open(path)
	if err != nil {
		return "", fmt.Errorf("loading %q: %+v", path, err)
	}
	defer contents.Close()

	byteValue, err := io.ReadAll(contents)
	if err != nil {
		return "", fmt.Errorf("reading contents of %q: %+v", path, err)
	}

	return string(byteValue), nil
}

// getDefinitionInfo transforms the file names in the api definitions directory into a definition type and a name e.g.
// Model-KeyVaultProperties.json -> type = Model and name = KeyVaultProperties
func getDefinitionInfo(fileName string) (string, string, error) {
	if !strings.HasSuffix(fileName, ".json") {
		return "", "", fmt.Errorf("file %q has an extensions not supported by the data api", fileName)
	}
	splitName := strings.Split(strings.TrimSuffix(fileName, ".json"), "-")

	definitionType := splitName[0]
	definitionName := splitName[1]

	return definitionType, definitionName, nil

}

// getTerraformDefinitionInfo transforms the file names in the api definitions directory into a name and aTerraform Definition type  e.g.
// LoadTest-Resource.json -> name = LoadTest and type = Resource
func getTerraformDefinitionInfo(fileName string) (string, string, error) {
	if !strings.HasSuffix(fileName, ".json") {
		return "", "", fmt.Errorf("file %q has an extensions not supported by the data api", fileName)
	}
	splitName := strings.SplitN(fileName, "-", 2)

	definitionName := splitName[0]
	definitionType := strings.Split(splitName[1], ".")[0]

	// Resource-Schema Files can have multiple files with the model type appended to it (ie. KubernetesFleetManager-Resource-Schema-FleetHubProfile
	// that final piece of the final name is not used and can be safely ignored
	if strings.Contains(strings.ToLower(definitionType), "resource-schema") && len(strings.Split(definitionType, "-")) >= 3 {
		log.Printf("FileName: %s", fileName)
		definitionType = "Resource-Schema"
	}

	return definitionName, definitionType, nil

}

// getTerraformTestInfo transforms the file names in the Tests directory into a name, Terraform Definition type, Test Type  e.g.
// LoadTest-Resource.json -> name = LoadTest and type = Resource
func getTerraformTestInfo(fileName string) (string, string, string, error) {
	if !strings.HasSuffix(fileName, ".hcl") {
		return "", "", "", fmt.Errorf("file %q has an extensions not supported by the data api", fileName)
	}
	splitName := strings.SplitN(fileName, "-", 3)

	definitionName := splitName[0]
	definitionType := splitName[1]
	testType := strings.Split(splitName[2], ".")[0]

	return definitionName, definitionType, testType, nil

}

// getTerraformOtherTestInfo transforms an otherTestType into `Other`, TestName, and a TestNum  e.g.
// LoadTest-Resource-Other-Foo-2 -> testName = Foo and testNum = 2
func getTerraformOtherTestInfo(otherTestType string) (string, int, error) {
	splitName := strings.SplitN(otherTestType, "-", 4)
	if len(splitName) != 4 {
		return "", -1, fmt.Errorf("expected OtherTest to be split into format Other-Foo-2. Received: %+v", otherTestType)
	}

	testName := splitName[1]

	testNum, err := strconv.Atoi(splitName[2])
	if err != nil {
		return "", -1, fmt.Errorf("converting %s to int: %+v", splitName[2], err)
	}

	return testName, testNum, nil

}
