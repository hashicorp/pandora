package generator

import (
	"fmt"
	"strings"
)

func (s *ServiceGenerator) methods(data ServiceGeneratorData) error {
	for operationName, operation := range data.operations {

		if data.useNewBaseLayer {
			fileName := fmt.Sprintf("method_%s.go", strings.ToLower(operationName))
			gen := methodsPandoraTemplater{
				operationName: operationName,
				operation:     operation,
				constants:     data.constants,
			}
			if err := s.writeToPathForResource(data.resourceOutputPath, fileName, gen, data); err != nil {
				return fmt.Errorf("templating methods (using hashicorp/go-azure-sdk): %+v", err)
			}
		} else {
			fileName := fmt.Sprintf("method_%s_autorest.go", strings.ToLower(operationName))
			gen := methodsAutoRestTemplater{
				operationName: operationName,
				operation:     operation,
				constants:     data.constants,
			}
			if err := s.writeToPathForResource(data.resourceOutputPath, fileName, gen, data); err != nil {
				return fmt.Errorf("templating methods (using autorest): %+v", err)
			}
		}
	}

	return nil
}
