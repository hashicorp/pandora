// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package workarounds

import (
	"fmt"

	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	"github.com/hashicorp/pandora/tools/importer-msgraph-metadata/components/parser"
)

var _ workaround = workaroundNamedLocation{}

// workaroundNamedLocation implements discrimination
type workaroundNamedLocation struct{}

func (workaroundNamedLocation) Name() string {
	return "NamedLocation / discrimination"
}

func (workaroundNamedLocation) Process(apiVersion string, models parser.Models, constants parser.Constants) error {
	model, ok := models["NamedLocation"]
	if !ok {
		return fmt.Errorf("`NamedLocation` model not found")
	}

	if _, ok = model.Fields["ODataType"]; !ok {
		return fmt.Errorf("`ODataType` field not found in `NamedLocation` model")
	}

	// Set the constant reference and discriminated flag for the @odata.type field
	model.Fields["ODataType"].ConstantName = pointer.To("NamedLocationType")
	model.Fields["ODataType"].DiscriminatedValue = true
	model.TypeField = pointer.To("ODataType")

	if _, ok = constants["NamedLocationType"]; ok {
		return fmt.Errorf("`NamedLocationType` constant already defined")
	}

	// Add constant values for the discriminated type value
	constants["NamedLocationType"] = &parser.Constant{
		Enum: []string{
			"#microsoft.graph.countryNamedLocation",
			"#microsoft.graph.ipNamedLocation",
		},
		Type: pointer.To(parser.DataTypeString),
	}

	// Set the parent model and discriminated type value for CountryNamedLocation
	model, ok = models["CountryNamedLocation"]
	if !ok {
		return fmt.Errorf("`CountryNamedLocation` model not found")
	}
	model.ParentModelName = pointer.To("NamedLocation")
	model.TypeField = pointer.To("ODataType")
	model.TypeValue = pointer.To("#microsoft.graph.countryNamedLocation")

	// Set the parent model and discriminated type value for CountryNamedLocation
	model, ok = models["IPNamedLocation"]
	if !ok {
		return fmt.Errorf("`IPNamedLocation` model not found")
	}
	model.ParentModelName = pointer.To("NamedLocation")
	model.TypeField = pointer.To("ODataType")
	model.TypeValue = pointer.To("#microsoft.graph.ipNamedLocation")

	return nil
}
