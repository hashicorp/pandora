package generator

import (
	"testing"

	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
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
	
	future.Poller, err = polling.NewPollerFromResponse(ctx, resp, c.Client, req.Method)
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
	
	future.Poller, err = polling.NewPollerFromResponse(ctx, resp, c.Client, req.Method)
	
	return
}
`
	assertTemplatedCodeMatches(t, expected, actual)
}

func TestTemplateMethodAutoRestDiscriminatedTypeResponder(t *testing.T) {
	input := ServiceGeneratorData{
		packageName:       "chubbyPandas",
		serviceClientName: "pandaClient",
		source:            AccTestLicenceType,
		models: map[string]resourcemanager.ModelDetails{
			"PandaPop": {
				TypeHintIn: stringPointer("cola"),
			},
		},
	}

	actual, err := methodsAutoRestTemplater{
		operation: resourcemanager.ApiOperation{
			Method: "GET",
			ResponseObject: &resourcemanager.ApiObjectDefinition{
				ReferenceName: stringPointer("PandaPop"),
			},
		},
		operationName: "Get",
	}.responderTemplate(input)

	if err != nil {
		t.Fatalf("err %+v", err)
	}

	expected := `
	// responderForGet handles the response to the Get request. The method always
	// closes the http.Response Body.
	func (c pandaClient) responderForGet(resp *http.Response) (result GetOperationResponse, err error) {
		err = autorest.Respond(
			resp,
			azure.WithErrorUnlessStatusCode(),
			autorest.ByClosing())
		result.HttpResponse = resp
		b, err := ioutil.ReadAll(resp.Body)
		if err != nil {
			return result, fmt.Errorf("reading response body: PandaPop", err)
		}
		model, err := unmarshalPandaPopImplementation(b)
		if err != nil {
			return
        }
		result.Model = &model
		return
	}`

	assertTemplatedCodeMatches(t, expected, *actual)
}
