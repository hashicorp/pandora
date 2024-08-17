// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package workarounds

import (
	"fmt"

	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	"github.com/hashicorp/pandora/tools/importer-msgraph-metadata/components/parser"
)

var _ workaround = workaroundDirectoryObject{}

// workaroundDirectoryObject implements discrimination
type workaroundDirectoryObject struct{}

func (workaroundDirectoryObject) Name() string {
	return "Directory Object / discrimination"
}

func (workaroundDirectoryObject) Process(apiVersion string, models parser.Models, constants parser.Constants) error {
	model, ok := models["DirectoryObject"]
	if !ok {
		return fmt.Errorf("`DirectoryObject` model not found")
	}

	if _, ok = model.Fields["ODataType"]; !ok {
		return fmt.Errorf("`ODataType` field not found in `DireectoryObject` model")
	}

	model.Fields["ODataType"].ConstantName = pointer.To("DirectoryObjectType")
	model.Fields["ODataType"].DiscriminatedValue = true
	model.TypeField = pointer.To("ODataType")

	// Add constant values for the discriminated type value
	constants["DirectoryObjectType"] = &parser.Constant{
		Enum: []string{
			"#microsoft.graph.administrativeUnit",
			"#microsoft.graph.application",
			"#microsoft.graph.device",
			"#microsoft.graph.group",
			"#microsoft.graph.orgContact",
			"#microsoft.graph.servicePrincipal",
			"#microsoft.graph.user",
		},
		Type: pointer.To(parser.DataTypeString),
	}

	// Set the parent model and discriminated type value for AdministrativeUnit
	model, ok = models["AdministrativeUnit"]
	if !ok {
		return fmt.Errorf("`AdministrativeUnit` model not found")
	}
	model.ParentModelName = pointer.To("DirectoryObject")
	model.TypeField = pointer.To("ODataType")
	model.TypeValue = pointer.To("#microsoft.graph.administrativeUnit")

	// Set the parent model and discriminated type value for Application
	model, ok = models["Application"]
	if !ok {
		return fmt.Errorf("`Application` model not found")
	}
	model.ParentModelName = pointer.To("DirectoryObject")
	model.TypeField = pointer.To("ODataType")
	model.TypeValue = pointer.To("#microsoft.graph.application")

	// Set the parent model and discriminated type value for Device
	model, ok = models["Device"]
	if !ok {
		return fmt.Errorf("`Device` model not found")
	}
	model.ParentModelName = pointer.To("DirectoryObject")
	model.TypeField = pointer.To("ODataType")
	model.TypeValue = pointer.To("#microsoft.graph.device")

	// Set the parent model and discriminated type value for Group
	model, ok = models["Group"]
	if !ok {
		return fmt.Errorf("`Group` model not found")
	}
	model.ParentModelName = pointer.To("DirectoryObject")
	model.TypeField = pointer.To("ODataType")
	model.TypeValue = pointer.To("#microsoft.graph.group")

	// Set the parent model and discriminated type value for OrgContact
	model, ok = models["OrgContact"]
	if !ok {
		return fmt.Errorf("`OrgContact` model not found")
	}
	model.ParentModelName = pointer.To("DirectoryObject")
	model.TypeField = pointer.To("ODataType")
	model.TypeValue = pointer.To("#microsoft.graph.orgContact")

	// Set the parent model and discriminated type value for ServicePrincipal
	model, ok = models["ServicePrincipal"]
	if !ok {
		return fmt.Errorf("`ServicePrincipal` model not found")
	}
	model.ParentModelName = pointer.To("DirectoryObject")
	model.TypeField = pointer.To("ODataType")
	model.TypeValue = pointer.To("#microsoft.graph.servicePrincipal")

	// Set the parent model and discriminated type value for User
	model, ok = models["User"]
	if !ok {
		return fmt.Errorf("`User` model not found")
	}
	model.ParentModelName = pointer.To("DirectoryObject")
	model.TypeField = pointer.To("ODataType")
	model.TypeValue = pointer.To("#microsoft.graph.user")

	return nil
}
