package resources

import (
	"strings"

	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
	"github.com/hashicorp/pandora/tools/sdk/services"
)

type CandidateDetails struct {
	// DataSources is a slice of the potential DataSources identified for this Service
	DataSources []DataSourceCandidate

	// Resources is a slice of the potential Resources identified for this Service
	Resources []ResourceCandidate
}

// FindCandidates returns a list of candidate Data Sources and Resources
// within the specified Service
func FindCandidates(input services.Resource) CandidateDetails {
	out := CandidateDetails{
		DataSources: []DataSourceCandidate{},
		Resources:   []ResourceCandidate{},
	}

	for resourceIdName, resourceId := range input.Schema.ResourceIds {
		// common resources shouldn't be generated
		if resourceId.CommonAlias != nil {
			continue
		}
		// no point
		if resourceId.Segments[0].Type == resourcemanager.ScopeSegment {
			continue
		}

		hasList := false
		hasSuffixedMethods := false

		var createMethod *OperationMetaData
		var updateMethod *OperationMetaData
		var deleteMethod *OperationMetaData
		var getMethod *OperationMetaData

		for operationName, operation := range input.Operations.Operations {
			// if it's an operation on just a suffix we're not interested
			if operation.ResourceIdName == nil {
				continue
			}
			if *operation.ResourceIdName != resourceIdName {
				continue
			}

			if strings.EqualFold(operation.Method, "POST") || strings.EqualFold(operation.Method, "PUT") {
				createMethod = &OperationMetaData{
					Name:   operationName,
					Method: operation,
				}
			}
			if strings.EqualFold(operation.Method, "PATCH") {
				updateMethod = &OperationMetaData{
					Name:   operationName,
					Method: operation,
				}
			}
			if strings.EqualFold(operation.Method, "GET") {
				if operation.UriSuffix == nil {
					getMethod = &OperationMetaData{
						Name:   operationName,
						Method: operation,
					}
				}

				if operation.FieldContainingPaginationDetails != nil {
					hasList = true
				}
			}
			if strings.EqualFold(operation.Method, "DELETE") {
				deleteMethod = &OperationMetaData{
					Name:   operationName,
					Method: operation,
				}
			}
			if operation.UriSuffix != nil && !strings.EqualFold(operation.Method, "GET") {
				hasSuffixedMethods = true
			}
		}

		if getMethod != nil || hasList {
			out.DataSources = append(out.DataSources, DataSourceCandidate{
				Singular:   getMethod != nil,
				Plural:     hasList,
				ResourceId: resourceId,
			})
		}
		if createMethod != nil && getMethod != nil && deleteMethod != nil {
			out.Resources = append(out.Resources, ResourceCandidate{
				CreateMethod:       createMethod,
				UpdateMethod:       updateMethod,
				DeleteMethod:       deleteMethod,
				GetMethod:          getMethod,
				HasSuffixedMethods: hasSuffixedMethods,
				ResourceId:         resourceId,
			})
		}
	}

	return out
}
