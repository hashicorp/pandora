package generator

import (
	"testing"

	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

func TestTemplateMethodsLROCreate(t *testing.T) {
	input := ServiceGeneratorData{
		packageName:       "skinnyPandas",
		serviceClientName: "pandaClient",
		source:            AccTestLicenceType,
		resourceIds: map[string]resourcemanager.ResourceIdDefinition{
			"PandaPop": {
				Id: "LingLing",
			},
		},
	}

	actual, err := methodsPandoraTemplater{
		operation: resourcemanager.ApiOperation{
			ExpectedStatusCodes: []int{201, 202},
			LongRunning:         true,
			Method:              "PUT",
			RequestObject: &resourcemanager.ApiObjectDefinition{
				Type: resourcemanager.StringApiObjectDefinitionType,
			},
			ResourceIdName: stringPointer("PandaPop"),
		},
		operationName: "Create",
	}.longRunningOperationTemplate(input)

	if err != nil {
		t.Fatalf("err %+v", err)
	}

	expected := `
type CreateOperationResponse struct {
	Poller pollers.Poller
	HttpResponse *http.Response
	OData *odata.OData
}

// Create ...
func (c pandaClient) Create(ctx context.Context , id PandaPop, input string) (result CreateOperationResponse, err error) {
	opts := client.RequestOptions{
		ContentType: "application/json",
		ExpectedStatusCodes: []int{
			http.StatusAccepted,
			http.StatusCreated,
		},
		HttpMethod: http.MethodPut,
		Path: id.ID(),
	}

	req, err := c.Client.NewRequest(ctx, opts)
	if err != nil {
		return
	}

	if err = req.Marshal(input); err != nil {
		return
	}

	var resp *client.Response
	resp, err = req.Execute(ctx)
	if resp != nil {
		result.OData = resp.OData
		result.HttpResponse = resp.Response
	}
	if err != nil {
		return
	}

	result.Poller, err = resourcemanager.PollerFromResponse(resp, c.Client)
	if err != nil {
		return
	}

	return
}

// CreateThenPoll performs Create then polls until it's completed
func (c pandaClient) CreateThenPoll(ctx context.Context , id PandaPop, input string) error {
	result, err := c.Create(ctx , id, input)
	if err != nil {
		return fmt.Errorf("performing Create: %+v", err)
	}

	if err := result.Poller.PollUntilDone(ctx); err != nil {
		return fmt.Errorf("polling after Create: %+v", err)
	}

	return nil
}
`
	assertTemplatedCodeMatches(t, expected, *actual)
}

func TestTemplateMethodsLROReboot(t *testing.T) {
	input := ServiceGeneratorData{
		packageName:       "skinnyPandas",
		serviceClientName: "pandaClient",
		source:            AccTestLicenceType,
		resourceIds: map[string]resourcemanager.ResourceIdDefinition{
			"PandaPop": {
				Id: "LingLing",
			},
		},
	}

	actual, err := methodsPandoraTemplater{
		operation: resourcemanager.ApiOperation{
			ExpectedStatusCodes: []int{200},
			LongRunning:         true,
			Method:              "POST",
			ResourceIdName:      stringPointer("PandaPop"),
		},
		operationName: "Reboot",
	}.longRunningOperationTemplate(input)

	if err != nil {
		t.Fatalf("err %+v", err)
	}

	expected := `
type RebootOperationResponse struct {
	Poller pollers.Poller
	HttpResponse *http.Response
	OData *odata.OData
}

// Reboot ...
func (c pandaClient) Reboot(ctx context.Context , id PandaPop) (result RebootOperationResponse, err error) {
	opts := client.RequestOptions{
		ContentType: "application/json",
		ExpectedStatusCodes: []int{
			http.StatusOK,
		},
		HttpMethod: http.MethodPost,
		Path: id.ID(),
	}

	req, err := c.Client.NewRequest(ctx, opts)
	if err != nil {
		return
	}
	var resp *client.Response
	resp, err = req.Execute(ctx)
	if resp != nil {
		result.OData = resp.OData
		result.HttpResponse = resp.Response
	}
	if err != nil {
	return
	}

	result.Poller, err = resourcemanager.PollerFromResponse(resp, c.Client)
	if err != nil {
		return
	}

	return
}

// RebootThenPoll performs Reboot then polls until it's completed
func (c pandaClient) RebootThenPoll(ctx context.Context , id PandaPop) error {
	result, err := c.Reboot(ctx , id)
	if err != nil {
		return fmt.Errorf("performing Reboot: %+v", err)
	}

	if err := result.Poller.PollUntilDone(ctx); err != nil {
		return fmt.Errorf("polling after Reboot: %+v", err)
	}

	return nil
}
`
	assertTemplatedCodeMatches(t, expected, *actual)
}

func TestTemplateMethodsLRODoesNotCallUnmarshal(t *testing.T) {
	// Long Running Operations may have a ResponseObject defined - however we shouldn't be
	// calling Unmarshal on the initial HTTP Response (since it MAY or MAY NOT contain a
	// payload depending on the API/status code).
	//
	// As such this test asserts that we don't call `Unmarshal` prior to creating the LRO
	// Poller - since (for the moment) consumers will need to decide when `Unmarshal` should
	// be called on the LRO Result, if needed at all.
	input := ServiceGeneratorData{
		packageName:       "skinnyPandas",
		serviceClientName: "pandaClient",
		source:            AccTestLicenceType,
		models: map[string]resourcemanager.ModelDetails{
			"Example": {
				Fields: map[string]resourcemanager.FieldDetails{
					"First": {
						Required: true,
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type: resourcemanager.StringApiObjectDefinitionType,
						},
						JsonName: "first",
					},
				},
			},
		},
		resourceIds: map[string]resourcemanager.ResourceIdDefinition{
			"PandaPop": {
				Id: "LingLing",
			},
		},
	}

	actual, err := methodsPandoraTemplater{
		operation: resourcemanager.ApiOperation{
			ExpectedStatusCodes: []int{200, 202},
			LongRunning:         true,
			Method:              "PUT",
			RequestObject: &resourcemanager.ApiObjectDefinition{
				Type:          resourcemanager.ReferenceApiObjectDefinitionType,
				ReferenceName: stringPointer("Example"),
			},
			ResponseObject: &resourcemanager.ApiObjectDefinition{
				Type:          resourcemanager.ReferenceApiObjectDefinitionType,
				ReferenceName: stringPointer("Example"),
			},
			ResourceIdName: stringPointer("PandaPop"),
		},
		operationName: "Create",
	}.longRunningOperationTemplate(input)

	if err != nil {
		t.Fatalf("err %+v", err)
	}

	expected := `
type CreateOperationResponse struct {
	Poller pollers.Poller
	HttpResponse *http.Response
	OData *odata.OData
	Model *Example
}

// Create ...
func (c pandaClient) Create(ctx context.Context , id PandaPop, input Example) (result CreateOperationResponse, err error) {
	opts := client.RequestOptions{
		ContentType: "application/json",
		ExpectedStatusCodes: []int{
			http.StatusAccepted,
			http.StatusOK,
		},
		HttpMethod: http.MethodPut,
		Path: id.ID(),
	}

	req, err := c.Client.NewRequest(ctx, opts)
	if err != nil {
		return
	}

	if err = req.Marshal(input); err != nil {
		return
	}

	var resp *client.Response
	resp, err = req.Execute(ctx)
	if resp != nil {
		result.OData = resp.OData
		result.HttpResponse = resp.Response
	}
	if err != nil {
		return
	}

	result.Poller, err = resourcemanager.PollerFromResponse(resp, c.Client)
	if err != nil {
		return
	}

	return
}

// CreateThenPoll performs Create then polls until it's completed
func (c pandaClient) CreateThenPoll(ctx context.Context , id PandaPop, input Example) error {
	result, err := c.Create(ctx , id, input)
	if err != nil {
		return fmt.Errorf("performing Create: %+v", err)
	}

	if err := result.Poller.PollUntilDone(ctx); err != nil {
		return fmt.Errorf("polling after Create: %+v", err)
	}

	return nil
}
`
	assertTemplatedCodeMatches(t, expected, *actual)
}
