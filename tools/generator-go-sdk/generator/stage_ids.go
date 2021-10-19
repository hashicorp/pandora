package generator

import (
	"fmt"
	"os"
	"path/filepath"
	"strings"
)

func (s *ServiceGenerator) ids(data ServiceGeneratorData) error {
	outputDirectory := data.outputPath

	// For each package we first write the utils
	// This is temporary until the util code gets merged to the azure-helpers repo
	utilFilePath := filepath.Join(outputDirectory, "id_util.go")
	// remove any existing file if it exists
	_ = os.Remove(utilFilePath)
	file, err := os.Create(utilFilePath)
	if err != nil {
		return fmt.Errorf("opening %q: %+v", utilFilePath, err)
	}
	defer file.Close()
	_, _ = file.WriteString(fmt.Sprintf(utilString, data.packageName))

	for idName, resourceData := range data.resourceIds {
		if len(resourceData.Segments) == 0 {
			continue
		}
		nameWithoutSuffix := strings.TrimSuffix(idName, "Id") // we suffix 'Id' and 'ID' in places
		fileNamePrefix := strings.ToLower(nameWithoutSuffix)
		pt := resourceId{
			name:            idName,
			resource:        resourceData,
			constantDetails: data.constants,
		}
		if err := s.writeToPath(outputDirectory, fmt.Sprintf("id_%s.go", fileNamePrefix), pt, data); err != nil {
			return fmt.Errorf("templating ids: %+v", err)
		}

		tpt := idCustomParserTestsTemplater{
			resourceName:    idName,
			resourceData:    resourceData,
			constantDetails: data.constants,
		}
		if err := s.writeToPath(outputDirectory, fmt.Sprintf("id_%s_test.go", fileNamePrefix), tpt, data); err != nil {
			return fmt.Errorf("templating tests for id: %+v", err)
		}
	}

	return nil
}
