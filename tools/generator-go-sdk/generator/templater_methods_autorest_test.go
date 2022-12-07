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
	}.responderTemplate("GetOperationResponse", input)

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
			return result, fmt.Errorf("reading response body for PandaPop: %+v", err)
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

func TestTemplateMethodsAutoRestBaseTypePredicates(t *testing.T) {
	input := ServiceGeneratorData{
		packageName:       "chubbyPandas",
		serviceClientName: "pandaClient",
		source:            AccTestLicenceType,
		resourceIds: map[string]resourcemanager.ResourceIdDefinition{
			"PandaPop": {
				Id: "LingLing",
			},
		},
	}

	actual, err := methodsAutoRestTemplater{
		operation: resourcemanager.ApiOperation{
			Method: "GET",
			ResponseObject: &resourcemanager.ApiObjectDefinition{
				Type: resourcemanager.StringApiObjectDefinitionType,
			},
			ResourceIdName: stringPointer("PandaPop"),
			ContentType:    stringPointer("text/powershell"),
		},
		operationName: "List",
	}.listOperationTemplate(input)

	if err != nil {
		t.Fatalf("err %+v", err)
	}

	expected := `
type ListOperationResponse struct {
	HttpResponse *http.Response
	Model *string
}

// List ...
func (c pandaClient) List(ctx context.Context, id PandaPop) (resp ListOperationResponse, err error) {
	req, err := c.preparerForList(ctx, id)
	if err != nil {
		err = autorest.NewErrorWithError(err, "chubbyPandas.pandaClient", "List", nil, "Failure preparing request")
		return
	}

	resp.HttpResponse, err = c.Client.Send(req, azure.DoRetryWithRegistration(c.Client))
	if err != nil {
		err = autorest.NewErrorWithError(err, "chubbyPandas.pandaClient", "List", resp.HttpResponse, "Failure sending request")
		return
	}

	resp, err = c.responderForList(resp.HttpResponse)
	if err != nil {
		err = autorest.NewErrorWithError(err, "chubbyPandas.pandaClient", "List", resp.HttpResponse, "Failure responding to request")
		return
	}
	return
}

// preparerForList prepares the List request.
	func (c pandaClient) preparerForList(ctx context.Context, id PandaPop) (*http.Request, error) {
		queryParameters := map[string]interface{}{
			"api-version": defaultApiVersion,
		}
		preparer := autorest.CreatePreparer(
		autorest.AsContentType("text/powershell"),
		autorest.AsGet(),
		autorest.WithBaseURL(c.baseUri),
		autorest.WithPath(id.ID()),
		autorest.WithQueryParameters(queryParameters))
		return preparer.Prepare((&http.Request{}).WithContext(ctx))
	}

// responderForList handles the response to the List request. The method always
// closes the http.Response Body.
func (c pandaClient) responderForList(resp *http.Response) (result ListOperationResponse, err error) {
	var content []byte
	err = autorest.Respond(
		resp,
		azure.WithErrorUnlessStatusCode(),
		autorest.ByUnmarshallingBytes(&content),
		autorest.ByClosing())
	str := string(content)
	result.Model = &str
	result.HttpResponse = resp
	return
}

// ListComplete retrieves all of the results into a single object
func (c pandaClient) ListComplete(ctx context.Context, id PandaPop) (result ListCompleteResult, err error) {
	items := make([]string, 0)

	page, err := c.List(ctx, id)
	if err != nil {
		err = fmt.Errorf("loading the initial page: %+v", err)
		return
	}
	if page.Model != nil {
		for _, v := range *page.Model {
			items = append(items, v)
		}
	}

	for page.HasMore() {
		page, err = page.LoadMore(ctx)
		if err != nil {
			err = fmt.Errorf("loading the next page: %+v", err)
			return
		}

		if page.Model != nil {
			for _, v := range *page.Model {
				items = append(items, v)
			}
		}
	}

	out := ListCompleteResult{
		Items: items,
	}
	return out, nil
}
`
	assertTemplatedCodeMatches(t, expected, *actual)
}

func TestTemplateMethodsAutoRestNonBaseTypePredicates(t *testing.T) {
	input := ServiceGeneratorData{
		packageName:       "chubbyPandas",
		serviceClientName: "pandaClient",
		source:            AccTestLicenceType,
		resourceIds: map[string]resourcemanager.ResourceIdDefinition{
			"PandaPop": {
				Id: "LingLing",
			},
		},
	}

	actual, err := methodsAutoRestTemplater{
		operation: resourcemanager.ApiOperation{
			Method: "GET",
			ResponseObject: &resourcemanager.ApiObjectDefinition{
				Type:          resourcemanager.ReferenceApiObjectDefinitionType,
				ReferenceName: stringPointer("LingLing"),
			},
			ResourceIdName: stringPointer("PandaPop"),
		},
		operationName: "List",
	}.listOperationTemplate(input)

	if err != nil {
		t.Fatalf("err %+v", err)
	}

	expected := `
type ListOperationResponse struct {
	HttpResponse *http.Response
	Model *LingLing
}

// List ...
func (c pandaClient) List(ctx context.Context, id PandaPop) (resp ListOperationResponse, err error) {
	req, err := c.preparerForList(ctx, id)
	if err != nil {
		err = autorest.NewErrorWithError(err, "chubbyPandas.pandaClient", "List", nil, "Failure preparing request")
		return
	}

	resp.HttpResponse, err = c.Client.Send(req, azure.DoRetryWithRegistration(c.Client))
	if err != nil {
		err = autorest.NewErrorWithError(err, "chubbyPandas.pandaClient", "List", resp.HttpResponse, "Failure sending request")
		return
	}

	resp, err = c.responderForList(resp.HttpResponse)
	if err != nil {
		err = autorest.NewErrorWithError(err, "chubbyPandas.pandaClient", "List", resp.HttpResponse, "Failure responding to request")
		return
	}
	return
}

// preparerForList prepares the List request.
	func (c pandaClient) preparerForList(ctx context.Context, id PandaPop) (*http.Request, error) {
		queryParameters := map[string]interface{}{
			"api-version": defaultApiVersion,
		}
		preparer := autorest.CreatePreparer(
		autorest.AsGet(),
		autorest.WithBaseURL(c.baseUri),
		autorest.WithPath(id.ID()),
		autorest.WithQueryParameters(queryParameters))
		return preparer.Prepare((&http.Request{}).WithContext(ctx))
	}

// responderForList handles the response to the List request. The method always
// closes the http.Response Body.
func (c pandaClient) responderForList(resp *http.Response) (result ListOperationResponse, err error) {
	err = autorest.Respond(
		resp,
		azure.WithErrorUnlessStatusCode(),
		autorest.ByUnmarshallingJSON(&result.Model),
		autorest.ByClosing())
	result.HttpResponse = resp
	return
}

// ListComplete retrieves all of the results into a single object
func (c pandaClient) ListComplete(ctx context.Context, id PandaPop) (ListCompleteResult, error) {
	return c.ListCompleteMatchingPredicate(ctx, id, LingLingOperationPredicate{})
}

// ListCompleteMatchingPredicate retrieves all of the results and then applied the predicate
func (c pandaClient) ListCompleteMatchingPredicate(ctx context.Context, id PandaPop, predicate LingLingOperationPredicate) (resp ListCompleteResult, err error) {
	items := make([]LingLing, 0)

	page, err := c.List(ctx, id)
	if err != nil {
		err = fmt.Errorf("loading the initial page: %+v", err)
		return
	}
	if page.Model != nil {
		for _, v := range *page.Model {
			if predicate.Matches(v) {
				items = append(items, v)
			}
		}
	}

	for page.HasMore() {
		page, err = page.LoadMore(ctx)
		if err != nil {
			err = fmt.Errorf("loading the next page: %+v", err)
			return
		}

		if page.Model != nil {
			for _, v := range *page.Model {
				if predicate.Matches(v) {
					items = append(items, v)
				}
			}
		}
	}

	out := ListCompleteResult{
		Items: items,
	}
	return out, nil
}
`
	assertTemplatedCodeMatches(t, expected, *actual)

}
