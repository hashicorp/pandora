package generator

import (
	"fmt"
	"sort"
	"strings"

	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

// TODO: should we expose a Description for each operation? seems not worthwhile
// TODO: implement predicates

// TODO: introduce a new Preparer for Lists which is Private and takes a nextLink in all cases

var _ templater = methodsAutoRestTemplater{}

type methodsAutoRestTemplater struct {
	operation     resourcemanager.ApiOperation
	operationName string
}

func (c methodsAutoRestTemplater) template(data ServiceGeneratorData) (*string, error) {
	methods, err := c.methods(data)
	if err != nil {
		return nil, err
	}

	template := fmt.Sprintf(`package %[1]s

import (
	"context"
	"fmt"
	"net/http"

	"github.com/Azure/go-autorest/autorest"
	"github.com/Azure/go-autorest/autorest/azure"
	"github.com/hashicorp/go-azure-helpers/polling"
)

%s
`, data.packageName, *methods)
	return &template, nil
}

func (c methodsAutoRestTemplater) methods(data ServiceGeneratorData) (*string, error) {
	// NOTE: most of this logic is sanity checking, but should be within the API and it's validators too
	// that could be a separate validation tool, but this would be most useful as unit tests

	switch strings.ToUpper(c.operation.Method) {
	case "DELETE":
		if c.operation.RequestObjectName != nil {
			// TODO: maybe implement this
			return nil, fmt.Errorf("`DELETE` operations do not support Request objects at this time")
		}
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

		if c.operation.RequestObjectName != nil {
			return nil, fmt.Errorf("`GET` operations do not support Request objects at this time")
		}

		if c.operation.ResponseObjectName == nil {
			return nil, fmt.Errorf("`GET` operations must have a Response object")
		}

		if c.operation.FieldContainingPaginationDetails != nil {
			return c.listOperationTemplate(data)
		}

		return c.immediateOperationTemplate(data)

	case "HEAD":
		if c.operation.LongRunning {
			return nil, fmt.Errorf("`HEAD` operations cannot be long running")
		}
		if c.operation.RequestObjectName != nil {
			return nil, fmt.Errorf("`HEAD` operations cannot have request objects")
		}
		if c.operation.ResponseObjectName != nil {
			return nil, fmt.Errorf("`HEAD` operations cannot have response objects")
		}

		if c.operation.FieldContainingPaginationDetails != nil {
			return nil, fmt.Errorf("pagination is not supported for HEAD Operations")
		}

		return c.immediateOperationTemplate(data)

	case "PATCH":
		if c.operation.RequestObjectName == nil {
			return nil, fmt.Errorf("`PATCH` operations must have a Request Object")
		}

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
			return nil, fmt.Errorf("pagination is not supported for POST Operations")
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
	argumentsMethodCode := c.argumentsTemplateForMethod()
	argumentsCode := c.argumentsTemplate()
	optionsStruct := c.optionsStruct()
	preparerCode := c.preparerTemplate(data)
	responseStruct := c.responseStructTemplate()
	responderCode := c.responderTemplate(data)
	templated := fmt.Sprintf(`
%[7]s
%[9]s

// %[2]s ...
func (c %[1]s) %[2]s(ctx context.Context, %[4]s) (result %[2]sResponse, err error) {
	req, err := c.%[2]sPreparer(ctx, %[8]s)
	if err != nil {
		err = autorest.NewErrorWithError(err, "%[3]s.%[1]s", "%[2]s", nil, "Failure preparing request")
		return
	}

	result.HttpResponse, err = c.Client.Send(req, azure.DoRetryWithRegistration(c.Client))
	if err != nil {
		err = autorest.NewErrorWithError(err, "%[3]s.%[1]s", "%[2]s", result.HttpResponse, "Failure sending request")
		return
	}

	result, err = c.%[2]sResponder(result.HttpResponse)
	if err != nil {
		err = autorest.NewErrorWithError(err, "%[3]s.%[1]s", "%[2]s", result.HttpResponse, "Failure responding to request")
		return
	}

	return
}

%[5]s

%[6]s
`, data.serviceClientName, c.operationName, data.packageName, argumentsMethodCode, preparerCode, responderCode, responseStruct, argumentsCode, optionsStruct)
	return &templated, nil
}

func (c methodsAutoRestTemplater) listOperationTemplate(data ServiceGeneratorData) (*string, error) {
	argumentsMethodCode := c.argumentsTemplateForMethod()
	argumentsCode := c.argumentsTemplate()
	listPredicateCode := c.listPredicateTemplate()
	optionsStruct := c.optionsStruct()
	preparerCode := c.preparerTemplate(data)
	responseStruct := c.responseStructTemplate()
	responderCode := c.responderTemplate(data)
	templated := fmt.Sprintf(`
%[7]s
%[9]s
%[10]s

// %[2]s ...
func (c %[1]s) %[2]s(ctx context.Context, %[4]s) (resp %[2]sResponse, err error) {
	req, err := c.%[2]sPreparer(ctx, %[8]s)
	if err != nil {
		err = autorest.NewErrorWithError(err, "%[3]s.%[1]s", "%[2]s", nil, "Failure preparing request")
		return
	}

	resp.HttpResponse, err = c.Client.Send(req, azure.DoRetryWithRegistration(c.Client))
	if err != nil {
		err = autorest.NewErrorWithError(err, "%[3]s.%[1]s", "%[2]s", resp.HttpResponse, "Failure sending request")
		return
	}

	resp, err = c.%[2]sResponder(resp.HttpResponse)
	if err != nil {
		err = autorest.NewErrorWithError(err, "%[3]s.%[1]s", "%[2]s", resp.HttpResponse, "Failure responding to request")
		return
	}
	return
}

// %[2]sCompleteMatchingPredicate retrieves all of the results into a single object
func (c %[1]s) %[2]sComplete(ctx context.Context, %[4]s) (%[2]sCompleteResult, error) {
	return c.%[2]sCompleteMatchingPredicate(ctx, %[8]s, %[11]sPredicate{})
}

// %[2]sCompleteMatchingPredicate retrieves all of the results and then applied the predicate
func (c %[1]s) %[2]sCompleteMatchingPredicate(ctx context.Context, %[4]s, predicate %[11]sPredicate) (resp %[2]sCompleteResult, err error) {
	items := make([]%[11]s, 0)

	page, err := c.%[2]s(ctx, %[8]s)
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
`, data.serviceClientName, c.operationName, data.packageName, argumentsMethodCode, preparerCode, responderCode, responseStruct, argumentsCode, optionsStruct, listPredicateCode, *c.operation.ResponseObjectName)
	return &templated, nil
}

func (c methodsAutoRestTemplater) longRunningOperationTemplate(data ServiceGeneratorData) (*string, error) {
	argumentsMethodCode := c.argumentsTemplateForMethod()
	argumentsCode := c.argumentsTemplate()
	optionsStruct := c.optionsStruct()
	preparerCode := c.preparerTemplate(data)
	responseStruct := c.responseStructTemplate()
	senderCode := c.senderLongRunningOperationTemplate(data)
	templated := fmt.Sprintf(`
%[7]s
%[9]s

// %[2]s ...
func (c %[1]s) %[2]s(ctx context.Context, %[4]s) (result %[2]sResponse, err error) {
	req, err := c.%[2]sPreparer(ctx, %[8]s)
	if err != nil {
		err = autorest.NewErrorWithError(err, "%[3]s.%[1]s", "%[2]s", nil, "Failure preparing request")
		return
	}

	result, err = c.%[2]sSender(ctx, req)
	if err != nil {
		err = autorest.NewErrorWithError(err, "%[3]s.%[1]s", "%[2]s", result.HttpResponse, "Failure sending request")
		return
	}

	return
}

// %[2]sThenPoll performs %[2]s then polls until it's completed
func (c %[1]s) %[2]sThenPoll(ctx context.Context, %[4]s) error {
	result, err := c.%[2]s(ctx, %[8]s)
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
`, data.serviceClientName, c.operationName, data.packageName, argumentsMethodCode, preparerCode, senderCode, responseStruct, argumentsCode, optionsStruct)
	return &templated, nil
}

func (c methodsAutoRestTemplater) argumentsTemplate() string {
	args := []string{}
	if c.operation.ResourceIdName != nil {
		args = append(args, "id")
	}
	if c.operation.RequestObjectName != nil {
		args = append(args, "input")
	}
	if len(c.operation.Options) > 0 {
		args = append(args, "options")
	}
	return strings.Join(args, ", ")
}

func (c methodsAutoRestTemplater) argumentsTemplateForMethod() string {
	arguments := []string{}
	if c.operation.ResourceIdName != nil {
		arguments = append(arguments, fmt.Sprintf("id %s", *c.operation.ResourceIdName))
	}
	if c.operation.RequestObjectName != nil {
		arguments = append(arguments, fmt.Sprintf("input %s", *c.operation.RequestObjectName))
	}
	if len(c.operation.Options) > 0 {
		arguments = append(arguments, fmt.Sprintf("options %sOptions", c.operationName))
	}
	return strings.Join(arguments, ", ")
}

func (c methodsAutoRestTemplater) preparerTemplate(data ServiceGeneratorData) string {
	apiVersion := "defaultApiVersion"
	if c.operation.ApiVersion != nil {
		apiVersion = fmt.Sprintf("%q", *c.operation.ApiVersion)
	}

	arguments := c.argumentsTemplateForMethod()

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

	if c.operation.RequestObjectName != nil {
		steps = append(steps, "autorest.WithJSON(input)")
		listSteps = append(listSteps, "autorest.WithJSON(input)")
	}
	steps = append(steps, "autorest.WithQueryParameters(queryParameters)")
	listSteps = append(listSteps, "autorest.WithQueryParameters(queryParameters)")

	optionsCode := ""
	if len(c.operation.Options) > 0 {
		optionsCode = `
	for k, v := range options.toQueryString() {
		queryParameters[k] = autorest.Encode("query", v)
	}`
	}

	template := `
// %[2]sPreparer prepares the %[2]s request.
func (c %[1]s) %[2]sPreparer(ctx context.Context, %[3]s) (*http.Request, error) {
	queryParameters := map[string]interface{}{
		"api-version": %[5]s,
	}
%[6]s

	preparer := autorest.CreatePreparer(
		%[4]s)
	return preparer.Prepare((&http.Request{}).WithContext(ctx))
}
`
	if c.operation.FieldContainingPaginationDetails != nil {
		template += `
// %[2]sPreparerWithNextLink prepares the %[2]s request with the given nextLink token.
func (c %[1]s) %[2]sPreparerWithNextLink(ctx context.Context, nextLink string) (*http.Request, error) {
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
		%[7]s)
	return preparer.Prepare((&http.Request{}).WithContext(ctx))
}
`
	}

	return fmt.Sprintf(template, data.serviceClientName, c.operationName, arguments, strings.Join(steps, ",\n\t\t"), apiVersion, optionsCode, strings.Join(listSteps, ",\n\t\t"))
}

func (c methodsAutoRestTemplater) responderTemplate(data ServiceGeneratorData) string {
	expectedStatusCodes := make([]string, 0)
	for _, statusCodeInt := range c.operation.ExpectedStatusCodes {
		statusCode := golangConstantForStatusCode(statusCodeInt)
		expectedStatusCodes = append(expectedStatusCodes, statusCode)
	}

	steps := make([]string, 0)
	steps = append(steps, fmt.Sprintf("azure.WithErrorUnlessStatusCode(%s)", strings.Join(expectedStatusCodes, ", ")))
	if c.operation.ResponseObjectName != nil {
		if c.operation.FieldContainingPaginationDetails != nil {
			steps = append(steps, "autorest.ByUnmarshallingJSON(&respObj)")
		} else {
			steps = append(steps, "autorest.ByUnmarshallingJSON(&result.Model)")
		}
	}
	steps = append(steps, "autorest.ByClosing()")

	if c.operation.FieldContainingPaginationDetails != nil {
		argumentsCode := c.argumentsTemplate()
		fields := make([]string, 0)
		fields = append(fields, fmt.Sprintf("Values []%s `json:%q`", *c.operation.ResponseObjectName, "value"))
		fields = append(fields, fmt.Sprintf("NextLink *string `json:%q`", *c.operation.FieldContainingPaginationDetails))
		return fmt.Sprintf(`
// %[2]sResponder handles the response to the %[2]s request. The method always
// closes the http.Response Body.
func (c %[1]s) %[2]sResponder(resp *http.Response) (result %[2]sResponse, err error) {
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
		result.nextPageFunc = func(ctx context.Context, nextLink string) (result %[2]sResponse, err error) {
			req, err := c.%[2]sPreparerWithNextLink(ctx, nextLink)
			if err != nil {
				err = autorest.NewErrorWithError(err, "%[6]s.%[1]s", "%[2]s", nil, "Failure preparing request")
				return
			}
		
			result.HttpResponse, err = c.Client.Send(req, azure.DoRetryWithRegistration(c.Client))
			if err != nil {
				err = autorest.NewErrorWithError(err, "%[6]s.%[1]s", "%[2]s", result.HttpResponse, "Failure sending request")
				return
			}
		
			result, err = c.%[2]sResponder(result.HttpResponse)
			if err != nil {
				err = autorest.NewErrorWithError(err, "%[6]s.%[1]s", "%[2]s", result.HttpResponse, "Failure responding to request")
				return
			}

			return
		}
	}
	return
}
`, data.serviceClientName, c.operationName, strings.Join(steps, ",\n\t\t"), strings.Join(fields, "\n\t\t"), argumentsCode, data.packageName)
	}

	return fmt.Sprintf(`
// %[2]sResponder handles the response to the %[2]s request. The method always
// closes the http.Response Body.
func (c %[1]s) %[2]sResponder(resp *http.Response) (result %[2]sResponse, err error) {
	err = autorest.Respond(
		resp,
		%[3]s)
	result.HttpResponse = resp
	result.nextLink = respObj.nextLink
	return
}
`, data.serviceClientName, c.operationName, strings.Join(steps, ",\n\t\t"))
}

func (c methodsAutoRestTemplater) responseStructTemplate() string {
	model := ""
	if c.operation.ResponseObjectName != nil {
		if c.operation.FieldContainingPaginationDetails != nil {
			model = fmt.Sprintf("Model *[]%s", *c.operation.ResponseObjectName)
		} else {
			model = fmt.Sprintf("Model *%s", *c.operation.ResponseObjectName)
		}
	}

	lro := ""
	if c.operation.LongRunning {
		lro = fmt.Sprintf("Poller polling.LongRunningPoller")
	}

	paginationFields := ""
	paginationCode := ""
	if c.operation.FieldContainingPaginationDetails != nil {
		// whilst these looks like they could crash it's guaranteed above
		paginationCode = fmt.Sprintf(`
type %[2]sCompleteResult struct {
	Items   []%[1]s
}

func (r %[2]sResponse) HasMore() bool {
	return r.nextLink != nil
}

func (r %[2]sResponse) LoadMore(ctx context.Context) (resp %[2]sResponse, err error) {
	if !r.HasMore() {
		err = fmt.Errorf("no more pages returned")
		return
	}
	return r.nextPageFunc(ctx, *r.nextLink)
}
`, *c.operation.ResponseObjectName, c.operationName)
		paginationFields = fmt.Sprintf(`
	nextLink *string
	nextPageFunc func(ctx context.Context, nextLink string) (%[2]sResponse, error)
`, *c.operation.ResponseObjectName, c.operationName)

		return fmt.Sprintf(`
type %[1]sResponse struct {
	%[3]s
	HttpResponse *http.Response
	%[2]s
	%[5]s
}

%[4]s
`, c.operationName, model, lro, paginationCode, paginationFields)
	}

	return fmt.Sprintf(`
type %[1]sResponse struct {
	%[3]s
	HttpResponse *http.Response
	%[2]s
}

`, c.operationName, model, lro)
}

func (c methodsAutoRestTemplater) senderLongRunningOperationTemplate(data ServiceGeneratorData) string {
	return fmt.Sprintf(`
// %[2]sSender sends the %[2]s request. The method will close the
// http.Response Body if it receives an error.
func (c %[1]s) %[2]sSender(ctx context.Context, req *http.Request) (future %[2]sResponse, err error) {
	var resp *http.Response
	resp, err = c.Client.Send(req, azure.DoRetryWithRegistration(c.Client))
	if err != nil {
		return
	}
	future.Poller, err = polling.NewLongRunningPollerFromResponse(ctx, resp, c.Client)
	return
}
`, data.serviceClientName, c.operationName)
}

func (c methodsAutoRestTemplater) optionsStruct() string {
	if len(c.operation.Options) == 0 {
		return ""
	}

	properties := make([]string, 0)
	assignments := make([]string, 0)

	for optionName, option := range c.operation.Options {
		var optionTypeName = func(input resourcemanager.OperationFieldType) string {
			switch input {
			case resourcemanager.OperationFieldTypeBoolean:
				return "bool"
			case resourcemanager.OperationFieldTypeInteger:
				return "int64"
			case resourcemanager.OperationFieldTypeString:
				return "string"
			default:
				panic(fmt.Sprintf("the operation type %q is not implemented", input))
			}
		}

		optionType := optionTypeName(option.FieldType)
		properties = append(properties, fmt.Sprintf("%s *%s", optionName, optionType))
		assignments = append(assignments, fmt.Sprintf(`
	if o.%[1]s != nil {
		out["%[2]s"] = *o.%[1]s
	}
`, optionName, option.QueryStringName))
	}

	sort.Strings(properties)
	sort.Strings(assignments)

	return fmt.Sprintf(`
type %[1]sOptions struct {
%[2]s
}

func Default%[1]sOptions() %[1]sOptions {
	return %[1]sOptions{}
} 

func (o %[1]sOptions) toQueryString() map[string]interface{} {
	out := make(map[string]interface{}, 0)
%[3]s
	return out
}
`, c.operationName, strings.Join(properties, "\n"), strings.Join(assignments, "\n"))
}

func (c methodsAutoRestTemplater) listPredicateTemplate() string {
	return fmt.Sprintf(` 
type %[1]sPredicate struct {
	// TODO: implement me
}

func (p %[1]sPredicate) Matches(input %[1]s) bool {
	// TODO: implement me
	// if p.Name != nil && input.Name != *p.Name {
	// 	return false
	// }

	return true
}
`, *c.operation.ResponseObjectName)
}
