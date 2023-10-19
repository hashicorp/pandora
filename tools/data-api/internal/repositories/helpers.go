package repositories

import (
	"fmt"
	"io"
	"os"
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
		return nil, fmt.Errorf("loading %q", path)
	}

	defer contents.Close()

	byteValue, err := io.ReadAll(contents)
	if err != nil {
		return nil, fmt.Errorf("reading contents of %q", path)
	}

	return &byteValue, nil
}

// getDefinitionInfo transforms the file names in the api definitions directory into a definition type and a name e.g.
// Model-KeyVaultProperties.json -> type = Model and name = KeyVaultProperties
func getDefinitionInfo(fileName string) (string, string, error) {
	if !strings.HasSuffix(fileName, ".json") {
		return "", "", fmt.Errorf("file %q has an extensions not supported by the data api", fileName)
	}
	splitName := strings.Split(fileName, "-")

	definitionType := splitName[0]
	definitionName := strings.Split(splitName[1], ".")[0]

	return definitionType, definitionName, nil

}

// getTerraformDefinitionInfo transforms the file names in the api definitions directory into a name and aTerraform Definition type  e.g.
// LoadTest-Resource.json -> name = LoadTest and type = Resource
func getTerraformDefinitionInfo(fileName string) (string, string, error) {
	if !strings.HasSuffix(fileName, ".json") {
		return "", "", fmt.Errorf("file %q has an extensions not supported by the data api", fileName)
	}
	splitName := strings.Split(fileName, "-")

	definitionName := splitName[0]
	definitionType := strings.Split(splitName[1], ".")[0]

	return definitionName, definitionType, nil

}
