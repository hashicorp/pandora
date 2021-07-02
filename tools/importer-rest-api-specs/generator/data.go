package generator

import (
	"fmt"
	"path"
	"strings"
)

type GenerationData struct {
	ServiceName   string
	ApiVersion    string
	SwaggerGitSha string

	NamespaceForService    string
	NamespaceForApiVersion string

	WorkingDirectoryForService    string
	WorkingDirectoryForApiVersion string
}

func GenerationDataForService(serviceName, rootDirectory, rootNamespace, swaggerGitSha string) GenerationData {
	normalisedServiceName := strings.ReplaceAll(serviceName, "-", "")
	serviceNamespace := fmt.Sprintf("%s.%s", rootNamespace, strings.Title(normalisedServiceName))
	serviceWorkingDirectory := path.Join(rootDirectory, rootNamespace, strings.Title(normalisedServiceName))

	return GenerationData{
		NamespaceForService:        serviceNamespace,
		ServiceName:                normalisedServiceName,
		SwaggerGitSha:              swaggerGitSha,
		WorkingDirectoryForService: serviceWorkingDirectory,
	}
}

func GenerationDataForServiceAndApiVersion(serviceName, apiVersion, rootDirectory, rootNamespace, swaggerGitSha string) GenerationData {
	normalizedApiVersion := normalizeApiVersion(apiVersion)
	data := GenerationDataForService(serviceName, rootDirectory, rootNamespace, swaggerGitSha)
	data.ApiVersion = apiVersion
	data.NamespaceForApiVersion = fmt.Sprintf("%s.%s", data.NamespaceForService, normalizedApiVersion)
	data.WorkingDirectoryForApiVersion = path.Join(data.WorkingDirectoryForService, normalizedApiVersion)
	return data
}

func (d GenerationData) NamespaceForResource(resourceName string) string {
	return fmt.Sprintf("%s.%s", d.NamespaceForApiVersion, strings.Title(resourceName))
}

func (d GenerationData) WorkingDirectoryForResource(resource string) string {
	dir := d.WorkingDirectoryForApiVersion
	return path.Join(dir, resource)
}
