package generator

import (
	"fmt"
	"strings"
)

func (s *ServiceGenerator) methods(data ServiceGeneratorData) error {
	if s.settings.Transport != AutoRest {
		return fmt.Errorf("only the AutoRest transport is supported at this time")
	}

	for operationName, operation := range data.operations {
		fileName := fmt.Sprintf("method_%s_autorest.go", strings.ToLower(operationName))
		gen := methodsAutoRestTemplater{
			operationName: operationName,
			operation:     operation,
		}
		if err := s.writeToPath(fileName, gen, data); err != nil {
			return fmt.Errorf("templating methods (using autorest): %+v", err)
		}
	}

	return nil
}
