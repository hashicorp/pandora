package resourcemanager

import (
	"net/http"

	"github.com/go-chi/render"
	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	"github.com/hashicorp/pandora/tools/data-api/models"
)

func operationsForApiResource(w http.ResponseWriter, r *http.Request) {
	payload := models.ApiOperationDetails{
		Operations: map[string]models.ApiOperation{
			"Get": {
				ContentType: pointer.To("application/json"),
				ExpectedStatusCodes: []int{
					http.StatusOK,
				},
				LongRunning:    false,
				Method:         http.MethodGet,
				RequestObject:  nil,
				ResourceIdName: nil,
				ResponseObject: &models.ApiObjectDefinition{
					ReferenceName: pointer.To("Computa"),
					Type:          models.ReferenceApiObjectDefinitionType,
				},
				FieldContainingPaginationDetails: nil,
				Options:                          nil,
				UriSuffix:                        nil,
			},
		},
	}
	render.JSON(w, r, payload)
}
