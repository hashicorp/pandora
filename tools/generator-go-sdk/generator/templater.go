package generator

import (
	"fmt"
	"os"
	"path/filepath"
)

type templaterForResource interface {
	template(data ServiceGeneratorData) (*string, error)
}

type templaterForVersion interface {
	template() (*string, error)
}

func (s *ServiceGenerator) writeToPathForResource(directory, filePath string, templater templaterForResource, data ServiceGeneratorData) error {
	fileContents, err := templater.template(data)
	if err != nil {
		return fmt.Errorf("templating: %+v", err)
	}

	fullFilePath := filepath.Join(directory, filePath)

	// remove any existing file if it exists
	_ = os.Remove(fullFilePath)
	file, err := os.Create(fullFilePath)
	defer file.Close()
	if err != nil {
		return fmt.Errorf("opening %q: %+v", fullFilePath, err)
	}

	_, _ = file.WriteString(*fileContents)
	return nil
}

func (s *ServiceGenerator) writeToPathForVersion(directory, filePath string, templater templaterForVersion) error {
	fileContents, err := templater.template()
	if err != nil {
		return fmt.Errorf("templating: %+v", err)
	}

	fullFilePath := filepath.Join(directory, filePath)

	// remove any existing file if it exists
	_ = os.Remove(fullFilePath)
	file, err := os.Create(fullFilePath)
	defer file.Close()
	if err != nil {
		return fmt.Errorf("opening %q: %+v", fullFilePath, err)
	}

	_, _ = file.WriteString(*fileContents)
	return nil
}
