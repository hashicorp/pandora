package generator

import (
	"fmt"
	"strings"
)

func (s *ServiceGenerator) ids(data ServiceGeneratorData) error {
	for idName, idFormat := range data.resourceIds {
		fileNamePrefix := strings.TrimSuffix(idName, "Id")
		fileNamePrefix = strings.ToLower(fileNamePrefix)
		if err := s.writeToPath(fmt.Sprintf("id_%s.go", fileNamePrefix), idParserTemplater{
			name:   idName,
			format: idFormat,
		}, data); err != nil {
			return fmt.Errorf("templating ids: %+v", err)
		}

		if err := s.writeToPath(fmt.Sprintf("id_%s_test.go", fileNamePrefix), idParserTestsTemplater{
			name:   idName,
			format: idFormat,
		}, data); err != nil {
			return fmt.Errorf("templating tests for id: %+v", err)
		}
	}

	return nil
}
