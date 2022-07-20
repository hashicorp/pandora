package identification

import (
	"strings"

	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/components/resources"

	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
	"github.com/hashicorp/pandora/tools/sdk/services"
)

type CandidateDetails = resources.CandidateDetails

func FindCandidates(details services.Resource) CandidateDetails {
	out := resources.CandidateDetails{
		DataSources: []resources.DataSourceCandidate{},
		Resources:   []resources.ResourceCandidate{},
	}

	for resourceIdName, resourceId := range details.Schema.ResourceIds {
		// common resources shouldn't be generated
		if resourceId.CommonAlias != nil {
			continue
		}
		// no point
		if resourceId.Segments[0].Type == resourcemanager.ScopeSegment {
			continue
		}

		//hasCreate := false
		//hasDelete := false
		//hasUpdate := false
		//hasRead := false
		hasList := false
		hasSuffixedMethods := false

		var createMethod *resources.OperationMetaData
		var updateMethod *resources.OperationMetaData
		var deleteMethod *resources.OperationMetaData
		var getMethod *resources.OperationMetaData

		for operationName, operation := range details.Operations.Operations {
			// if it's an operation on just a suffix we're not interested
			if operation.ResourceIdName == nil {
				continue
			}
			if *operation.ResourceIdName != resourceIdName {
				continue
			}

			if strings.EqualFold(operation.Method, "POST") || strings.EqualFold(operation.Method, "PUT") {
				createMethod = &resources.OperationMetaData{
					Name:   operationName,
					Method: operation,
				}
			}
			if strings.EqualFold(operation.Method, "PATCH") {
				updateMethod = &resources.OperationMetaData{
					Name:   operationName,
					Method: operation,
				}
			}
			if strings.EqualFold(operation.Method, "GET") {
				if operation.UriSuffix == nil {
					getMethod = &resources.OperationMetaData{
						Name:   operationName,
						Method: operation,
					}
				}

				if operation.FieldContainingPaginationDetails != nil {
					hasList = true
				}
			}
			if strings.EqualFold(operation.Method, "DELETE") {
				deleteMethod = &resources.OperationMetaData{
					Name:   operationName,
					Method: operation,
				}
			}
			if operation.UriSuffix != nil && !strings.EqualFold(operation.Method, "GET") {
				hasSuffixedMethods = true
			}
		}

		if getMethod != nil || hasList {
			out.DataSources = append(out.DataSources, resources.DataSourceCandidate{
				Singular:   getMethod != nil,
				Plural:     hasList,
				ResourceId: resourceId,
			})
		}
		if createMethod != nil && getMethod != nil && deleteMethod != nil {
			out.Resources = append(out.Resources, resources.ResourceCandidate{
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
