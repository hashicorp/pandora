package generator

import (
	"fmt"
	"sort"
	"strings"

	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

// TODO: should we expose a Description for each operation? seems not worthwhile
// TODO: implement predicates
// TODO: add unit tests covering this

var _ templaterForResource = methodsAutoRestTemplater{}

type methodsAutoRestTemplater struct {
	operation     resourcemanager.ApiOperation
	operationName string
	constants     map[string]resourcemanager.ConstantDetails
}

func (c methodsAutoRestTemplater) template(data ServiceGeneratorData) (*string, error) {
	methods, err := c.methods(data)
	if err != nil {
		return nil, fmt.Errorf("building methods: %+v", err)
	}

	copyrightLines, err := copyrightLinesForSource(data.source)
	if err != nil {
		return nil, fmt.Errorf("retrieving copyright lines: %+v", err)
	}

	template := fmt.Sprintf(`package %[1]s

import (
	"context"
	"fmt"
	"io/ioutil"
	"net/http"
	"net/url"

	"github.com/Azure/go-autorest/autorest"
	"github.com/Azure/go-autorest/autorest/azure"
	"github.com/hashicorp/go-azure-helpers/lang/response"
	"github.com/hashicorp/go-azure-helpers/resourcemanager/commonids"
	"github.com/hashicorp/go-azure-helpers/polling"
)

%s

%s
`, data.packageName, *copyrightLines, *methods)
	return &template, nil
}

func (c methodsAutoRestTemplater) methods(data ServiceGeneratorData) (*string, error) {
	// NOTE: most of this logic is sanity checking, but should be within the API and it's validators too
	// that could be a separate validation tool, but this would be most useful as unit tests

	switch strings.ToUpper(c.operation.Method) {
	case "DELETE":
		if c.operation.LongRunning {
			return c.longRunningOperationTemplate(data)
		}

		if c.operation.FieldContainingPaginationDetails != nil {
			return nil, fmt.Errorf("pagination is not supported for DELETE Operations")
		}

		return c.immediateOperationTemplate(data)

	case "GET":
		if c.operation.LongRunning {
			return nil, fmt.Errorf("`GET` operations cannot be long-running")
		}

		if c.operation.FieldContainingPaginationDetails != nil {
			return c.listOperationTemplate(data)
		}

		return c.immediateOperationTemplate(data)

	case "HEAD":
		if c.operation.LongRunning {
			return nil, fmt.Errorf("`HEAD` operations cannot be long running")
		}
		if c.operation.RequestObject != nil {
			return nil, fmt.Errorf("`HEAD` operations cannot have request objects")
		}
		if c.operation.ResponseObject != nil {
			return nil, fmt.Errorf("`HEAD` operations cannot have response objects")
		}

		if c.operation.FieldContainingPaginationDetails != nil {
			return nil, fmt.Errorf("pagination is not supported for HEAD Operations")
		}

		return c.immediateOperationTemplate(data)

	case "PATCH":
		if c.operation.LongRunning {
			return c.longRunningOperationTemplate(data)
		}

		if c.operation.FieldContainingPaginationDetails != nil {
			return nil, fmt.Errorf("pagination is not supported for PATCH Operations")
		}

		return c.immediateOperationTemplate(data)

	case "POST":
		if c.operation.LongRunning {
			return c.longRunningOperationTemplate(data)
		}

		if c.operation.FieldContainingPaginationDetails != nil {
			return c.listOperationTemplate(data)
		}

		return c.immediateOperationTemplate(data)

	case "PUT":
		if c.operation.LongRunning {
			return c.longRunningOperationTemplate(data)
		}

		if c.operation.FieldContainingPaginationDetails != nil {
			return nil, fmt.Errorf("pagination is not supported for PUT Operations")
		}

		return c.immediateOperationTemplate(data)
	}

	return nil, fmt.Errorf("unsupported HTTP Method %q", c.operation.Method)
}

func (c methodsAutoRestTemplater) immediateOperationTemplate(data ServiceGeneratorData) (*string, error) {
	argumentsMethodCode, err := c.argumentsTemplateForMethod(data)
	if err != nil {
		return nil, fmt.Errorf("building arguments for immediate operation: %+v", err)
	}
	argumentsCode := c.argumentsTemplate()
	optionsStruct, err := c.optionsStruct(data)
	if err != nil {
		return nil, fmt.Errorf("building options struct: %+v", err)
	}
	preparerCode, err := c.preparerTemplate(data)
	if err != nil {
		return nil, fmt.Errorf("building arguments for preparer template: %+v", err)
	}
	responseStruct, err := c.responseStructTemplate(data)
	if err != nil {
		return nil, fmt.Errorf("building response struct template: %+v", err)
	}
	responderCode, err := c.responderTemplate(data)
	if err != nil {
		return nil, fmt.Errorf("building responder template: %+v", err)
	}
	templated := fmt.Sprintf(`
%[7]s
%[9]s

// %[2]s ...
func (c %[1]s) %[2]s(ctx context.Context %[4]s) (result %[2]sOperationResponse, err error) {
	req, err := c.preparerFor%[2]s(ctx %[8]s)
	if err != nil {
		err = autorest.NewErrorWithError(err, "%[3]s.%[1]s", "%[2]s", nil, "Failure preparing request")
		return
	}

	result.HttpResponse, err = c.Client.Send(req, azure.DoRetryWithRegistration(c.Client))
	if err != nil {
		err = autorest.NewErrorWithError(err, "%[3]s.%[1]s", "%[2]s", result.HttpResponse, "Failure sending request")
		return
	}

	result, err = c.responderFor%[2]s(result.HttpResponse)
	if err != nil {
		err = autorest.NewErrorWithError(err, "%[3]s.%[1]s", "%[2]s", result.HttpResponse, "Failure responding to request")
		return
	}

	return
}

%[5]s

%[6]s
`, data.serviceClientName, c.operationName, data.packageName, *argumentsMethodCode, *preparerCode, *responderCode, *responseStruct, argumentsCode, *optionsStruct)
	return &templated, nil
}

func (c methodsAutoRestTemplater) listOperationTemplate(data ServiceGeneratorData) (*string, error) {
	argumentsMethodCode, err := c.argumentsTemplateForMethod(data)
	if err != nil {
		return nil, fmt.Errorf("building arguments for list operation: %+v", err)
	}
	argumentsCode := c.argumentsTemplate()
	optionsStruct, err := c.optionsStruct(data)
	if err != nil {
		return nil, fmt.Errorf("building options struct: %+v", err)
	}
	preparerCode, err := c.preparerTemplate(data)
	if err != nil {
		return nil, fmt.Errorf("building arguments for preparer template: %+v", err)
	}
	responseStruct, err := c.responseStructTemplate(data)
	if err != nil {
		return nil, fmt.Errorf("building response struct template: %+v", err)
	}
	responderCode, err := c.responderTemplate(data)
	if err != nil {
		return nil, fmt.Errorf("building responder template: %+v", err)
	}
	typeName, err := golangTypeNameForObjectDefinition(*c.operation.ResponseObject)
	if err != nil {
		return nil, fmt.Errorf("determining golang type name for response object: %+v", err)
	}

	templated := fmt.Sprintf(`
%[7]s
%[9]s

// %[2]s ...
func (c %[1]s) %[2]s(ctx context.Context %[4]s) (resp %[2]sOperationResponse, err error) {
	req, err := c.preparerFor%[2]s(ctx %[8]s)
	if err != nil {
		err = autorest.NewErrorWithError(err, "%[3]s.%[1]s", "%[2]s", nil, "Failure preparing request")
		return
	}

	resp.HttpResponse, err = c.Client.Send(req, azure.DoRetryWithRegistration(c.Client))
	if err != nil {
		err = autorest.NewErrorWithError(err, "%[3]s.%[1]s", "%[2]s", resp.HttpResponse, "Failure sending request")
		return
	}

	resp, err = c.responderFor%[2]s(resp.HttpResponse)
	if err != nil {
		err = autorest.NewErrorWithError(err, "%[3]s.%[1]s", "%[2]s", resp.HttpResponse, "Failure responding to request")
		return
	}
	return
}

// %[2]sComplete retrieves all of the results into a single object
func (c %[1]s) %[2]sComplete(ctx context.Context %[4]s) (%[2]sCompleteResult, error) {
	return c.%[2]sCompleteMatchingPredicate(ctx %[8]s, %[10]sOperationPredicate{})
}

// %[2]sCompleteMatchingPredicate retrieves all of the results and then applied the predicate
func (c %[1]s) %[2]sCompleteMatchingPredicate(ctx context.Context %[4]s, predicate %[10]sOperationPredicate) (resp %[2]sCompleteResult, err error) {
	items := make([]%[10]s, 0)

	page, err := c.%[2]s(ctx %[8]s)
	if err != nil {
		err = fmt.Errorf("loading the initial page: %%+v", err)
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
			err = fmt.Errorf("loading the next page: %%+v", err)
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

	out := %[2]sCompleteResult{
		Items: items,
	}
	return out, nil
}

%[5]s

%[6]s
`, data.serviceClientName, c.operationName, data.packageName, *argumentsMethodCode, *preparerCode, *responderCode, *responseStruct, argumentsCode, *optionsStruct, *typeName)
	return &templated, nil
}

func (c methodsAutoRestTemplater) longRunningOperationTemplate(data ServiceGeneratorData) (*string, error) {
	argumentsMethodCode, err := c.argumentsTemplateForMethod(data)
	if err != nil {
		return nil, fmt.Errorf("building arguments for long running template: %+v", err)
	}
	argumentsCode := c.argumentsTemplate()
	optionsStruct, err := c.optionsStruct(data)
	if err != nil {
		return nil, fmt.Errorf("building options struct: %+v", err)
	}
	preparerCode, err := c.preparerTemplate(data)
	if err != nil {
		return nil, fmt.Errorf("building preparer template: %+v", err)
	}
	responseStruct, err := c.responseStructTemplate(data)
	if err != nil {
		return nil, fmt.Errorf("building response struct template: %+v", err)
	}
	senderCode := c.senderLongRunningOperationTemplate(data)
	templated := fmt.Sprintf(`
%[7]s
%[9]s

// %[2]s ...
func (c %[1]s) %[2]s(ctx context.Context %[4]s) (result %[2]sOperationResponse, err error) {
	req, err := c.preparerFor%[2]s(ctx %[8]s)
	if err != nil {
		err = autorest.NewErrorWithError(err, "%[3]s.%[1]s", "%[2]s", nil, "Failure preparing request")
		return
	}

	result, err = c.senderFor%[2]s(ctx, req)
	if err != nil {
		err = autorest.NewErrorWithError(err, "%[3]s.%[1]s", "%[2]s", result.HttpResponse, "Failure sending request")
		return
	}

	return
}

// %[2]sThenPoll performs %[2]s then polls until it's completed
func (c %[1]s) %[2]sThenPoll(ctx context.Context %[4]s) error {
	result, err := c.%[2]s(ctx %[8]s)
	if err != nil {
		return fmt.Errorf("performing %[2]s: %%+v", err)
	}
	
	if err := result.Poller.PollUntilDone(); err != nil {
		return fmt.Errorf("polling after %[2]s: %%+v", err)
	}

	return nil
}

%[5]s

%[6]s
`, data.serviceClientName, c.operationName, data.packageName, *argumentsMethodCode, *preparerCode, senderCode, *responseStruct, argumentsCode, *optionsStruct)
	return &templated, nil
}

func (c methodsAutoRestTemplater) argumentsTemplate() string {
	args := make([]string, 0)
	if c.operation.ResourceIdName != nil {
		args = append(args, "id")
	}
	if c.operation.RequestObject != nil {
		args = append(args, "input")
	}
	if len(c.operation.Options) > 0 {
		args = append(args, "options")
	}
	if len(args) == 0 {
		return ""
	}

	return fmt.Sprintf(", %s", strings.Join(args, ", "))
}

func (c methodsAutoRestTemplater) argumentsTemplateForMethod(data ServiceGeneratorData) (*string, error) {
	arguments := make([]string, 0)
	if c.operation.ResourceIdName != nil {
		idName := *c.operation.ResourceIdName
		id, ok := data.resourceIds[idName]
		if !ok {
			return nil, fmt.Errorf("internal error: Resource ID %q was not found", idName)
		}
		if id.CommonAlias != nil {
			idName = fmt.Sprintf("commonids.%sId", *id.CommonAlias)
		}

		arguments = append(arguments, fmt.Sprintf("id %s", idName))
	}
	if c.operation.RequestObject != nil {
		typeName, err := golangTypeNameForObjectDefinition(*c.operation.RequestObject)
		if err != nil {
			return nil, fmt.Errorf("determining type name for request object: %+v", err)
		}
		arguments = append(arguments, fmt.Sprintf("input %s", *typeName))
	}
	if len(c.operation.Options) > 0 {
		arguments = append(arguments, fmt.Sprintf("options %sOperationOptions", c.operationName))
	}

	out := fmt.Sprintf(", %s", strings.Join(arguments, ", "))
	if len(arguments) == 0 {
		out = ""
	}
	return &out, nil
}

func (c methodsAutoRestTemplater) preparerTemplate(data ServiceGeneratorData) (*string, error) {
	arguments, err := c.argumentsTemplateForMethod(data)
	if err != nil {
		return nil, fmt.Errorf("building arguments for preparer template: %+v", err)
	}

	steps := make([]string, 0)
	listSteps := make([]string, 0)
	if c.operation.ContentType != nil {
		steps = append(steps, fmt.Sprintf("autorest.AsContentType(%q)", *c.operation.ContentType))
		listSteps = append(listSteps, fmt.Sprintf("autorest.AsContentType(%q)", *c.operation.ContentType))
	}
	if strings.EqualFold(c.operation.Method, "Delete") {
		steps = append(steps, "autorest.AsDelete()")
		listSteps = append(listSteps, "autorest.AsDelete()")
	}
	if strings.EqualFold(c.operation.Method, "Head") {
		steps = append(steps, "autorest.AsHead()")
		listSteps = append(listSteps, "autorest.AsHead()")
	}
	if strings.EqualFold(c.operation.Method, "Get") {
		steps = append(steps, "autorest.AsGet()")
		listSteps = append(listSteps, "autorest.AsGet()")
	}
	if strings.EqualFold(c.operation.Method, "Patch") {
		steps = append(steps, "autorest.AsPatch()")
		listSteps = append(listSteps, "autorest.AsPatch()")
	}
	if strings.EqualFold(c.operation.Method, "Post") {
		steps = append(steps, "autorest.AsPost()")
		listSteps = append(listSteps, "autorest.AsPost()")
	}
	if strings.EqualFold(c.operation.Method, "Put") {
		steps = append(steps, "autorest.AsPut()")
		listSteps = append(listSteps, "autorest.AsPut()")
	}
	steps = append(steps, "autorest.WithBaseURL(c.baseUri)")
	listSteps = append(listSteps, "autorest.WithBaseURL(c.baseUri)")

	optionsCode := ""
	if len(c.operation.Options) > 0 {
		optionsCode = `
	for k, v := range options.toQueryString() {
		queryParameters[k] = autorest.Encode("query", v)
	}`
		steps = append(steps, "autorest.WithHeaders(options.toHeaders())")
	}

	if c.operation.UriSuffix != nil {
		if c.operation.ResourceIdName != nil {
			steps = append(steps, fmt.Sprintf("autorest.WithPath(fmt.Sprintf(\"%%s%s\", id.ID()))", *c.operation.UriSuffix))
		} else {
			steps = append(steps, fmt.Sprintf("autorest.WithPath(%q)", *c.operation.UriSuffix))
		}
	} else {
		if c.operation.ResourceIdName != nil {
			steps = append(steps, "autorest.WithPath(id.ID())")
		}
	}
	listSteps = append(listSteps, "autorest.WithPath(uri.Path)")

	if c.operation.RequestObject != nil {
		steps = append(steps, "autorest.WithJSON(input)")
	}
	steps = append(steps, "autorest.WithQueryParameters(queryParameters)")
	listSteps = append(listSteps, "autorest.WithQueryParameters(queryParameters)")

	template := `
// preparerFor%[2]s prepares the %[2]s request.
func (c %[1]s) preparerFor%[2]s(ctx context.Context %[3]s) (*http.Request, error) {
	queryParameters := map[string]interface{}{
		"api-version": defaultApiVersion,
	}
%[5]s

	preparer := autorest.CreatePreparer(
		%[4]s)
	return preparer.Prepare((&http.Request{}).WithContext(ctx))
}
`
	if c.operation.FieldContainingPaginationDetails != nil {
		template += `
// preparerFor%[2]sWithNextLink prepares the %[2]s request with the given nextLink token.
func (c %[1]s) preparerFor%[2]sWithNextLink(ctx context.Context, nextLink string) (*http.Request, error) {
	uri, err := url.Parse(nextLink)
	if err != nil {
		return nil, fmt.Errorf("parsing nextLink %%q: %%+v", nextLink, err)
	}
	queryParameters := map[string]interface{}{}
	for k, v := range uri.Query() {
		if len(v) == 0 {
			continue
		}
		val := v[0]
		val = autorest.Encode("query", val)
		queryParameters[k] = val
	}

	preparer := autorest.CreatePreparer(
		%[6]s)
	return preparer.Prepare((&http.Request{}).WithContext(ctx))
}
`
	}

	output := fmt.Sprintf(template, data.serviceClientName, c.operationName, *arguments, strings.Join(steps, ",\n\t\t"), optionsCode, strings.Join(listSteps, ",\n\t\t"))
	return &output, nil
}

func (c methodsAutoRestTemplater) responderTemplate(data ServiceGeneratorData) (*string, error) {
	expectedStatusCodes := make([]string, 0)
	for _, statusCodeInt := range c.operation.ExpectedStatusCodes {
		statusCode := golangConstantForStatusCode(statusCodeInt)
		expectedStatusCodes = append(expectedStatusCodes, statusCode)
	}
	// removes spurious changes in the output
	sort.Strings(expectedStatusCodes)

	discriminatedType := c.discriminatedTypeName(data.models)

	steps := make([]string, 0)
	steps = append(steps, fmt.Sprintf("azure.WithErrorUnlessStatusCode(%s)", strings.Join(expectedStatusCodes, ", ")))
	if c.operation.ResponseObject != nil {
		if discriminatedType == "" { // If this is a discriminated type with a parent interface, do not use the autorest decorator to unmarshal it
			if c.operation.FieldContainingPaginationDetails != nil {
				steps = append(steps, "autorest.ByUnmarshallingJSON(&respObj)")
			} else {
				steps = append(steps, "autorest.ByUnmarshallingJSON(&result.Model)")
			}
		}
	}
	steps = append(steps, "autorest.ByClosing()")

	if c.operation.FieldContainingPaginationDetails != nil {
		typeName, err := golangTypeNameForObjectDefinition(*c.operation.ResponseObject)
		if err != nil {
			return nil, fmt.Errorf("determining golang type name for response object: %+v", err)
		}

		fields := make([]string, 0)
		fields = append(fields, fmt.Sprintf("Values []%s `json:%q`", *typeName, "value"))
		fields = append(fields, fmt.Sprintf("NextLink *string `json:%q`", *c.operation.FieldContainingPaginationDetails))
		output := fmt.Sprintf(`
// responderFor%[2]s handles the response to the %[2]s request. The method always
// closes the http.Response Body.
func (c %[1]s) responderFor%[2]s(resp *http.Response) (result %[2]sOperationResponse, err error) {
	type page struct {
		%[4]s
	}
	var respObj page
	err = autorest.Respond(
		resp,
		%[3]s)
	result.HttpResponse = resp
	result.Model = &respObj.Values
	result.nextLink = respObj.NextLink
	if respObj.NextLink != nil {
		result.nextPageFunc = func(ctx context.Context, nextLink string) (result %[2]sOperationResponse, err error) {
			req, err := c.preparerFor%[2]sWithNextLink(ctx, nextLink)
			if err != nil {
				err = autorest.NewErrorWithError(err, "%[5]s.%[1]s", "%[2]s", nil, "Failure preparing request")
				return
			}
		
			result.HttpResponse, err = c.Client.Send(req, azure.DoRetryWithRegistration(c.Client))
			if err != nil {
				err = autorest.NewErrorWithError(err, "%[5]s.%[1]s", "%[2]s", result.HttpResponse, "Failure sending request")
				return
			}
		
			result, err = c.responderFor%[2]s(result.HttpResponse)
			if err != nil {
				err = autorest.NewErrorWithError(err, "%[5]s.%[1]s", "%[2]s", result.HttpResponse, "Failure responding to request")
				return
			}

			return
		}
	}
	return
}
`, data.serviceClientName, c.operationName, strings.Join(steps, ",\n\t\t"), strings.Join(fields, "\n\t\t"), data.packageName)
		return &output, nil
	}

	if discriminatedType != "" {
		output := fmt.Sprintf(`
// responderFor%[2]s handles the response to the %[2]s request. The method always
// closes the http.Response Body.
func (c %[1]s) responderFor%[2]s(resp *http.Response) (result %[2]sOperationResponse, err error) {
	err = autorest.Respond(
		resp,
		%[3]s)
	result.HttpResponse = resp
	b, err := ioutil.ReadAll(resp.Body)
	if err != nil {
		return result, fmt.Errorf("reading response body: %+v", err)
	}
	model, err := unmarshal%[4]sImplementation(b)
	if err != nil {
		return
	}
	result.Model = &model
	return
}
`, data.serviceClientName, c.operationName, strings.Join(steps, ",\n\t\t"), discriminatedType)
		return &output, nil
	}

	output := fmt.Sprintf(`
// responderFor%[2]s handles the response to the %[2]s request. The method always
// closes the http.Response Body.
func (c %[1]s) responderFor%[2]s(resp *http.Response) (result %[2]sOperationResponse, err error) {
	err = autorest.Respond(
		resp,
		%[3]s)
	result.HttpResponse = resp

	return
}
`, data.serviceClientName, c.operationName, strings.Join(steps, ",\n\t\t"), discriminatedType)

	return &output, nil
}

func (c methodsAutoRestTemplater) responseStructTemplate(data ServiceGeneratorData) (*string, error) {
	model := ""
	typeName := ""
	if c.operation.ResponseObject != nil {
		golangTypeName, err := golangTypeNameForObjectDefinition(*c.operation.ResponseObject)
		if err != nil {
			return nil, fmt.Errorf("determing golang type name for response object: %+v", err)
		}
		typeName = *golangTypeName

		if c.operation.FieldContainingPaginationDetails != nil {
			model = fmt.Sprintf("Model *[]%s", typeName)
		} else {
			model = fmt.Sprintf("Model *%s", typeName)
		}
	}

	lro := ""
	if c.operation.LongRunning {
		lro = fmt.Sprintf("Poller polling.LongRunningPoller")
	}

	responseStructName := fmt.Sprintf("%[1]sOperationResponse", c.operationName)
	if _, hasExistingModel := data.models[responseStructName]; hasExistingModel {
		return nil, fmt.Errorf("existing model %q conflicts with the operation response model for %q", responseStructName, c.operationName)
	}

	paginationFields := ""
	paginationCode := ""
	if c.operation.FieldContainingPaginationDetails != nil {
		// whilst these looks like they could crash it's guaranteed above
		paginationCode = fmt.Sprintf(`
type %[2]sCompleteResult struct {
	Items   []%[1]s
}

func (r %[2]sOperationResponse) HasMore() bool {
	return r.nextLink != nil
}

func (r %[2]sOperationResponse) LoadMore(ctx context.Context) (resp %[2]sOperationResponse, err error) {
	if !r.HasMore() {
		err = fmt.Errorf("no more pages returned")
		return
	}
	return r.nextPageFunc(ctx, *r.nextLink)
}
`, typeName, c.operationName)
		paginationFields = fmt.Sprintf(`
	nextLink *string
	nextPageFunc func(ctx context.Context, nextLink string) (%[1]sOperationResponse, error)
`, c.operationName)

		output := fmt.Sprintf(`
type %[1]s struct {
	%[3]s
	HttpResponse *http.Response
	%[2]s
	%[5]s
}

%[4]s
`, responseStructName, model, lro, paginationCode, paginationFields)
		return &output, nil
	}

	output := fmt.Sprintf(`
type %[1]s struct {
	%[3]s
	HttpResponse *http.Response
	%[2]s
}

`, responseStructName, model, lro)
	return &output, nil
}

func (c methodsAutoRestTemplater) senderLongRunningOperationTemplate(data ServiceGeneratorData) string {
	return fmt.Sprintf(`
// senderFor%[2]s sends the %[2]s request. The method will close the
// http.Response Body if it receives an error.
func (c %[1]s) senderFor%[2]s(ctx context.Context, req *http.Request) (future %[2]sOperationResponse, err error) {
	var resp *http.Response
	resp, err = c.Client.Send(req, azure.DoRetryWithRegistration(c.Client))
	if err != nil {
		return
	}
	
	future.Poller, err = polling.NewPollerFromResponse(ctx, resp, c.Client, req.Method)
	return
}
`, data.serviceClientName, c.operationName)
}

func (c methodsAutoRestTemplater) optionsStruct(data ServiceGeneratorData) (*string, error) {
	if len(c.operation.Options) == 0 {
		out := ""
		return &out, nil
	}

	optionsStructName := fmt.Sprintf("%sOperationOptions", c.operationName)
	if _, hasExisting := data.models[optionsStructName]; hasExisting {
		return nil, fmt.Errorf("existing model %q conflicts with options model for %q", optionsStructName, c.operationName)
	}

	properties := make([]string, 0)
	queryStringAssignments := make([]string, 0)
	headerAssignments := make([]string, 0)

	for optionName, option := range c.operation.Options {
		optionType, err := golangTypeNameForObjectDefinition(option.ObjectDefinition)
		if err != nil {
			return nil, fmt.Errorf("determining golang type name for option %q's ObjectDefinition: %+v", optionName, err)
		}
		properties = append(properties, fmt.Sprintf("%s *%s", optionName, *optionType))
		if option.HeaderName != nil {
			headerAssignments = append(headerAssignments, fmt.Sprintf(`
	if o.%[1]s != nil {
		out["%[2]s"] = *o.%[1]s
	}
`, optionName, *option.HeaderName))
		}
		if option.QueryStringName != nil {
			queryStringAssignments = append(queryStringAssignments, fmt.Sprintf(`
	if o.%[1]s != nil {
		out["%[2]s"] = *o.%[1]s
	}
`, optionName, *option.QueryStringName))
		}
	}

	sort.Strings(properties)
	sort.Strings(headerAssignments)
	sort.Strings(queryStringAssignments)

	out := fmt.Sprintf(`
type %[1]s struct {
%[2]s
}

func Default%[1]s() %[1]s {
	return %[1]s{}
}

func (o %[1]s) toHeaders() map[string]interface{} {
	out := make(map[string]interface{})
%[3]s
	return out
}

func (o %[1]s) toQueryString() map[string]interface{} {
	out := make(map[string]interface{})
%[4]s
	return out
}
`, optionsStructName, strings.Join(properties, "\n"), strings.Join(headerAssignments, "\n"), strings.Join(queryStringAssignments, "\n"))
	return &out, nil
}

func (c methodsAutoRestTemplater) discriminatedTypeName(input map[string]resourcemanager.ModelDetails) string {
	if c.operation.ResponseObject != nil && c.operation.ResponseObject.ReferenceName != nil {
		if name, ok := input[*c.operation.ResponseObject.ReferenceName]; ok && name.TypeHintIn != nil {
			return *c.operation.ResponseObject.ReferenceName
		}
	}

	return ""
}
