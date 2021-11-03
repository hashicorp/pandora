package generator

import (
	"fmt"
	"strings"
)

func (s *ServiceGenerator) ids(data ServiceGeneratorData) error {
	outputDirectory := data.outputPath

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
