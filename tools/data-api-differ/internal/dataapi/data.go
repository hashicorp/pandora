package dataapi

import (
	"fmt"
	"math/rand"

	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	"github.com/hashicorp/pandora/tools/data-api-differ/internal/log"
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

// ParseDataFromPath launches the Data API using inputPath as the API Definitions directory.
func ParseDataFromPath(dataApiBinary, inputPath string) (*Data, error) {
	port := randomPortNumber()
	log.Logger.Info("Launching Data API..")
	dataApi := newDataApiCmd(dataApiBinary, port, inputPath)
	if err := dataApi.launchAndWait(); err != nil {
		return nil, fmt.Errorf("launching the Data API: %+v", err)
	}
	defer dataApi.shutdown()

	// TODO: once the client is updated to take a `SourceData` argument - update this to target _ALL_ endpoints not just Resource Manager
	client := resourcemanager.NewResourceManagerClient(dataApi.endpoint)
	resourceManagerServices, err := populateResourceManagerServices(client)
	if err != nil {
		return nil, fmt.Errorf("populating Resource Manager Services: %+v", err)
	}

	return &Data{
		ResourceManagerServices: *resourceManagerServices,
	}, nil
}

// populateResourceManagerServices populates the list of Resource Manager Services from the Data API.
func populateResourceManagerServices(client resourcemanager.Client) (*map[string]ServiceData, error) {
	log.Logger.Info("Retrieving Services..")
	servicesResp, err := client.Services().Get()
	if err != nil {
		return nil, fmt.Errorf("retrieving Services: %+v", err)
	}

	// We need to obtain and then flatten this data - arguably this could/should live in the SDK - but that's a question
	// for another day.
	log.Logger.Trace("Processing Services..")
	services := make(map[string]ServiceData)
	for serviceName, serviceSummary := range *servicesResp {
		log.Logger.Trace(fmt.Sprintf("Populating Details for Service %q..", serviceName))
		service, err := populateServiceDetails(client, serviceSummary)
		if err != nil {
			return nil, fmt.Errorf("populating the Service Details for %q: %+v", serviceName, err)
		}

		services[serviceName] = *service
	}

	return &services, nil
}

// populateServiceDetails populates ServiceData for the specified Service.
func populateServiceDetails(client resourcemanager.Client, summary resourcemanager.ServiceSummary) (*ServiceData, error) {
	serviceDetails, err := client.ServiceDetails().Get(summary)
	if err != nil {
		return nil, fmt.Errorf("retrieving details: %+v", err)
	}

	apiVersions := make(map[string]ApiVersionData)
	for apiVersion, versionSummary := range serviceDetails.Versions {
		log.Logger.Trace(fmt.Sprintf("Populating Details for API Version %q..", apiVersion))
		apiVersionDetails, err := populateApiVersionDetails(client, versionSummary)
		if err != nil {
			return nil, fmt.Errorf("populating details for API Version %q: %+v", apiVersion, err)
		}
		apiVersions[apiVersion] = *apiVersionDetails
	}

	return &ServiceData{
		ApiVersions:          apiVersions,
		Generate:             summary.Generate,
		ResourceProvider:     pointer.To(serviceDetails.ResourceProvider),
		TerraformPackageName: serviceDetails.TerraformPackageName,
	}, nil
}

// populateApiVersionDetails populates ApiVersionData for this API Version.
func populateApiVersionDetails(client resourcemanager.Client, summary resourcemanager.ServiceVersion) (*ApiVersionData, error) {
	resp, err := client.ServiceVersion().Get(summary)
	if err != nil {
		return nil, fmt.Errorf("retrieving details: %+v", err)
	}

	resources := make(map[string]ApiResourceData)
	for resourceName, resourceDetails := range resp.Resources {
		log.Logger.Trace(fmt.Sprintf("Populating details for API Resource %q..", resourceName))
		resource, err := populateApiResourceDetails(client, resourceDetails)
		if err != nil {
			return nil, fmt.Errorf("populating details for API Resource %q: %+v", resourceName, err)
		}
		resources[resourceName] = *resource
	}

	return &ApiVersionData{
		Generate:  summary.Generate,
		Preview:   summary.Preview,
		Resources: resources,
		Source:    resp.Source,
	}, nil
}

// populateApiResourceDetails populates ApiResourceData (containing the Operations and Schema) for the specified API Resource.
func populateApiResourceDetails(client resourcemanager.Client, details resourcemanager.ResourceSummary) (*ApiResourceData, error) {
	log.Logger.Trace("Retrieving API Operation Details..")
	operationsResp, err := client.ApiOperations().Get(details)
	if err != nil {
		return nil, fmt.Errorf("retrieving API Operation details: %+v", err)
	}

	log.Logger.Trace("Retrieving API Schema Details..")
	schemaResp, err := client.ApiSchema().Get(details)
	if err != nil {
		return nil, fmt.Errorf("retrieving API Schema details: %+v", err)
	}

	return &ApiResourceData{
		Constants:   schemaResp.Constants,
		Models:      schemaResp.Models,
		ResourceIds: schemaResp.ResourceIds,
		Operations:  operationsResp.Operations,
	}, nil
}

// randomPortNumber returns a random port number - this allows launching a unique instance each time
func randomPortNumber() int {
	return rand.Intn(50000-10000) + 10000
}
