package generator

import (
	"fmt"
	"strings"
)

func (s *ServiceGenerator) models(data ServiceGeneratorData) error {
	if len(data.models) == 0 {
		return nil
	}

	for modelName, model := range data.models {
		// model_{name}.go
		// arguably we could enhance this to make `MyThing` be `my_thing` but this is fine for now
		fileName := fmt.Sprintf("model_%s.go", strings.ToLower(modelName))
		gen := modelsTemplater{
			name:  modelName,
			model: model,
		}
		if err := s.writeToPathForResource(data.resourceOutputPath, fileName, gen, data); err != nil {
			return fmt.Errorf("templating model for %q: %+v", modelName, err)
		}
	}

	return nil
}
