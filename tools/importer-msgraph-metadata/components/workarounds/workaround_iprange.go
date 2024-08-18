// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package workarounds

import (
	"fmt"

	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	"github.com/hashicorp/pandora/tools/importer-msgraph-metadata/components/parser"
)

var _ workaround = workaroundIPRange{}

// workaroundIPRange implements discrimination for iPv4CidrRange, iPv4Range, iPv6CidrRange, and iPv6Range
type workaroundIPRange struct{}

func (workaroundIPRange) Name() string {
	return "IPRange / discrimination"
}

func (workaroundIPRange) Process(apiVersion string, models parser.Models, constants parser.Constants) error {
	// microsoft.graph.ipRange model is empty and is omitted by the OpenAPI parser
	models["IPRange"] = &parser.Model{
		Fields: map[string]*parser.ModelField{
			"ODataId": {
				Title:     "ODataId",
				Type:      pointer.To(parser.DataTypeString),
				Default:   "",
				JsonField: "@odata.id",
			},
			"ODataType": {
				Title:              "ODataType",
				Type:               pointer.To(parser.DataTypeString),
				ConstantName:       pointer.To("IPRangeType"),
				Default:            "",
				DiscriminatedValue: true,
				JsonField:          "@odata.type",
			},
		},
		Common:    true,
		TypeField: pointer.To("ODataType"),
	}

	if _, ok := constants["IPRangeType"]; ok {
		return fmt.Errorf("`IPRangeType` constant already defined")
	}

	// Add constant values for the discriminated type value
	constants["IPRangeType"] = &parser.Constant{
		Enum: []string{
			"#microsoft.graph.iPv4CidrRange",
			"#microsoft.graph.iPv4Range",
			"#microsoft.graph.iPv6CidrRange",
			"#microsoft.graph.iPv6Range",
		},
		Type: pointer.To(parser.DataTypeString),
	}

	// Set the parent model and discriminated type value for IPv4CIDRRange
	model, ok := models["IPv4CIDRRange"]
	if !ok {
		return fmt.Errorf("`IPv4CIDRRange` model not found")
	}
	model.ParentModelName = pointer.To("IPRange")
	model.TypeField = pointer.To("ODataType")
	model.TypeValue = pointer.To("#microsoft.graph.iPv4CidrRange")

	// Set the parent model and discriminated type value for IPv4Range
	model, ok = models["IPv4Range"]
	if !ok {
		return fmt.Errorf("`IPv4Range` model not found")
	}
	model.ParentModelName = pointer.To("IPRange")
	model.TypeField = pointer.To("ODataType")
	model.TypeValue = pointer.To("#microsoft.graph.iPv4Range")

	// Set the parent model and discriminated type value for IPv6CIDRRange
	model, ok = models["IPv6CIDRRange"]
	if !ok {
		return fmt.Errorf("`IPv6CIDRRange` model not found")
	}
	model.ParentModelName = pointer.To("IPRange")
	model.TypeField = pointer.To("ODataType")
	model.TypeValue = pointer.To("#microsoft.graph.iPv6CidrRange")

	// Set the parent model and discriminated type value for IPv6Range
	model, ok = models["IPv6Range"]
	if !ok {
		return fmt.Errorf("`IPv6Range` model not found")
	}
	model.ParentModelName = pointer.To("IPRange")
	model.TypeField = pointer.To("ODataType")
	model.TypeValue = pointer.To("#microsoft.graph.iPv6Range")

	return nil
}
