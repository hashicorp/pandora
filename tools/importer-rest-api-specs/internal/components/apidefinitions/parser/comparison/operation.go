// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package comparison

import (
	"fmt"
	"reflect"
	"strings"

	"github.com/davecgh/go-spew/spew"
	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/logging"
)

func OperationsMatch(first, second sdkModels.SDKOperation) (bool, error) {
	if first.ContentType != second.ContentType {
		logging.Tracef("Differing ContentType %q and %q", first.ContentType, second.ContentType)
		return false, fmt.Errorf("Differing ContentType %q and %q", first.ContentType, second.ContentType)
	}
	if !reflect.DeepEqual(first.ExpectedStatusCodes, second.ExpectedStatusCodes) {
		logging.Tracef("Differing ExpectedStatusCodes %+v and %+v", first.ExpectedStatusCodes, second.ExpectedStatusCodes)
		return false, fmt.Errorf("Differing ExpectedStatusCodes %+v and %+v", first.ExpectedStatusCodes, second.ExpectedStatusCodes)
	}
	if !strings.EqualFold(pointer.From(first.FieldContainingPaginationDetails), pointer.From(second.FieldContainingPaginationDetails)) {
		logging.Tracef("Differing FieldContainingPaginationDetails %q and %q", pointer.From(first.FieldContainingPaginationDetails), pointer.From(second.FieldContainingPaginationDetails))
		return false, fmt.Errorf("Differing FieldContainingPaginationDetails %q and %q", pointer.From(first.FieldContainingPaginationDetails), pointer.From(second.FieldContainingPaginationDetails))
	}
	if first.LongRunning != second.LongRunning {
		logging.Tracef("Differing LongRunning %t and %t", first.LongRunning, second.LongRunning)
		return false, fmt.Errorf("Differing LongRunning %t and %t", first.LongRunning, second.LongRunning)
	}
	if first.Method != second.Method {
		logging.Tracef("Differing Method %q and %q", first.Method, second.Method)
		return false, fmt.Errorf("Differing Method %q and %q", first.Method, second.Method)
	}
	if !OperationOptionsMatch(first.Options, second.Options) {
		logging.Tracef("Differing Options %+v and %+v", first.Options, second.Options)
		return false, fmt.Errorf("Differing Options %+v and %+v", spew.Sdump(first.Options), spew.Sdump(second.Options))
	}
	if ok, err := ObjectDefinitionsMatch(first.RequestObject, second.RequestObject); !ok {
		logging.Tracef("Differing RequestObject %+v and %+v", first.RequestObject, second.RequestObject)
		return false, fmt.Errorf("Differing RequestObject: %+v", err)
	}
	if pointer.From(first.ResourceIDName) != pointer.From(second.ResourceIDName) {
		logging.Tracef("Differing ResourceIDName %q and %q", pointer.From(first.ResourceIDName), pointer.From(second.ResourceIDName))
		return false, fmt.Errorf("Differing ResourceIDName %q and %q", pointer.From(first.ResourceIDName), pointer.From(second.ResourceIDName))
	}
	if ok, err := ObjectDefinitionsMatch(first.ResponseObject, second.ResponseObject); !ok {
		logging.Tracef("Differing ResponseObjects %+v and %+v", first.ResponseObject, second.ResponseObject)
		return false, fmt.Errorf("Differing ResponseObjects: %+v", err)
	}
	if pointer.From(first.URISuffix) != pointer.From(second.URISuffix) {
		logging.Tracef("Differing URISuffix %q and %q", pointer.From(first.URISuffix), pointer.From(second.URISuffix))
		return false, fmt.Errorf("Differing URISuffix %q and %q", pointer.From(first.URISuffix), pointer.From(second.URISuffix))
	}

	return true, nil
}
