package identification

import (
	"strings"

	"github.com/hashicorp/pandora/tools/schema-playground/models"
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
	"github.com/hashicorp/pandora/tools/sdk/services"
)

type CandidateDetails struct {
	DataSources []models.DataSourceCandidate
	Resources   []models.ResourceCandidate
}

func FindCandidates(details services.Resource) (*CandidateDetails, error) {
	out := CandidateDetails{
		DataSources: []models.DataSourceCandidate{},
		Resources:   []models.ResourceCandidate{},
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

		var createMethod *models.OperationMetaData
		var updateMethod *models.OperationMetaData
		var deleteMethod *models.OperationMetaData
		var getMethod *models.OperationMetaData

		for operationName, operation := range details.Operations.Operations {
			// if it's an operation on just a suffix we're not interested
			if operation.ResourceIdName == nil {
				continue
			}
			if *operation.ResourceIdName != resourceIdName {
				continue
			}

			if strings.EqualFold(operation.Method, "POST") || strings.EqualFold(operation.Method, "PUT") {
				createMethod = &models.OperationMetaData{
					Name:   operationName,
					Method: operation,
				}
			}
			if strings.EqualFold(operation.Method, "PATCH") {
				updateMethod = &models.OperationMetaData{
					Name:   operationName,
					Method: operation,
				}
			}
			if strings.EqualFold(operation.Method, "GET") {
				if operation.UriSuffix == nil {
					getMethod = &models.OperationMetaData{
						Name:   operationName,
						Method: operation,
					}
				}

				if operation.FieldContainingPaginationDetails != nil {
					hasList = true
				}
			}
			if strings.EqualFold(operation.Method, "DELETE") {
				deleteMethod = &models.OperationMetaData{
					Name:   operationName,
					Method: operation,
				}
			}
			if operation.UriSuffix != nil && !strings.EqualFold(operation.Method, "GET") {
				hasSuffixedMethods = true
			}
		}

		if getMethod != nil || hasList {
			out.DataSources = append(out.DataSources, models.DataSourceCandidate{
				Singular:   getMethod != nil,
				Plural:     hasList,
				ResourceId: resourceId,
			})
		}
		if createMethod != nil && getMethod != nil && deleteMethod != nil {
			out.Resources = append(out.Resources, models.ResourceCandidate{
				CreateMethod:       createMethod,
				UpdateMethod:       updateMethod,
				DeleteMethod:       deleteMethod,
				GetMethod:          getMethod,
				HasSuffixedMethods: hasSuffixedMethods,
				ResourceId:         resourceId,
			})
		}
	}

	return &out, nil
}
