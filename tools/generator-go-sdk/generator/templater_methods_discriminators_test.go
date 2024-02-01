package generator

import (
	"fmt"
	"net/http"
	"testing"

	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

// TODO: additional tests covering the Methods for Discriminated Types.

func TestTemplateMethods_Discriminator_ResponseObjectIsImplementation_Get(t *testing.T) {
	// This test covers the Response Object being a Discriminated Implementation for a GET operation
	// In this instance the Discriminated Implementation Type should be used in the Response and the
	// Discriminated Parent's `unmarshal` function shouldn't be called.

	input := ServiceGeneratorData{
		packageName:       "chubbypandas",
		serviceClientName: "pandaClient",
		source:            AccTestLicenceType,
		models: map[string]resourcemanager.ModelDetails{
			"PandaPop": {
				ParentTypeName: stringPointer("FizzyDrink"),
				TypeHintValue:  stringPointer("Cola"),
				Fields: map[string]resourcemanager.FieldDetails{
					"Cola": {
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type: resourcemanager.StringApiObjectDefinitionType,
						},
						Required: true,
					},
				},
			},
		},
		useNewBaseLayer: true,
	}

	actual, err := methodsPandoraTemplater{
		operation: resourcemanager.ApiOperation{
			ExpectedStatusCodes: []int{
				http.StatusOK,
			},
			Method: "GET",
			ResponseObject: &resourcemanager.ApiObjectDefinition{
				Type:          resourcemanager.ReferenceApiObjectDefinitionType,
				ReferenceName: stringPointer("PandaPop"),
			},
			UriSuffix: stringPointer("/thing"),
		},
		operationName: "Get",
	}.template(input)

	if err != nil {
		t.Fatalf("err %+v", err)
	}

	expected := `
package chubbypandas
import (
"context"
"fmt"
"net/http"
"net/url"
"github.com/hashicorp/go-azure-helpers/resourcemanager/commonids"
"github.com/hashicorp/go-azure-sdk/sdk/client"
"github.com/hashicorp/go-azure-sdk/sdk/client/pollers"
"github.com/hashicorp/go-azure-sdk/sdk/client/resourcemanager"
"github.com/hashicorp/go-azure-sdk/sdk/odata"
)
// acctests licence placeholder
type GetOperationResponse struct {
	HttpResponse *http.Response
	OData *odata.OData
	Model *PandaPop
}

// Get ...
func (c pandaClient) Get(ctx context.Context ) (result GetOperationResponse, err error) {
	opts := client.RequestOptions{
		ContentType: "application/json",
		ExpectedStatusCodes: []int{
			http.StatusOK,
		},
		HttpMethod: http.MethodGet,
		Path: "/thing",
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
}`

	assertTemplatedCodeMatches(t, expected, *actual)
}

func TestTemplateMethods_Discriminator_ResponseObjectIsParent_Get(t *testing.T) {
	// This test covers the Response Object being a Discriminated Parent Type for a GET operation
	// In this instance the `unmarshal` function for the Parent Type should be called as a part
	// of the Response.
	input := ServiceGeneratorData{
		packageName:       "chubbypandas",
		serviceClientName: "pandaClient",
		source:            AccTestLicenceType,
		models: map[string]resourcemanager.ModelDetails{
			"FizzyDrink": {
				TypeHintIn: stringPointer("Type"),
				Fields: map[string]resourcemanager.FieldDetails{
					"Type": {
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type: resourcemanager.StringApiObjectDefinitionType,
						},
						Required: true,
					},
				},
			},
		},
		useNewBaseLayer: true,
	}

	actual, err := methodsPandoraTemplater{
		operation: resourcemanager.ApiOperation{
			ExpectedStatusCodes: []int{
				http.StatusOK,
			},
			Method: "GET",
			ResponseObject: &resourcemanager.ApiObjectDefinition{
				Type:          resourcemanager.ReferenceApiObjectDefinitionType,
				ReferenceName: stringPointer("FizzyDrink"),
			},
			UriSuffix: stringPointer("/thing"),
		},
		operationName: "Get",
	}.template(input)

	if err != nil {
		t.Fatalf("err %+v", err)
	}

	expected := `
package chubbypandas

import (
"context"
"fmt"
"net/http"
"net/url"
"github.com/hashicorp/go-azure-helpers/resourcemanager/commonids"
"github.com/hashicorp/go-azure-sdk/sdk/client"
"github.com/hashicorp/go-azure-sdk/sdk/client/pollers"
"github.com/hashicorp/go-azure-sdk/sdk/client/resourcemanager"
"github.com/hashicorp/go-azure-sdk/sdk/odata"
)

// acctests licence placeholder
type GetOperationResponse struct {
	HttpResponse *http.Response
	OData *odata.OData
	Model *FizzyDrink
}

// Get ...
func (c pandaClient) Get(ctx context.Context ) (result GetOperationResponse, err error) {
	opts := client.RequestOptions{
		ContentType: "application/json",
		ExpectedStatusCodes: []int{
			http.StatusOK,
		},
		HttpMethod: http.MethodGet,
		Path: "/thing",
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

	var respObj json.RawMessage
	if err = resp.Unmarshal(&respObj); err != nil {
		return
	}
	model, err := unmarshalFizzyDrinkImplementation(respObj)
	if err != nil {
		return
	}
	result.Model = &model
	return
}`

	assertTemplatedCodeMatches(t, expected, *actual)
}

func TestTemplateMethods_Discriminator_ResponseObjectIsImplementation_List(t *testing.T) {
	// This test covers the Response Object being a List of a Discriminated Implementation
	// for a GET Operation. In this instance a slice of the Discriminated Implementation Type
	// should be output - and the Discriminated Parent's `unmarshal` function shouldn't be called.

	input := ServiceGeneratorData{
		packageName:       "chubbypandas",
		serviceClientName: "pandaClient",
		source:            AccTestLicenceType,
		models: map[string]resourcemanager.ModelDetails{
			"PandaPop": {
				ParentTypeName: stringPointer("FizzyDrink"),
				TypeHintValue:  stringPointer("Cola"),
				Fields: map[string]resourcemanager.FieldDetails{
					"Cola": {
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type: resourcemanager.StringApiObjectDefinitionType,
						},
						Required: true,
					},
				},
			},
		},
		useNewBaseLayer: true,
	}

	actual, err := methodsPandoraTemplater{
		operation: resourcemanager.ApiOperation{
			ExpectedStatusCodes: []int{
				http.StatusOK,
			},
			FieldContainingPaginationDetails: pointer.To("SomeField"),
			Method:                           "GET",
			ResponseObject: &resourcemanager.ApiObjectDefinition{
				Type:          resourcemanager.ReferenceApiObjectDefinitionType,
				ReferenceName: stringPointer("PandaPop"),
			},
			UriSuffix: stringPointer("/thing"),
		},
		operationName: "List",
	}.template(input)

	if err != nil {
		t.Fatalf("err %+v", err)
	}

	expected := fmt.Sprintf(`
package chubbypandas

import (
	"context"
	"fmt"
	"net/http"
	"net/url"
	"github.com/hashicorp/go-azure-helpers/resourcemanager/commonids"
	"github.com/hashicorp/go-azure-sdk/sdk/client"
	"github.com/hashicorp/go-azure-sdk/sdk/client/pollers"
	"github.com/hashicorp/go-azure-sdk/sdk/client/resourcemanager"
	"github.com/hashicorp/go-azure-sdk/sdk/odata"
)

// acctests licence placeholder
type ListOperationResponse struct {
	HttpResponse *http.Response
    OData *odata.OData
    Model *[]PandaPop
}

type ListCompleteResult struct {
	LatestHttpResponse *http.Response
	Items []PandaPop
}

// List ...
func (c pandaClient) List(ctx context.Context ) (result ListOperationResponse, err error) {
	opts := client.RequestOptions{
		ContentType: "application/json",
		ExpectedStatusCodes: []int{
			http.StatusOK,
		},
		HttpMethod: http.MethodGet,
		Path: "/thing",
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
		Values *[]PandaPop %[1]s
	}
	if err = resp.Unmarshal(&values); err != nil {
		return
	}

	result.Model = values.Values

	return
}

// ListComplete retrieves all the results into a single object
func (c pandaClient) ListComplete(ctx context.Context) (ListCompleteResult, error) {
	return c.ListCompleteMatchingPredicate(ctx, PandaPopOperationPredicate{})
}

// ListCompleteMatchingPredicate retrieves all the results and then applies the predicate
func (c pandaClient) ListCompleteMatchingPredicate(ctx context.Context, predicate PandaPopOperationPredicate) (result ListCompleteResult, err error) {
	items := make([]PandaPop, 0)
	resp, err := c.List(ctx)
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

func TestTemplateMethods_Discriminator_ResponseObjectIsParent_List(t *testing.T) {
	// This test covers the Response Object being a List of a Discriminated Parent Types
	// for a GET Operation. In this instance a slice of the Discriminated Parent Type
	// should be output - and the (Discriminated Parent's) `unmarshal` function should be called.

	input := ServiceGeneratorData{
		packageName:       "chubbypandas",
		serviceClientName: "pandaClient",
		source:            AccTestLicenceType,
		models: map[string]resourcemanager.ModelDetails{
			"FizzyDrink": {
				TypeHintIn: stringPointer("Type"),
				Fields: map[string]resourcemanager.FieldDetails{
					"Type": {
						ObjectDefinition: resourcemanager.ApiObjectDefinition{
							Type: resourcemanager.StringApiObjectDefinitionType,
						},
						Required: true,
					},
				},
			},
		},
		useNewBaseLayer: true,
	}

	actual, err := methodsPandoraTemplater{
		operation: resourcemanager.ApiOperation{
			ExpectedStatusCodes: []int{
				http.StatusOK,
			},
			FieldContainingPaginationDetails: pointer.To("SomeField"),
			Method:                           "GET",
			ResponseObject: &resourcemanager.ApiObjectDefinition{
				Type:          resourcemanager.ReferenceApiObjectDefinitionType,
				ReferenceName: stringPointer("FizzyDrink"),
			},
			UriSuffix: stringPointer("/thing"),
		},
		operationName: "List",
	}.template(input)

	if err != nil {
		t.Fatalf("err %+v", err)
	}

	expected := fmt.Sprintf(`
package chubbypandas

import (
	"context"
	"fmt"
	"net/http"
	"net/url"
	"github.com/hashicorp/go-azure-helpers/resourcemanager/commonids"
	"github.com/hashicorp/go-azure-sdk/sdk/client"
	"github.com/hashicorp/go-azure-sdk/sdk/client/pollers"
	"github.com/hashicorp/go-azure-sdk/sdk/client/resourcemanager"
	"github.com/hashicorp/go-azure-sdk/sdk/odata"
)

// acctests licence placeholder
type ListOperationResponse struct {
	HttpResponse *http.Response
	OData *odata.OData
	Model *[]FizzyDrink
}

type ListCompleteResult struct {
	LatestHttpResponse *http.Response
	Items []FizzyDrink
}

// List ...
func (c pandaClient) List(ctx context.Context ) (result ListOperationResponse, err error) {
	opts := client.RequestOptions{
		ContentType: "application/json",
		ExpectedStatusCodes: []int{
			http.StatusOK,
		},
		HttpMethod: http.MethodGet,
		Path: "/thing",
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
	temp := make([]FizzyDrink, 0)
	if values.Values != nil {
		for i, v := range *values.Values {
			val, err := unmarshalFizzyDrinkImplementation(v)
			if err != nil {
				err = fmt.Errorf("unmarshalling item %%d for FizzyDrink (%%q): %%+v", i, v, err)
				return result, err
			}
			temp = append(temp, val)
		}
	}

	result.Model = &temp
	return
}

// ListComplete retrieves all the results into a single object
func (c pandaClient) ListComplete(ctx context.Context) (ListCompleteResult, error) {
	return c.ListCompleteMatchingPredicate(ctx, FizzyDrinkOperationPredicate{})
}

// ListCompleteMatchingPredicate retrieves all the results and then applies the predicate
func (c pandaClient) ListCompleteMatchingPredicate(ctx context.Context, predicate FizzyDrinkOperationPredicate) (result ListCompleteResult, err error) {
	items := make([]FizzyDrink, 0)
	resp, err := c.List(ctx)
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
