// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package generator

import (
	"fmt"
	"testing"

	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

// TODO: split the tests out into sub-groupings & add more coverage

func TestTemplateMethodsGet(t *testing.T) {
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
			Method:              "GET",
			ResourceIdName:      stringPointer("PandaPop"),
			ResponseObject: &resourcemanager.ApiObjectDefinition{
				Type: resourcemanager.StringApiObjectDefinitionType,
			},
		},
		operationName: "Get",
	}.immediateOperationTemplate(input)

	if err != nil {
		t.Fatalf("err %+v", err)
	}

	expected := `
type GetOperationResponse struct {
	HttpResponse *http.Response
	OData *odata.OData
	Model *string
}

// Get ...
func (c pandaClient) Get(ctx context.Context , id PandaPop) (result GetOperationResponse, err error) {
	opts := client.RequestOptions{
		ContentType: "application/json",
		ExpectedStatusCodes: []int{
			http.StatusOK,
		},
		HttpMethod: http.MethodGet,
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

	if err = resp.Unmarshal(&result.Model); err != nil {
		return
	}

	return
}
`
	assertTemplatedCodeMatches(t, expected, *actual)
}

func TestTemplateMethodsGetAsTextPowerShell(t *testing.T) {
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
			ContentType:         stringPointer("text/powershell"),
			ExpectedStatusCodes: []int{200},
			Method:              "GET",
			ResourceIdName:      stringPointer("PandaPop"),
			ResponseObject: &resourcemanager.ApiObjectDefinition{
				Type: resourcemanager.StringApiObjectDefinitionType,
			},
		},
		operationName: "Get",
	}.immediateOperationTemplate(input)

	if err != nil {
		t.Fatalf("err %+v", err)
	}

	expected := `
type GetOperationResponse struct {
	HttpResponse *http.Response
	OData *odata.OData
	Model *string
}

// Get ...
func (c pandaClient) Get(ctx context.Context , id PandaPop) (result GetOperationResponse, err error) {
	opts := client.RequestOptions{
		ContentType: "text/powershell",
		ExpectedStatusCodes: []int{
			http.StatusOK,
		},
		HttpMethod: http.MethodGet,
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

	if err = resp.Unmarshal(&result.Model); err != nil {
		return
	}

	return
}
`
	assertTemplatedCodeMatches(t, expected, *actual)
}

// NOTE: List Operations differ slightly depending on the Response Object.
// * When the Response Object is a Model or a List (of a Model) we include support for predicate filtering.
// * When the Response Object is a Simple Type (e.g. int/string) we don't.
// As such these tests (whilst similar) cover the two different code paths.

func TestTemplateMethodsListWithDiscriminatedType(t *testing.T) {
	input := ServiceGeneratorData{
		packageName:       "chubbyPandas",
		serviceClientName: "pandaClient",
		source:            AccTestLicenceType,
		models: map[string]resourcemanager.ModelDetails{
			"Bottle": {
				Fields: map[string]resourcemanager.FieldDetails{
					"Type": {
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type: resourcemanager.StringApiObjectDefinitionType,
						},
						Required: true,
					},
				},
				ParentTypeName: nil,
				TypeHintIn:     pointer.To("Type"),
				TypeHintValue:  nil,
			},
			"MilkBottle": {
				Fields: map[string]resourcemanager.FieldDetails{
					"Size": {
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type: resourcemanager.StringApiObjectDefinitionType,
						},
						Required: true,
					},
				},
				ParentTypeName: pointer.To("Bottle"),
				TypeHintIn:     pointer.To("Type"),
				TypeHintValue:  pointer.To("Milk"),
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
			ExpectedStatusCodes:              []int{200},
			FieldContainingPaginationDetails: stringPointer("nextLink"),
			Method:                           "GET",
			ResponseObject: &resourcemanager.ApiObjectDefinition{
				Type:          resourcemanager.ReferenceApiObjectDefinitionType,
				ReferenceName: stringPointer("Bottle"),
			},
			ResourceIdName: stringPointer("PandaPop"),
			UriSuffix:      stringPointer("/pandas"),
		},
		operationName: "List",
	}.listOperationTemplate(input)

	if err != nil {
		t.Fatalf("err %+v", err)
	}

	expected := fmt.Sprintf(`
type ListOperationResponse struct {
	HttpResponse *http.Response
    OData *odata.OData
	Model *[]Bottle
}

type ListCompleteResult struct {
	LatestHttpResponse *http.Response
	Items []Bottle
}

// List ...
func (c pandaClient) List(ctx context.Context , id PandaPop) (result ListOperationResponse, err error) {
	opts := client.RequestOptions{
		ContentType: "application/json",
		ExpectedStatusCodes: []int{
			http.StatusOK,
		},
		HttpMethod: http.MethodGet,
		Path: fmt.Sprintf("%%s/pandas", id.ID()),
	}

	req, err := c.Client.NewRequest(ctx, opts)
	if err != nil {
		return
	}

	var resp *client.Response
	resp, err = req.ExecutePaged(ctx)
	if resp != nil {
		result.OData = resp.OData
		result.HttpResponse = resp.Response
	}

	if err != nil {
		return
	}

	var values struct {
		Values *[]json.RawMessage %[1]s
	}
	if err = resp.Unmarshal(&values); err != nil {
		return
	}

	temp := make([]Bottle, 0)
	if values.Values != nil {
		for i, v := range *values.Values {
			val, err := unmarshalBottleImplementation(v)
			if err != nil {
				err = fmt.Errorf("unmarshalling item %%d for Bottle (%%q): %%+v", i, v, err)
				return result, err
			}
			temp = append(temp, val)
		}
	}
	result.Model = &temp

	return
}

// ListComplete retrieves all the results into a single object
func (c pandaClient) ListComplete(ctx context.Context, id PandaPop) (ListCompleteResult, error) {
	return c.ListCompleteMatchingPredicate(ctx, id, BottleOperationPredicate{})
}

// ListCompleteMatchingPredicate retrieves all the results and then applies the predicate
func (c pandaClient) ListCompleteMatchingPredicate(ctx context.Context, id PandaPop, predicate BottleOperationPredicate) (result ListCompleteResult, err error) {
	items := make([]Bottle, 0)

	resp, err := c.List(ctx, id)
	if err != nil {
		err = fmt.Errorf("loading results: %%+v", err)
		return
	}
	if resp.Model != nil {
		for _, v := range *resp.Model {
			if predicate.Matches(v) {
				items = append(items, v)
			}
		}
	}

	result = ListCompleteResult{
		LatestHttpResponse: resp.HttpResponse,
		Items: items,
	}
	return
}
`, "`json:\"value\"`")

	assertTemplatedCodeMatches(t, expected, *actual)
}

func TestTemplateMethodsListWithSimpleType(t *testing.T) {

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

	actual, err := methodsPandoraTemplater{
		operation: resourcemanager.ApiOperation{
			ExpectedStatusCodes:              []int{200},
			FieldContainingPaginationDetails: stringPointer("nextLink"),
			Method:                           "GET",
			ResponseObject: &resourcemanager.ApiObjectDefinition{
				Type: resourcemanager.StringApiObjectDefinitionType,
			},
			ResourceIdName: stringPointer("PandaPop"),
			UriSuffix:      stringPointer("/pandas"),
		},
		operationName: "List",
	}.listOperationTemplate(input)

	if err != nil {
		t.Fatalf("err %+v", err)
	}

	expected := fmt.Sprintf(`
type ListOperationResponse struct {
	HttpResponse *http.Response
    OData *odata.OData
	Model *[]string
}

type ListCompleteResult struct {
	LatestHttpResponse *http.Response
	Items []string
}

// List ...
func (c pandaClient) List(ctx context.Context , id PandaPop) (result ListOperationResponse, err error) {
	opts := client.RequestOptions{
		ContentType: "application/json",
		ExpectedStatusCodes: []int{
			http.StatusOK,
		},
		HttpMethod: http.MethodGet,
		Path: fmt.Sprintf("%%s/pandas", id.ID()),
	}

	req, err := c.Client.NewRequest(ctx, opts)
	if err != nil {
		return
	}

	var resp *client.Response
	resp, err = req.ExecutePaged(ctx)
	if resp != nil {
		result.OData = resp.OData
		result.HttpResponse = resp.Response
	}

	if err != nil {
		return
	}

	var values struct {
		Values *[]string %[1]s
	}
	if err = resp.Unmarshal(&values); err != nil {
		return
	}

	result.Model = values.Values

	return
}

// ListComplete retrieves all the results into a single object
func (c pandaClient) ListComplete(ctx context.Context, id PandaPop) (result ListCompleteResult, err error) {
	items := make([]string, 0)

	resp, err := c.List(ctx, id)
	if err != nil {
		err = fmt.Errorf("loading results: %%+v", err)
		return
	}
	if resp.Model != nil {
		for _, v := range *resp.Model {
			items = append(items, v)
		}
	}

	result = ListCompleteResult{
		LatestHttpResponse: resp.HttpResponse,
		Items:    items,
	}
	return
}
`, "`json:\"value\"`")

	assertTemplatedCodeMatches(t, expected, *actual)
}

func TestTemplateMethodsListWithObject(t *testing.T) {
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

	actual, err := methodsPandoraTemplater{
		operation: resourcemanager.ApiOperation{
			ExpectedStatusCodes:              []int{200},
			FieldContainingPaginationDetails: stringPointer("nextLink"),
			Method:                           "GET",
			ResponseObject: &resourcemanager.ApiObjectDefinition{
				Type:          resourcemanager.ReferenceApiObjectDefinitionType,
				ReferenceName: stringPointer("LingLing"),
			},
			ResourceIdName: stringPointer("PandaPop"),
			UriSuffix:      stringPointer("/pandas"),
		},
		operationName: "List",
	}.listOperationTemplate(input)

	if err != nil {
		t.Fatalf("err %+v", err)
	}

	expected := fmt.Sprintf(`
type ListOperationResponse struct {
	HttpResponse *http.Response
    OData *odata.OData
	Model *[]LingLing
}

type ListCompleteResult struct {
	LatestHttpResponse *http.Response
	Items []LingLing
}

// List ...
func (c pandaClient) List(ctx context.Context , id PandaPop) (result ListOperationResponse, err error) {
	opts := client.RequestOptions{
		ContentType: "application/json",
		ExpectedStatusCodes: []int{
			http.StatusOK,
		},
		HttpMethod: http.MethodGet,
		Path: fmt.Sprintf("%%s/pandas", id.ID()),
	}

	req, err := c.Client.NewRequest(ctx, opts)
	if err != nil {
		return
	}

	var resp *client.Response
	resp, err = req.ExecutePaged(ctx)
	if resp != nil {
		result.OData = resp.OData
		result.HttpResponse = resp.Response
	}

	if err != nil {
		return
	}

	var values struct {
		Values *[]LingLing %[1]s
	}
	if err = resp.Unmarshal(&values); err != nil {
		return
	}

	result.Model = values.Values

	return
}

// ListComplete retrieves all the results into a single object
func (c pandaClient) ListComplete(ctx context.Context, id PandaPop) (ListCompleteResult, error) {
	return c.ListCompleteMatchingPredicate(ctx, id, LingLingOperationPredicate{})
}

// ListCompleteMatchingPredicate retrieves all the results and then applies the predicate
func (c pandaClient) ListCompleteMatchingPredicate(ctx context.Context, id PandaPop, predicate LingLingOperationPredicate) (result ListCompleteResult, err error) {
	items := make([]LingLing, 0)

	resp, err := c.List(ctx, id)
	if err != nil {
		err = fmt.Errorf("loading results: %%+v", err)
		return
	}
	if resp.Model != nil {
		for _, v := range *resp.Model {
			if predicate.Matches(v) {
				items = append(items, v)
			}
		}
	}

	result = ListCompleteResult{
		LatestHttpResponse: resp.HttpResponse,
		Items: items,
	}
	return
}
`, "`json:\"value\"`")

	assertTemplatedCodeMatches(t, expected, *actual)
}
