package differ

import (
	"net/http"
	"testing"

	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	"github.com/hashicorp/pandora/tools/data-api-differ/internal/changes"
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

func TestDiff_OperationAddedWithResourceId(t *testing.T) {
	initial := map[string]resourcemanager.ApiOperation{
		"First": {},
	}
	updated := map[string]resourcemanager.ApiOperation{
		"First": {},
		"Second": {
			ResourceIdName: pointer.To("SomeId"),
		},
	}
	ids := map[string]resourcemanager.ResourceIdDefinition{
		"SomeId": {
			Id: "/some/resource/id",
		},
	}
	actual, err := differ{}.changesForOperations("Computer", "2020-01-01", "Example", initial, updated, ids, ids)
	if err != nil {
		t.Fatalf(err.Error())
	}
	expected := []changes.Change{
		changes.OperationAdded{
			ServiceName:   "Computer",
			ApiVersion:    "2020-01-01",
			ResourceName:  "Example",
			OperationName: "Second",
			Uri:           "/some/resource/id",
		},
	}
	assertChanges(t, expected, *actual)
	assertContainsNoBreakingChanges(t, *actual)
}

func TestDiff_OperationAddedWithResourceIdAndUriSuffix(t *testing.T) {
	initial := map[string]resourcemanager.ApiOperation{
		"First": {},
	}
	updated := map[string]resourcemanager.ApiOperation{
		"First": {},
		"Second": {
			ResourceIdName: pointer.To("SomeId"),
			UriSuffix:      pointer.To("/example"),
		},
	}
	ids := map[string]resourcemanager.ResourceIdDefinition{
		"SomeId": {
			Id: "/some/resource/id",
		},
	}
	actual, err := differ{}.changesForOperations("Computer", "2020-01-01", "Example", initial, updated, ids, ids)
	if err != nil {
		t.Fatalf(err.Error())
	}
	expected := []changes.Change{
		changes.OperationAdded{
			ServiceName:   "Computer",
			ApiVersion:    "2020-01-01",
			ResourceName:  "Example",
			OperationName: "Second",
			Uri:           "/some/resource/id/example",
		},
	}
	assertChanges(t, expected, *actual)
	assertContainsNoBreakingChanges(t, *actual)
}

func TestDiff_OperationAddedWithUriSuffix(t *testing.T) {
	initial := map[string]resourcemanager.ApiOperation{
		"First": {},
	}
	updated := map[string]resourcemanager.ApiOperation{
		"First": {},
		"Second": {
			UriSuffix: pointer.To("/example"),
		},
	}
	ids := make(map[string]resourcemanager.ResourceIdDefinition)
	actual, err := differ{}.changesForOperations("Computer", "2020-01-01", "Example", initial, updated, ids, ids)
	if err != nil {
		t.Fatalf(err.Error())
	}
	expected := []changes.Change{
		changes.OperationAdded{
			ServiceName:   "Computer",
			ApiVersion:    "2020-01-01",
			ResourceName:  "Example",
			OperationName: "Second",
			Uri:           "/example",
		},
	}
	assertChanges(t, expected, *actual)
	assertContainsNoBreakingChanges(t, *actual)
}

func TestDiff_OperationContentTypeChanged(t *testing.T) {
	initial := map[string]resourcemanager.ApiOperation{
		"First": {
			ContentType: pointer.To("application/json"),
		},
	}
	updated := map[string]resourcemanager.ApiOperation{
		"First": {
			ContentType: pointer.To("text/xml"),
		},
	}
	ids := make(map[string]resourcemanager.ResourceIdDefinition)
	actual, err := differ{}.changesForOperations("Computer", "2020-01-01", "Example", initial, updated, ids, ids)
	if err != nil {
		t.Fatalf(err.Error())
	}
	expected := []changes.Change{
		changes.OperationContentTypeChanged{
			ServiceName:    "Computer",
			ApiVersion:     "2020-01-01",
			ResourceName:   "Example",
			OperationName:  "First",
			OldContentType: "application/json",
			NewContentType: "text/xml",
		},
	}
	assertChanges(t, expected, *actual)
	assertContainsBreakingChanges(t, *actual)
}

func TestDiff_OperationExpectedStatusCodeChanged(t *testing.T) {
	initial := map[string]resourcemanager.ApiOperation{
		"First": {
			ExpectedStatusCodes: []int{200},
		},
	}
	updated := map[string]resourcemanager.ApiOperation{
		"First": {
			ExpectedStatusCodes: []int{200, 202},
		},
	}
	ids := make(map[string]resourcemanager.ResourceIdDefinition)
	actual, err := differ{}.changesForOperations("Computer", "2020-01-01", "Example", initial, updated, ids, ids)
	if err != nil {
		t.Fatalf(err.Error())
	}
	expected := []changes.Change{
		changes.OperationExpectedStatusCodesChanged{
			ServiceName:            "Computer",
			ApiVersion:             "2020-01-01",
			ResourceName:           "Example",
			OperationName:          "First",
			OldExpectedStatusCodes: []int{200},
			NewExpectedStatusCodes: []int{200, 202},
		},
	}
	assertChanges(t, expected, *actual)
	assertContainsNoBreakingChanges(t, *actual)
}

func TestDiff_OperationExpectedStatusCodeChangedBreakingChange(t *testing.T) {
	// ExpectedStatusCodes is /conditionally/ a breaking change, if a Status Code is removed then it's a breaking change
	// else it's not
	initial := map[string]resourcemanager.ApiOperation{
		"First": {
			ExpectedStatusCodes: []int{200, 202},
		},
	}
	updated := map[string]resourcemanager.ApiOperation{
		"First": {
			ExpectedStatusCodes: []int{200},
		},
	}
	ids := make(map[string]resourcemanager.ResourceIdDefinition)
	actual, err := differ{}.changesForOperations("Computer", "2020-01-01", "Example", initial, updated, ids, ids)
	if err != nil {
		t.Fatalf(err.Error())
	}
	expected := []changes.Change{
		changes.OperationExpectedStatusCodesChanged{
			ServiceName:            "Computer",
			ApiVersion:             "2020-01-01",
			ResourceName:           "Example",
			OperationName:          "First",
			OldExpectedStatusCodes: []int{200, 202},
			NewExpectedStatusCodes: []int{200},
		},
	}
	assertChanges(t, expected, *actual)
	assertContainsBreakingChanges(t, *actual)
}

func TestDiff_OperationLongRunningAdded(t *testing.T) {
	initial := map[string]resourcemanager.ApiOperation{
		"First": {
			LongRunning: false,
		},
	}
	updated := map[string]resourcemanager.ApiOperation{
		"First": {
			LongRunning: true,
		},
	}
	ids := make(map[string]resourcemanager.ResourceIdDefinition)
	actual, err := differ{}.changesForOperations("Computer", "2020-01-01", "Example", initial, updated, ids, ids)
	if err != nil {
		t.Fatalf(err.Error())
	}
	expected := []changes.Change{
		changes.OperationLongRunningAdded{
			ServiceName:   "Computer",
			ApiVersion:    "2020-01-01",
			ResourceName:  "Example",
			OperationName: "First",
		},
	}
	assertChanges(t, expected, *actual)
	assertContainsBreakingChanges(t, *actual)
}

func TestDiff_OperationLongRunningRemoved(t *testing.T) {
	initial := map[string]resourcemanager.ApiOperation{
		"First": {
			LongRunning: true,
		},
	}
	updated := map[string]resourcemanager.ApiOperation{
		"First": {
			LongRunning: false,
		},
	}
	ids := make(map[string]resourcemanager.ResourceIdDefinition)
	actual, err := differ{}.changesForOperations("Computer", "2020-01-01", "Example", initial, updated, ids, ids)
	if err != nil {
		t.Fatalf(err.Error())
	}
	expected := []changes.Change{
		changes.OperationLongRunningRemoved{
			ServiceName:   "Computer",
			ApiVersion:    "2020-01-01",
			ResourceName:  "Example",
			OperationName: "First",
		},
	}
	assertChanges(t, expected, *actual)
	assertContainsBreakingChanges(t, *actual)
}

func TestDiff_OperationMethodChanged(t *testing.T) {
	initial := map[string]resourcemanager.ApiOperation{
		"First": {
			Method: http.MethodHead,
		},
	}
	updated := map[string]resourcemanager.ApiOperation{
		"First": {
			Method: http.MethodGet,
		},
	}
	ids := make(map[string]resourcemanager.ResourceIdDefinition)
	actual, err := differ{}.changesForOperations("Computer", "2020-01-01", "Example", initial, updated, ids, ids)
	if err != nil {
		t.Fatalf(err.Error())
	}
	expected := []changes.Change{
		changes.OperationMethodChanged{
			ServiceName:   "Computer",
			ApiVersion:    "2020-01-01",
			ResourceName:  "Example",
			OperationName: "First",
			OldValue:      http.MethodHead,
			NewValue:      http.MethodGet,
		},
	}
	assertChanges(t, expected, *actual)
	assertContainsBreakingChanges(t, *actual)
}

func TestDiff_OperationOptionsAdded(t *testing.T) {
	initial := map[string]resourcemanager.ApiOperation{
		"First": {
			Options: nil,
		},
	}
	updated := map[string]resourcemanager.ApiOperation{
		"First": {
			Options: map[string]resourcemanager.ApiOperationOption{
				"Expand": {
					QueryStringName: pointer.To("expand"),
					Required:        false,
					ObjectDefinition: resourcemanager.ApiObjectDefinition{
						Type: resourcemanager.StringApiObjectDefinitionType,
					},
				},
			},
		},
	}
	ids := make(map[string]resourcemanager.ResourceIdDefinition)
	actual, err := differ{}.changesForOperations("Computer", "2020-01-01", "Example", initial, updated, ids, ids)
	if err != nil {
		t.Fatalf(err.Error())
	}
	expected := []changes.Change{
		changes.OperationOptionsAdded{
			ServiceName:   "Computer",
			ApiVersion:    "2020-01-01",
			ResourceName:  "Example",
			OperationName: "First",
			NewValue: map[string]string{
				"Expand": `ObjectDefinition "string" / Required false / QueryStringName "expand"`,
			},
		},
	}
	assertChanges(t, expected, *actual)
	assertContainsBreakingChanges(t, *actual)
}

func TestDiff_OperationOptionsChanged(t *testing.T) {
	// Adding a new Option to an existing set of Options is not a breaking change
	initial := map[string]resourcemanager.ApiOperation{
		"First": {
			Options: map[string]resourcemanager.ApiOperationOption{
				"Expand": {
					QueryStringName: pointer.To("expand"),
					Required:        false,
					ObjectDefinition: resourcemanager.ApiObjectDefinition{
						Type: resourcemanager.StringApiObjectDefinitionType,
					},
				},
			},
		},
	}
	updated := map[string]resourcemanager.ApiOperation{
		"First": {
			Options: map[string]resourcemanager.ApiOperationOption{
				"Expand": {
					QueryStringName: pointer.To("expand"),
					Required:        false,
					ObjectDefinition: resourcemanager.ApiObjectDefinition{
						Type: resourcemanager.StringApiObjectDefinitionType,
					},
				},
				"Other": {
					QueryStringName: pointer.To("other"),
					Required:        false,
					ObjectDefinition: resourcemanager.ApiObjectDefinition{
						Type: resourcemanager.StringApiObjectDefinitionType,
					},
				},
			},
		},
	}
	ids := make(map[string]resourcemanager.ResourceIdDefinition)
	actual, err := differ{}.changesForOperations("Computer", "2020-01-01", "Example", initial, updated, ids, ids)
	if err != nil {
		t.Fatalf(err.Error())
	}
	expected := []changes.Change{
		changes.OperationOptionsChanged{
			ServiceName:   "Computer",
			ApiVersion:    "2020-01-01",
			ResourceName:  "Example",
			OperationName: "First",
			OldValue: map[string]string{
				"Expand": `ObjectDefinition "string" / Required false / QueryStringName "expand"`,
			},
			NewValue: map[string]string{
				"Expand": `ObjectDefinition "string" / Required false / QueryStringName "expand"`,
				"Other":  `ObjectDefinition "string" / Required false / QueryStringName "other"`,
			},
		},
	}
	assertChanges(t, expected, *actual)
	assertContainsNoBreakingChanges(t, *actual)
}

func TestDiff_OperationOptionsChangedBreakingChange(t *testing.T) {
	// Changing the ObjectDefinition for an existing Object is a breaking change
	initial := map[string]resourcemanager.ApiOperation{
		"First": {
			Options: map[string]resourcemanager.ApiOperationOption{
				"Expand": {
					QueryStringName: pointer.To("expand"),
					Required:        false,
					ObjectDefinition: resourcemanager.ApiObjectDefinition{
						Type: resourcemanager.StringApiObjectDefinitionType,
					},
				},
			},
		},
	}
	updated := map[string]resourcemanager.ApiOperation{
		"First": {
			Options: map[string]resourcemanager.ApiOperationOption{
				"Expand": {
					QueryStringName: pointer.To("expand"),
					Required:        false,
					ObjectDefinition: resourcemanager.ApiObjectDefinition{
						Type:          resourcemanager.ReferenceApiObjectDefinitionType,
						ReferenceName: pointer.To("SomeConstant"),
					},
				},
			},
		},
	}
	ids := make(map[string]resourcemanager.ResourceIdDefinition)
	actual, err := differ{}.changesForOperations("Computer", "2020-01-01", "Example", initial, updated, ids, ids)
	if err != nil {
		t.Fatalf(err.Error())
	}
	expected := []changes.Change{
		changes.OperationOptionsChanged{
			ServiceName:   "Computer",
			ApiVersion:    "2020-01-01",
			ResourceName:  "Example",
			OperationName: "First",
			OldValue: map[string]string{
				"Expand": `ObjectDefinition "string" / Required false / QueryStringName "expand"`,
			},
			NewValue: map[string]string{
				"Expand": `ObjectDefinition "SomeConstant" / Required false / QueryStringName "expand"`,
			},
		},
	}
	assertChanges(t, expected, *actual)
	assertContainsBreakingChanges(t, *actual)
}

func TestDiff_OperationOptionsRemoved(t *testing.T) {
	initial := map[string]resourcemanager.ApiOperation{
		"First": {
			Options: map[string]resourcemanager.ApiOperationOption{
				"Expand": {
					QueryStringName: pointer.To("expand"),
					Required:        false,
					ObjectDefinition: resourcemanager.ApiObjectDefinition{
						Type: resourcemanager.StringApiObjectDefinitionType,
					},
				},
			},
		},
	}
	updated := map[string]resourcemanager.ApiOperation{
		"First": {
			Options: nil,
		},
	}
	ids := make(map[string]resourcemanager.ResourceIdDefinition)
	actual, err := differ{}.changesForOperations("Computer", "2020-01-01", "Example", initial, updated, ids, ids)
	if err != nil {
		t.Fatalf(err.Error())
	}
	expected := []changes.Change{
		changes.OperationOptionsRemoved{
			ServiceName:   "Computer",
			ApiVersion:    "2020-01-01",
			ResourceName:  "Example",
			OperationName: "First",
			OldValue: map[string]string{
				"Expand": `ObjectDefinition "string" / Required false / QueryStringName "expand"`,
			},
		},
	}
	assertChanges(t, expected, *actual)
	assertContainsBreakingChanges(t, *actual)
}

func TestDiff_OperationPaginationFieldChanged(t *testing.T) {
	initial := map[string]resourcemanager.ApiOperation{
		"First": {
			FieldContainingPaginationDetails: pointer.To("OldField"),
		},
	}
	updated := map[string]resourcemanager.ApiOperation{
		"First": {
			FieldContainingPaginationDetails: pointer.To("NewField"),
		},
	}
	ids := make(map[string]resourcemanager.ResourceIdDefinition)
	actual, err := differ{}.changesForOperations("Computer", "2020-01-01", "Example", initial, updated, ids, ids)
	if err != nil {
		t.Fatalf(err.Error())
	}
	expected := []changes.Change{
		changes.OperationPaginationFieldChanged{
			ServiceName:   "Computer",
			ApiVersion:    "2020-01-01",
			ResourceName:  "Example",
			OperationName: "First",
			OldValue:      "OldField",
			NewValue:      "NewField",
		},
	}
	assertChanges(t, expected, *actual)
	assertContainsBreakingChanges(t, *actual)
}

func TestDiff_OperationRemovedWithResourceId(t *testing.T) {
	initial := map[string]resourcemanager.ApiOperation{
		"First": {},
		"Second": {
			ResourceIdName: pointer.To("SomeId"),
		},
	}
	updated := map[string]resourcemanager.ApiOperation{
		"First": {},
	}
	ids := map[string]resourcemanager.ResourceIdDefinition{
		"SomeId": {
			Id: "/some/example/id",
		},
	}
	actual, err := differ{}.changesForOperations("Computer", "2020-01-01", "Example", initial, updated, ids, ids)
	if err != nil {
		t.Fatalf(err.Error())
	}
	expected := []changes.Change{
		changes.OperationRemoved{
			ServiceName:   "Computer",
			ApiVersion:    "2020-01-01",
			ResourceName:  "Example",
			OperationName: "Second",
			Uri:           "/some/example/id",
		},
	}
	assertChanges(t, expected, *actual)
	assertContainsBreakingChanges(t, *actual)
}

func TestDiff_OperationRemovedWithResourceIdAndUriSuffix(t *testing.T) {
	initial := map[string]resourcemanager.ApiOperation{
		"First": {},
		"Second": {
			ResourceIdName: pointer.To("SomeId"),
			UriSuffix:      pointer.To("/example"),
		},
	}
	updated := map[string]resourcemanager.ApiOperation{
		"First": {},
	}
	ids := map[string]resourcemanager.ResourceIdDefinition{
		"SomeId": {
			Id: "/some/example/id",
		},
	}
	actual, err := differ{}.changesForOperations("Computer", "2020-01-01", "Example", initial, updated, ids, ids)
	if err != nil {
		t.Fatalf(err.Error())
	}
	expected := []changes.Change{
		changes.OperationRemoved{
			ServiceName:   "Computer",
			ApiVersion:    "2020-01-01",
			ResourceName:  "Example",
			OperationName: "Second",
			Uri:           "/some/example/id/example",
		},
	}
	assertChanges(t, expected, *actual)
	assertContainsBreakingChanges(t, *actual)
}

func TestDiff_OperationRemovedWithUriSuffix(t *testing.T) {
	initial := map[string]resourcemanager.ApiOperation{
		"First": {},
		"Second": {
			UriSuffix: pointer.To("/example"),
		},
	}
	updated := map[string]resourcemanager.ApiOperation{
		"First": {},
	}
	ids := make(map[string]resourcemanager.ResourceIdDefinition)
	actual, err := differ{}.changesForOperations("Computer", "2020-01-01", "Example", initial, updated, ids, ids)
	if err != nil {
		t.Fatalf(err.Error())
	}
	expected := []changes.Change{
		changes.OperationRemoved{
			ServiceName:   "Computer",
			ApiVersion:    "2020-01-01",
			ResourceName:  "Example",
			OperationName: "Second",
			Uri:           "/example",
		},
	}
	assertChanges(t, expected, *actual)
	assertContainsBreakingChanges(t, *actual)
}

func TestDiff_OperationRequestObjectAdded(t *testing.T) {
	initial := map[string]resourcemanager.ApiOperation{
		"First": {
			RequestObject: nil,
		},
	}
	updated := map[string]resourcemanager.ApiOperation{
		"First": {
			RequestObject: &resourcemanager.ApiObjectDefinition{
				Type: resourcemanager.StringApiObjectDefinitionType,
			},
		},
	}
	ids := make(map[string]resourcemanager.ResourceIdDefinition)
	actual, err := differ{}.changesForOperations("Computer", "2020-01-01", "Example", initial, updated, ids, ids)
	if err != nil {
		t.Fatalf(err.Error())
	}
	expected := []changes.Change{
		changes.OperationRequestObjectAdded{
			ServiceName:      "Computer",
			ApiVersion:       "2020-01-01",
			ResourceName:     "Example",
			OperationName:    "First",
			NewRequestObject: "string",
		},
	}
	assertChanges(t, expected, *actual)
	assertContainsBreakingChanges(t, *actual)
}

func TestDiff_OperationRequestObjectChanged(t *testing.T) {
	initial := map[string]resourcemanager.ApiOperation{
		"First": {
			RequestObject: &resourcemanager.ApiObjectDefinition{
				Type: resourcemanager.StringApiObjectDefinitionType,
			},
		},
	}
	updated := map[string]resourcemanager.ApiOperation{
		"First": {
			RequestObject: &resourcemanager.ApiObjectDefinition{
				Type:          resourcemanager.ReferenceApiObjectDefinitionType,
				ReferenceName: pointer.To("SomeConstant"),
			},
		},
	}
	ids := make(map[string]resourcemanager.ResourceIdDefinition)
	actual, err := differ{}.changesForOperations("Computer", "2020-01-01", "Example", initial, updated, ids, ids)
	if err != nil {
		t.Fatalf(err.Error())
	}
	expected := []changes.Change{
		changes.OperationRequestObjectChanged{
			ServiceName:      "Computer",
			ApiVersion:       "2020-01-01",
			ResourceName:     "Example",
			OperationName:    "First",
			OldRequestObject: "string",
			NewRequestObject: "SomeConstant",
		},
	}
	assertChanges(t, expected, *actual)
	assertContainsBreakingChanges(t, *actual)
}

func TestDiff_OperationRequestObjectRemoved(t *testing.T) {
	initial := map[string]resourcemanager.ApiOperation{
		"First": {
			RequestObject: &resourcemanager.ApiObjectDefinition{
				Type: resourcemanager.StringApiObjectDefinitionType,
			},
		},
	}
	updated := map[string]resourcemanager.ApiOperation{
		"First": {
			RequestObject: nil,
		},
	}
	ids := make(map[string]resourcemanager.ResourceIdDefinition)
	actual, err := differ{}.changesForOperations("Computer", "2020-01-01", "Example", initial, updated, ids, ids)
	if err != nil {
		t.Fatalf(err.Error())
	}
	expected := []changes.Change{
		changes.OperationRequestObjectRemoved{
			ServiceName:      "Computer",
			ApiVersion:       "2020-01-01",
			ResourceName:     "Example",
			OperationName:    "First",
			OldRequestObject: "string",
		},
	}
	assertChanges(t, expected, *actual)
	assertContainsBreakingChanges(t, *actual)
}

func TestDiff_OperationResourceIDAdded(t *testing.T) {
	initial := map[string]resourcemanager.ApiOperation{
		"First": {
			ResourceIdName: nil,
		},
	}
	updated := map[string]resourcemanager.ApiOperation{
		"First": {
			ResourceIdName: pointer.To("Example"),
		},
	}
	oldIds := make(map[string]resourcemanager.ResourceIdDefinition)
	newIds := map[string]resourcemanager.ResourceIdDefinition{
		"Example": {
			Id: "/some/example/id",
		},
	}
	actual, err := differ{}.changesForOperations("Computer", "2020-01-01", "Example", initial, updated, oldIds, newIds)
	if err != nil {
		t.Fatalf(err.Error())
	}
	expected := []changes.Change{
		changes.OperationResourceIdAdded{
			ServiceName:       "Computer",
			ApiVersion:        "2020-01-01",
			ResourceName:      "Example",
			OperationName:     "First",
			NewResourceIdName: "Example",
		},
	}
	assertChanges(t, expected, *actual)
	assertContainsBreakingChanges(t, *actual)
}

func TestDiff_OperationResourceIDChangedUri(t *testing.T) {
	initial := map[string]resourcemanager.ApiOperation{
		"SomeOperation": {
			ResourceIdName: pointer.To("First"),
		},
	}
	updated := map[string]resourcemanager.ApiOperation{
		"SomeOperation": {
			ResourceIdName: pointer.To("First"),
		},
	}
	oldIds := map[string]resourcemanager.ResourceIdDefinition{
		"First": {
			Id: "/some/example/id",
		},
	}
	newIds := map[string]resourcemanager.ResourceIdDefinition{
		"First": {
			Id: "/some/other/id",
		},
	}
	actual, err := differ{}.changesForOperations("Computer", "2020-01-01", "Example", initial, updated, oldIds, newIds)
	if err != nil {
		t.Fatalf(err.Error())
	}
	expected := []changes.Change{
		changes.OperationResourceIdChanged{
			ServiceName:       "Computer",
			ApiVersion:        "2020-01-01",
			ResourceName:      "Example",
			OperationName:     "SomeOperation",
			OldResourceIdName: "First",
			NewResourceIdName: "First",
			OldValue:          "/some/example/id",
			NewValue:          "/some/other/id",
		},
	}
	assertChanges(t, expected, *actual)
	assertContainsBreakingChanges(t, *actual)
}

func TestDiff_OperationResourceIDChangedNameAndUri(t *testing.T) {
	initial := map[string]resourcemanager.ApiOperation{
		"SomeOperation": {
			ResourceIdName: pointer.To("First"),
		},
	}
	updated := map[string]resourcemanager.ApiOperation{
		"SomeOperation": {
			ResourceIdName: pointer.To("Second"),
		},
	}
	oldIds := map[string]resourcemanager.ResourceIdDefinition{
		"First": {
			Id: "/some/example/id",
		},
	}
	newIds := map[string]resourcemanager.ResourceIdDefinition{
		"Second": {
			Id: "/some/other/id",
		},
	}
	actual, err := differ{}.changesForOperations("Computer", "2020-01-01", "Example", initial, updated, oldIds, newIds)
	if err != nil {
		t.Fatalf(err.Error())
	}
	expected := []changes.Change{
		changes.OperationResourceIdRenamed{
			ServiceName:       "Computer",
			ApiVersion:        "2020-01-01",
			ResourceName:      "Example",
			OperationName:     "SomeOperation",
			OldResourceIdName: "First",
			NewResourceIdName: "Second",
		},
		changes.OperationResourceIdChanged{
			ServiceName:       "Computer",
			ApiVersion:        "2020-01-01",
			ResourceName:      "Example",
			OperationName:     "SomeOperation",
			OldResourceIdName: "First",
			NewResourceIdName: "Second",
			OldValue:          "/some/example/id",
			NewValue:          "/some/other/id",
		},
	}
	assertChanges(t, expected, *actual)
	assertContainsBreakingChanges(t, *actual)
}

func TestDiff_OperationResourceIDRemoved(t *testing.T) {
	initial := map[string]resourcemanager.ApiOperation{
		"First": {
			ResourceIdName: pointer.To("Example"),
		},
	}
	updated := map[string]resourcemanager.ApiOperation{
		"First": {
			ResourceIdName: nil,
		},
	}
	oldIds := map[string]resourcemanager.ResourceIdDefinition{
		"Example": {
			Id: "/some/example/id",
		},
	}
	newIds := make(map[string]resourcemanager.ResourceIdDefinition)
	actual, err := differ{}.changesForOperations("Computer", "2020-01-01", "Example", initial, updated, oldIds, newIds)
	if err != nil {
		t.Fatalf(err.Error())
	}
	expected := []changes.Change{
		changes.OperationResourceIdRemoved{
			ServiceName:       "Computer",
			ApiVersion:        "2020-01-01",
			ResourceName:      "Example",
			OperationName:     "First",
			OldResourceIdName: "Example",
		},
	}
	assertChanges(t, expected, *actual)
	assertContainsBreakingChanges(t, *actual)
}

func TestDiff_OperationResourceIDRenamed(t *testing.T) {
	initial := map[string]resourcemanager.ApiOperation{
		"SomeOperation": {
			ResourceIdName: pointer.To("First"),
		},
	}
	updated := map[string]resourcemanager.ApiOperation{
		"SomeOperation": {
			ResourceIdName: pointer.To("Second"),
		},
	}
	oldIds := map[string]resourcemanager.ResourceIdDefinition{
		"First": {
			Id: "/some/example/id",
		},
	}
	newIds := map[string]resourcemanager.ResourceIdDefinition{
		"Second": {
			Id: "/some/example/id",
		},
	}
	actual, err := differ{}.changesForOperations("Computer", "2020-01-01", "Example", initial, updated, oldIds, newIds)
	if err != nil {
		t.Fatalf(err.Error())
	}
	expected := []changes.Change{
		changes.OperationResourceIdRenamed{
			ServiceName:       "Computer",
			ApiVersion:        "2020-01-01",
			ResourceName:      "Example",
			OperationName:     "SomeOperation",
			OldResourceIdName: "First",
			NewResourceIdName: "Second",
		},
	}
	assertChanges(t, expected, *actual)
	assertContainsBreakingChanges(t, *actual)
}

func TestDiff_OperationResponseObjectAdded(t *testing.T) {
	initial := map[string]resourcemanager.ApiOperation{
		"First": {
			ResponseObject: nil,
		},
	}
	updated := map[string]resourcemanager.ApiOperation{
		"First": {
			ResponseObject: &resourcemanager.ApiObjectDefinition{
				Type: resourcemanager.StringApiObjectDefinitionType,
			},
		},
	}
	ids := make(map[string]resourcemanager.ResourceIdDefinition)
	actual, err := differ{}.changesForOperations("Computer", "2020-01-01", "Example", initial, updated, ids, ids)
	if err != nil {
		t.Fatalf(err.Error())
	}
	expected := []changes.Change{
		changes.OperationResponseObjectAdded{
			ServiceName:       "Computer",
			ApiVersion:        "2020-01-01",
			ResourceName:      "Example",
			OperationName:     "First",
			NewResponseObject: "string",
		},
	}
	assertChanges(t, expected, *actual)
	assertContainsBreakingChanges(t, *actual)
}

func TestDiff_OperationResponseObjectChanged(t *testing.T) {
	initial := map[string]resourcemanager.ApiOperation{
		"First": {
			ResponseObject: &resourcemanager.ApiObjectDefinition{
				Type: resourcemanager.StringApiObjectDefinitionType,
			},
		},
	}
	updated := map[string]resourcemanager.ApiOperation{
		"First": {
			ResponseObject: &resourcemanager.ApiObjectDefinition{
				Type:          resourcemanager.ReferenceApiObjectDefinitionType,
				ReferenceName: pointer.To("SomeConstant"),
			},
		},
	}
	ids := make(map[string]resourcemanager.ResourceIdDefinition)
	actual, err := differ{}.changesForOperations("Computer", "2020-01-01", "Example", initial, updated, ids, ids)
	if err != nil {
		t.Fatalf(err.Error())
	}
	expected := []changes.Change{
		changes.OperationResponseObjectChanged{
			ServiceName:       "Computer",
			ApiVersion:        "2020-01-01",
			ResourceName:      "Example",
			OperationName:     "First",
			OldResponseObject: "string",
			NewResponseObject: "SomeConstant",
		},
	}
	assertChanges(t, expected, *actual)
	assertContainsBreakingChanges(t, *actual)
}

func TestDiff_OperationResponseObjectRemoved(t *testing.T) {
	initial := map[string]resourcemanager.ApiOperation{
		"First": {
			ResponseObject: &resourcemanager.ApiObjectDefinition{
				Type: resourcemanager.StringApiObjectDefinitionType,
			},
		},
	}
	updated := map[string]resourcemanager.ApiOperation{
		"First": {
			ResponseObject: nil,
		},
	}
	ids := make(map[string]resourcemanager.ResourceIdDefinition)
	actual, err := differ{}.changesForOperations("Computer", "2020-01-01", "Example", initial, updated, ids, ids)
	if err != nil {
		t.Fatalf(err.Error())
	}
	expected := []changes.Change{
		changes.OperationResponseObjectRemoved{
			ServiceName:       "Computer",
			ApiVersion:        "2020-01-01",
			ResourceName:      "Example",
			OperationName:     "First",
			OldResponseObject: "string",
		},
	}
	assertChanges(t, expected, *actual)
	assertContainsBreakingChanges(t, *actual)
}

func TestDiff_OperationUriSuffixAdded(t *testing.T) {
	initial := map[string]resourcemanager.ApiOperation{
		"First": {
			UriSuffix: nil,
		},
	}
	updated := map[string]resourcemanager.ApiOperation{
		"First": {
			UriSuffix: pointer.To("/doSomething"),
		},
	}
	ids := make(map[string]resourcemanager.ResourceIdDefinition)
	actual, err := differ{}.changesForOperations("Computer", "2020-01-01", "Example", initial, updated, ids, ids)
	if err != nil {
		t.Fatalf(err.Error())
	}
	expected := []changes.Change{
		changes.OperationUriSuffixAdded{
			ServiceName:   "Computer",
			ApiVersion:    "2020-01-01",
			ResourceName:  "Example",
			OperationName: "First",
			NewValue:      "/doSomething",
		},
	}
	assertChanges(t, expected, *actual)
	assertContainsBreakingChanges(t, *actual)
}

func TestDiff_OperationUriSuffixChanged(t *testing.T) {
	initial := map[string]resourcemanager.ApiOperation{
		"First": {
			UriSuffix: pointer.To("/doSomething"),
		},
	}
	updated := map[string]resourcemanager.ApiOperation{
		"First": {
			UriSuffix: pointer.To("/doSomethingElse"),
		},
	}
	ids := make(map[string]resourcemanager.ResourceIdDefinition)
	actual, err := differ{}.changesForOperations("Computer", "2020-01-01", "Example", initial, updated, ids, ids)
	if err != nil {
		t.Fatalf(err.Error())
	}
	expected := []changes.Change{
		changes.OperationUriSuffixChanged{
			ServiceName:   "Computer",
			ApiVersion:    "2020-01-01",
			ResourceName:  "Example",
			OperationName: "First",
			OldValue:      "/doSomething",
			NewValue:      "/doSomethingElse",
		},
	}
	assertChanges(t, expected, *actual)
	assertContainsBreakingChanges(t, *actual)
}

func TestDiff_OperationUriSuffixRemoved(t *testing.T) {
	initial := map[string]resourcemanager.ApiOperation{
		"First": {
			UriSuffix: pointer.To("/doSomething"),
		},
	}
	updated := map[string]resourcemanager.ApiOperation{
		"First": {
			UriSuffix: nil,
		},
	}
	ids := make(map[string]resourcemanager.ResourceIdDefinition)
	actual, err := differ{}.changesForOperations("Computer", "2020-01-01", "Example", initial, updated, ids, ids)
	if err != nil {
		t.Fatalf(err.Error())
	}
	expected := []changes.Change{
		changes.OperationUriSuffixRemoved{
			ServiceName:   "Computer",
			ApiVersion:    "2020-01-01",
			ResourceName:  "Example",
			OperationName: "First",
			OldValue:      "/doSomething",
		},
	}
	assertChanges(t, expected, *actual)
	assertContainsBreakingChanges(t, *actual)
}
