// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package generator

import (
	"fmt"
	"testing"

	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

// TODO: split the tests out into sub-groupings & add more coverage

func TestTemplateMethodsGet(t *testing.T) {
	input := GeneratorData{
		packageName:       "skinnyPandas",
		serviceClientName: "pandaClient",
		source:            AccTestLicenceType,
		resourceIds: map[string]models.ResourceID{
			"PandaPop": {
				ExampleValue: "LingLing",
			},
		},
	}

	actual, err := methodsPandoraTemplater{
		operation: models.SDKOperation{
			ContentType:         "application/json",
			ExpectedStatusCodes: []int{200},
			Method:              "GET",
			ResourceIDName:      stringPointer("PandaPop"),
			ResponseObject: &models.SDKObjectDefinition{
				Type: models.StringSDKObjectDefinitionType,
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

	var model string
	result.Model = &model
	if err = resp.Unmarshal(result.Model); err != nil {
		return
	}

	return
}
`
	assertTemplatedCodeMatches(t, expected, *actual)
}

func TestTemplateMethodsGetAsTextPowerShell(t *testing.T) {
	input := GeneratorData{
		packageName:       "skinnyPandas",
		serviceClientName: "pandaClient",
		source:            AccTestLicenceType,
		resourceIds: map[string]models.ResourceID{
			"PandaPop": {
				ExampleValue: "LingLing",
			},
		},
	}

	actual, err := methodsPandoraTemplater{
		operation: models.SDKOperation{
			ContentType:         "text/powershell",
			ExpectedStatusCodes: []int{200},
			Method:              "GET",
			ResourceIDName:      stringPointer("PandaPop"),
			ResponseObject: &models.SDKObjectDefinition{
				Type: models.RawFileSDKObjectDefinitionType,
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
	Model *[]byte
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

	var model []byte
	result.Model = &model
	if err = resp.Unmarshal(result.Model); err != nil {
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
	input := GeneratorData{
		packageName:       "chubbyPandas",
		serviceClientName: "pandaClient",
		source:            AccTestLicenceType,
		models: map[string]models.SDKModel{
			"Bottle": {
				Fields: map[string]models.SDKField{
					"Type": {
						ObjectDefinition: models.SDKObjectDefinition{
							Type: models.StringSDKObjectDefinitionType,
						},
						Required: true,
					},
				},
				ParentTypeName:                        nil,
				FieldNameContainingDiscriminatedValue: pointer.To("Type"),
				DiscriminatedValue:                    nil,
			},
			"MilkBottle": {
				Fields: map[string]models.SDKField{
					"Size": {
						ObjectDefinition: models.SDKObjectDefinition{
							Type: models.StringSDKObjectDefinitionType,
						},
						Required: true,
					},
				},
				ParentTypeName:                        pointer.To("Bottle"),
				FieldNameContainingDiscriminatedValue: pointer.To("Type"),
				DiscriminatedValue:                    pointer.To("Milk"),
			},
		},
		resourceIds: map[string]models.ResourceID{
			"PandaPop": {
				ExampleValue: "LingLing",
			},
		},
	}

	actual, err := methodsPandoraTemplater{
		operation: models.SDKOperation{
			ContentType:                      "application/json",
			ExpectedStatusCodes:              []int{200},
			FieldContainingPaginationDetails: stringPointer("nextLink"),
			Method:                           "GET",
			ResponseObject: &models.SDKObjectDefinition{
				Type:          models.ReferenceSDKObjectDefinitionType,
				ReferenceName: stringPointer("Bottle"),
			},
			ResourceIDName: stringPointer("PandaPop"),
			URISuffix:      stringPointer("/pandas"),
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

type ListCustomPager struct {
	NextLink *odata.Link %[2]s
}

func (p *ListCustomPager) NextPageLink() *odata.Link {
	defer func() {
		p.NextLink = nil
	}()

	return p.NextLink
}

// List ...
func (c pandaClient) List(ctx context.Context , id PandaPop) (result ListOperationResponse, err error) {
	opts := client.RequestOptions{
		ContentType: "application/json",
		ExpectedStatusCodes: []int{
			http.StatusOK,
		},
		HttpMethod: http.MethodGet,
		Pager: &ListCustomPager{},
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
		result.LatestHttpResponse = resp.HttpResponse
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
`, "`json:\"value\"`", "`json:\"nextLink\"`")

	assertTemplatedCodeMatches(t, expected, *actual)
}

func TestTemplateMethodsListWithSimpleType(t *testing.T) {
	input := GeneratorData{
		packageName:       "chubbyPandas",
		serviceClientName: "pandaClient",
		source:            AccTestLicenceType,
		resourceIds: map[string]models.ResourceID{
			"PandaPop": {
				ExampleValue: "LingLing",
			},
		},
	}

	actual, err := methodsPandoraTemplater{
		operation: models.SDKOperation{
			ContentType:                      "application/json",
			ExpectedStatusCodes:              []int{200},
			FieldContainingPaginationDetails: stringPointer("nextLink"),
			Method:                           "GET",
			ResponseObject: &models.SDKObjectDefinition{
				Type: models.StringSDKObjectDefinitionType,
			},
			ResourceIDName: stringPointer("PandaPop"),
			URISuffix:      stringPointer("/pandas"),
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

type ListCustomPager struct {
	NextLink *odata.Link %[2]s
}

func (p *ListCustomPager) NextPageLink() *odata.Link {
	defer func() {
		p.NextLink = nil
	}()

	return p.NextLink
}

// List ...
func (c pandaClient) List(ctx context.Context , id PandaPop) (result ListOperationResponse, err error) {
	opts := client.RequestOptions{
		ContentType: "application/json",
		ExpectedStatusCodes: []int{
			http.StatusOK,
		},
		HttpMethod: http.MethodGet,
		Pager: &ListCustomPager{},
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
		result.LatestHttpResponse = resp.HttpResponse
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
`, "`json:\"value\"`", "`json:\"nextLink\"`")

	assertTemplatedCodeMatches(t, expected, *actual)
}

func TestTemplateMethodsListWithObject(t *testing.T) {
	input := GeneratorData{
		packageName:       "chubbyPandas",
		serviceClientName: "pandaClient",
		source:            AccTestLicenceType,
		resourceIds: map[string]models.ResourceID{
			"PandaPop": {
				ExampleValue: "LingLing",
			},
		},
	}

	actual, err := methodsPandoraTemplater{
		operation: models.SDKOperation{
			ContentType:                      "application/json",
			ExpectedStatusCodes:              []int{200},
			FieldContainingPaginationDetails: stringPointer("nextLink"),
			Method:                           "GET",
			ResponseObject: &models.SDKObjectDefinition{
				Type:          models.ReferenceSDKObjectDefinitionType,
				ReferenceName: stringPointer("LingLing"),
			},
			ResourceIDName: stringPointer("PandaPop"),
			URISuffix:      stringPointer("/pandas"),
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

type ListCustomPager struct {
	NextLink *odata.Link %[2]s
}

func (p *ListCustomPager) NextPageLink() *odata.Link {
	defer func() {
		p.NextLink = nil
	}()

	return p.NextLink
}

// List ...
func (c pandaClient) List(ctx context.Context , id PandaPop) (result ListOperationResponse, err error) {
	opts := client.RequestOptions{
		ContentType: "application/json",
		ExpectedStatusCodes: []int{
			http.StatusOK,
		},
		HttpMethod: http.MethodGet,
		Pager: &ListCustomPager{},
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
		result.LatestHttpResponse = resp.HttpResponse
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
`, "`json:\"value\"`", "`json:\"nextLink\"`")

	assertTemplatedCodeMatches(t, expected, *actual)
}
