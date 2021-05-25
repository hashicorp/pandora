package generator

import (
	"fmt"
	"strings"
)

func (s *ServiceGenerator) ids(data ServiceGeneratorData) error {
	outputDirectory := data.outputPath
	packageName := data.packageName

	if data.useIdAliases {
		outputDirectory = data.idsOutputPath
		packageName = "ids"
	}

	for idName, idFormat := range data.resourceIds {
		nameWithoutSuffix := strings.TrimSuffix(idName, "Id") // we suffix 'Id' and 'ID' in places
		fileNamePrefix := strings.ToLower(nameWithoutSuffix)
		if err := s.writeToPath(outputDirectory, fmt.Sprintf("id_%s.go", fileNamePrefix), idParserTemplater{
			name:        nameWithoutSuffix,
			format:      idFormat,
			packageName: packageName,
		}, data); err != nil {
			return fmt.Errorf("templating ids: %+v", err)
		}

		if err := s.writeToPath(outputDirectory, fmt.Sprintf("id_%s_test.go", fileNamePrefix), idParserTestsTemplater{
			name:        nameWithoutSuffix,
			format:      idFormat,
			packageName: packageName,
		}, data); err != nil {
			return fmt.Errorf("templating tests for id: %+v", err)
		}
	}

	return nil
}
