package generator

import "fmt"

func (s *ServiceGenerator) clients(data ServiceGeneratorData) error {
	if err := s.writeToPathForResource(data.resourceOutputPath, "client.go", clientsAutoRestTemplater{}, data); err != nil {
		return fmt.Errorf("templating client: %+v", err)
	}

	return nil
}
