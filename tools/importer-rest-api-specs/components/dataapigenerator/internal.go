package dataapigenerator

import (
	"fmt"
	"path"
	"strings"
)

type generationData struct {
	ServiceName           string
	ApiVersion            string
	ApiVersionPackageName string

	NamespaceForService    string
	NamespaceForApiVersion string
	NamespaceForTerraform  string

	WorkingDirectoryForService    string
	WorkingDirectoryForApiVersion string
	WorkingDirectoryForTerraform  string
	ResourceProvider              *string
	TerraformPackageName          *string
}

func (d generationData) namespaceForResource(resourceName string) string {
	return fmt.Sprintf("%s.%s", d.NamespaceForApiVersion, d.packageNameForResource(resourceName))
}

func (d generationData) packageNameForResource(resourceName string) string {
	return strings.Title(resourceName)
}

func (d generationData) workingDirectoryForResource(resource string) string {
	dir := d.WorkingDirectoryForApiVersion
	return path.Join(dir, resource)
}
