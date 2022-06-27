package generator

import (
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
	"testing"
)

func TestTemplateMethodsAutoRestLRODelete(t *testing.T) {
	input := ServiceGeneratorData{
		packageName:       "chubbyPandas",
		serviceClientName: "pandaClient",
		source:            AccTestLicenceType,
	}

	actual := methodsAutoRestTemplater{
		operation: resourcemanager.ApiOperation{
			Method: "DELETE",
		},
		operationName: "Delete",
	}.senderLongRunningOperationTemplate(input)

	expected := `
// senderForDelete sends the Delete request. The method will close the
// http.Response Body if it receives an error.
func (c pandaClient) senderForDelete(ctx context.Context, req *http.Request) (future DeleteOperationResponse, err error) {
	var resp *http.Response
	resp, err = c.Client.Send(req, azure.DoRetryWithRegistration(c.Client))
	if err != nil {
		return
	}
	
	future.Poller, err = polling.NewLongRunningPollerFromResponse(ctx, resp, c.Client)
	if !response.WasNotFound(future.Poller.HttpResponse) {
		return future, err
    }
	return
}
`
	assertTemplatedCodeMatches(t, expected, actual)
}

func TestTemplateMethodsAutoRestLROCreate(t *testing.T) {
	input := ServiceGeneratorData{
		packageName:       "chubbyPandas",
		serviceClientName: "pandaClient",
		source:            AccTestLicenceType,
	}

	actual := methodsAutoRestTemplater{
		operation: resourcemanager.ApiOperation{
			Method: "PUT",
		},
		operationName: "Create",
	}.senderLongRunningOperationTemplate(input)

	expected := `
// senderForCreate sends the Create request. The method will close the
// http.Response Body if it receives an error.
func (c pandaClient) senderForCreate(ctx context.Context, req *http.Request) (future CreateOperationResponse, err error) {
	var resp *http.Response
	resp, err = c.Client.Send(req, azure.DoRetryWithRegistration(c.Client))
	if err != nil {
		return
	}
	
	future.Poller, err = polling.NewLongRunningPollerFromResponse(ctx, resp, c.Client)
	
	return
}
`
	assertTemplatedCodeMatches(t, expected, actual)
}
