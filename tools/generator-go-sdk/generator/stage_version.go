package generator

import "fmt"

func (s *ServiceGenerator) version(data ServiceGeneratorData) error {
	if err := s.writeToPath(data.outputPath, "version.go", versionTemplater{}, data); err != nil {
		return fmt.Errorf("templating version: %+v", err)
	}

	return nil
}
