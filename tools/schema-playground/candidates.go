package main

import (
	"fmt"
	"log"
	"strings"

	"github.com/hashicorp/pandora/tools/schema-playground/identification"
	"github.com/hashicorp/pandora/tools/schema-playground/schema"
	"github.com/hashicorp/pandora/tools/sdk/config/definitions"
	"github.com/hashicorp/pandora/tools/sdk/services"
)

type CandidatesForService struct {
	ServiceName     string
	ApiVersion      string
	ResourceName    string
	Candidates      identification.CandidateDetails
	ResourceDetails services.Resource
}

func (c CandidatesForService) String() string {
	return fmt.Sprintf("Candidate %s", strings.Join([]string{
		fmt.Sprintf("Service %q", c.ServiceName),
		fmt.Sprintf("ApiVersion %q", c.ApiVersion),
		fmt.Sprintf("ResourceName %q", c.ResourceName),
	}, " / "))
}

func findCandidates(input services.ResourceManagerServices) (*[]CandidatesForService, error) {
	out := make([]CandidatesForService, 0)
	for serviceName, service := range input.Services {
		if !service.Details.Generate {
			continue
		}

		for apiVersion, versionDetails := range service.Versions {
			for resourceName, resourceDetails := range versionDetails.Resources {
				candidates, err := identification.FindCandidates(resourceDetails)
				if err != nil {
					return nil, fmt.Errorf("determining candidates for Service %q / Version %q / Resource %q: %+v", serviceName, apiVersion, resourceName, err)
				}

				if len(candidates.DataSources) == 0 && len(candidates.Resources) == 0 {
					continue
				}

				out = append(out, CandidatesForService{
					ServiceName:     serviceName,
					ApiVersion:      apiVersion,
					ResourceName:    resourceName,
					Candidates:      *candidates,
					ResourceDetails: resourceDetails,
				})
			}
		}
	}

	return &out, nil
}

func processSchemaForCandidate(input CandidatesForService, resourceDefinition map[string]definitions.ResourceDefinition) error {
	totalDataSources := 0
	totalResources := 0

	builder := schema.NewBuilder(input.ResourceDetails.Schema.Constants, input.ResourceDetails.Schema.Models, input.ResourceDetails.Schema.ResourceIds)
	if len(input.Candidates.DataSources) == 0 {
		log.Printf("[DEBUG] No Data Sources were found")
	}
	for _, dataSource := range input.Candidates.DataSources {
		var definition *definitions.ResourceDefinition
		for _, v := range resourceDefinition {
			if v.ID == dataSource.ResourceId.Id {
				definition = &v
				break
			}
		}
		if definition == nil {
			continue
		}

		totalDataSources++
		log.Printf("* Data Source: %s (Name %q)", dataSource, definition.Name)
	}

	if len(input.Candidates.Resources) == 0 {
		log.Printf("[DEBUG] No Resources were found")
	}
	for _, resource := range input.Candidates.Resources {
		var definition *definitions.ResourceDefinition
		for _, v := range resourceDefinition {
			if v.ID == resource.ResourceId.Id {
				definition = &v
				break
			}
		}
		if definition == nil {
			continue
		}

		totalResources++
		log.Printf("* Resources: %q (Name %q)", resource, definition.Name)

		schemaForResource, err := builder.Build(resource)
		if err != nil {
			return fmt.Errorf("building schema for %s: %+v", input, err)
		}
		if schemaForResource == nil {
			log.Printf("[DEBUG] resource doesn't appear to be applicable for Schema building - skipping")
			continue
		}
		for k, v := range schemaForResource.Fields {
			log.Printf("Schema Field %q: %v", k, v.String())
		}
	}
	log.Printf("\n\n")

	log.Printf("Summary - Total Resources %d - Data Sources %d", totalDataSources, totalResources)

	return nil
}
