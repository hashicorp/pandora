package generator

import (
	"fmt"
	"os"
	"strings"
)

func writeToFile(fileName, fileContents string) error {
	existing, err := os.Open(fileName)
	if os.IsExist(err) {
		return fmt.Errorf("existing file exists at %q", fileName)
	}
	existing.Close()

	file, err := os.Create(fileName)
	if err != nil {
		return fmt.Errorf("creating %q: %+v", fileName, err)
	}

	file.WriteString(fileContents)
	file.Close()
	return nil
}

func (g PandoraDefinitionGenerator) normalizeApiVersion() string {
	normalized := strings.ReplaceAll(g.apiVersion, "-", "_") // e.g. 2020-01-01-preview -> 2020_01_01_preview
	normalized = strings.ReplaceAll(normalized, ".", "_")    // e.g. 1.0 -> 1_0
	return fmt.Sprintf("v%s", normalized)
}

func (g PandoraDefinitionGenerator) namespace(resourceName string) string {
	normalizedApiVersion := g.normalizeApiVersion()
	return fmt.Sprintf("%s.%s.%s.%s", g.rootNamespace, strings.Title(g.serviceName), normalizedApiVersion, strings.Title(resourceName))
}
