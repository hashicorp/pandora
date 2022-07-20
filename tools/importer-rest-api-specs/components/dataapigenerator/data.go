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

func generationDataForService(serviceName, rootDirectory, rootNamespace string, resourceProvider, terraformPackageName *string) generationData {
	normalisedServiceName := strings.ReplaceAll(serviceName, "-", "")
	serviceNamespace := fmt.Sprintf("%s.%s", rootNamespace, strings.Title(normalisedServiceName))
	serviceWorkingDirectory := path.Join(rootDirectory, rootNamespace, strings.Title(normalisedServiceName))
	terraformNamespace := fmt.Sprintf("%s.Terraform", serviceNamespace)
	terraformWorkingDirectory := path.Join(serviceWorkingDirectory, "Terraform")

	return generationData{
		NamespaceForService:          serviceNamespace,
		ResourceProvider:             resourceProvider,
		ServiceName:                  normalisedServiceName,
		TerraformPackageName:         terraformPackageName,
		NamespaceForTerraform:        terraformNamespace,
		WorkingDirectoryForService:   serviceWorkingDirectory,
		WorkingDirectoryForTerraform: terraformWorkingDirectory,
	}
}

func generationDataForServiceAndApiVersion(serviceName, apiVersion, rootDirectory, rootNamespace string, resourceProvider, terraformPackageName *string) generationData {
	normalizedApiVersion := normalizeApiVersion(apiVersion)
	data := generationDataForService(serviceName, rootDirectory, rootNamespace, resourceProvider, terraformPackageName)
	data.ApiVersion = apiVersion
	data.ApiVersionPackageName = normalizedApiVersion
	data.NamespaceForApiVersion = fmt.Sprintf("%s.%s", data.NamespaceForService, normalizedApiVersion)
	data.WorkingDirectoryForApiVersion = path.Join(data.WorkingDirectoryForService, normalizedApiVersion)
	return data
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
