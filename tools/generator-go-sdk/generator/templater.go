package generator

import (
	"fmt"
	"os"
	"path/filepath"
)

type templater interface {
	template(data ServiceGeneratorData) (*string, error)
}

func (s *ServiceGenerator) writeToPath(filePath string, templater templater, data ServiceGeneratorData) error {
	fileContents, err := templater.template(data)
	if err != nil {
		return fmt.Errorf("templating: %+v", err)
	}

	fullFilePath := filepath.Join(data.outputPath, filePath)

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
