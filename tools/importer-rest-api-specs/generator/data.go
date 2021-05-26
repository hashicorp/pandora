package generator

import (
	"fmt"
	"path"
	"strings"
)

type GenerationData struct {
	ServiceName string
	ApiVersion  string

	NamespaceForService    string
	NamespaceForApiVersion string

	WorkingDirectoryForService    string
	WorkingDirectoryForApiVersion string
}

func GenerationDataForService(serviceName, apiVersion, rootDirectory, rootNamespace string) GenerationData {
	normalizedApiVersion := normalizeApiVersion(apiVersion)
	serviceNamespace := fmt.Sprintf("%s.%s", rootNamespace, strings.Title(serviceName))
	versionNamespace := fmt.Sprintf("%s.%s", serviceNamespace, normalizedApiVersion)

	serviceWorkingDirectory := path.Join(rootDirectory, strings.Title(serviceName))
	versionWorkingDirectory := path.Join(serviceWorkingDirectory, normalizedApiVersion)

	return GenerationData{
		ServiceName:                   serviceName,
		ApiVersion:                    apiVersion,
		NamespaceForService:           serviceNamespace,
		NamespaceForApiVersion:        versionNamespace,
		WorkingDirectoryForService:    serviceWorkingDirectory,
		WorkingDirectoryForApiVersion: versionWorkingDirectory,
	}
}

func (d GenerationData) NamespaceForResource(resourceName string) string {
	return fmt.Sprintf("%s.%s", d.NamespaceForApiVersion, strings.Title(resourceName))
}

func (d GenerationData) WorkingDirectoryForResource(resource string) string {
	dir := d.WorkingDirectoryForApiVersion
	return path.Join(dir, resource)
}
