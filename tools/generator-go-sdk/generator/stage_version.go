package generator

import "fmt"

func (s *ServiceGenerator) version(data ServiceGeneratorData) error {
	if err := s.writeToPath(data.outputPath, "version.go", versionTemplater{}, data); err != nil {
		return fmt.Errorf("templating version: %+v", err)
	}

	return nil
}

var _ templater = versionTemplater{}

type versionTemplater struct {
}

func (c versionTemplater) template(data ServiceGeneratorData) (*string, error) {
	template := fmt.Sprintf(`package %[1]s

import "fmt"

const defaultApiVersion = "%[2]s"

func userAgent() string {
	return fmt.Sprintf("pandora/%[1]s/%%s", defaultApiVersion)
}
`, data.packageName, data.apiVersion)
	return &template, nil
}
