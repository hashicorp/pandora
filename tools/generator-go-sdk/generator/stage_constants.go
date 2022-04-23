package generator

import (
	"fmt"
)

func (s *ServiceGenerator) constants(data ServiceGeneratorData) error {
	if len(data.constants) == 0 {
		return nil
	}

	if err := s.writeToPath(data.outputPath, "constants.go", constantsTemplater{}, data); err != nil {
		return fmt.Errorf("templating constants: %+v", err)
	}

	return nil
}
