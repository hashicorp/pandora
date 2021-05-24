package generator

import (
	"fmt"
	"strings"
)

func (s *ServiceGenerator) ids(data ServiceGeneratorData) error {
	for idName, idFormat := range data.resourceIds {
		nameWithoutSuffix := strings.TrimSuffix(idName, "Id") // we suffix 'Id' and 'ID' in places
		fileNamePrefix := strings.ToLower(nameWithoutSuffix)
		if err := s.writeToPath(fmt.Sprintf("id_%s.go", fileNamePrefix), idParserTemplater{
			name:   nameWithoutSuffix,
			format: idFormat,
		}, data); err != nil {
			return fmt.Errorf("templating ids: %+v", err)
		}

		if err := s.writeToPath(fmt.Sprintf("id_%s_test.go", fileNamePrefix), idParserTestsTemplater{
			name:   nameWithoutSuffix,
			format: idFormat,
		}, data); err != nil {
			return fmt.Errorf("templating tests for id: %+v", err)
		}
	}

	return nil
}
