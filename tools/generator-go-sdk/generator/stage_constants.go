package generator

import (
	"fmt"
)

func (s *ServiceGenerator) constants(data ServiceGeneratorData) error {
	if len(data.constants) == 0 {
		return nil
	}

	t := constantsTemplater{
		constantTemplateFunc: templateForConstant,
	}
	if err := s.writeToPathForResource(data.resourceOutputPath, "templater_constants.go", t, data); err != nil {
		return fmt.Errorf("templating constants: %+v", err)
	}

	return nil
}
