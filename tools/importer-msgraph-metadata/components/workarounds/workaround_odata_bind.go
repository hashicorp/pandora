// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package workarounds

import (
	"fmt"
	"strings"

	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	"github.com/hashicorp/pandora/tools/importer-msgraph-metadata/components/normalize"
	"github.com/hashicorp/pandora/tools/importer-msgraph-metadata/components/parser"
	"github.com/hashicorp/pandora/tools/importer-msgraph-metadata/internal/logging"
)

var _ dataWorkaround = workaroundODataBind{}

// workaroundODataBind inserts an `@odata.bind` field where a field or collection refers to a DirectoryObject. The
// OpenAPI spec unfortunately does not document relationships between entities.
// For example usage, see https://learn.microsoft.com/en-us/graph/api/group-post-groups?view=graph-rest-1.0&tabs=http#example-2-create-a-group-with-owners-and-members
type workaroundODataBind struct{}

func (workaroundODataBind) Name() string {
	return "OData / add @odata.bind fields"
}

func (workaroundODataBind) Process(apiVersion string, models parser.Models, constants parser.Constants, resourceIds parser.ResourceIds) error {
	for schemaName, model := range models {
		for jsonField, field := range model.Fields {
			if field.ReferenceName != nil && strings.EqualFold(*field.ReferenceName, "microsoft.graph.directoryObject") {
				bindFieldName := fmt.Sprintf("%s_ODataBind", normalize.CleanName(jsonField))
				bindFieldJsonName := fmt.Sprintf("%s@odata.bind", jsonField)

				logging.Tracef("Adding `%s_ODataBind` (`%s@odata.bind`) field to %q model", bindFieldName, bindFieldJsonName, schemaName)

				description := ""
				if field.Type != nil && *field.Type == parser.DataTypeArray {
					description = fmt.Sprintf("List of OData IDs for `%s` to bind to this entity", normalize.CleanName(jsonField))
				} else {
					description = fmt.Sprintf("OData ID for `%s` to bind to this entity", normalize.CleanName(jsonField))
				}

				var fieldType, itemType *parser.DataType

				fieldType = pointer.To(parser.DataTypeString)
				if *field.Type == parser.DataTypeArray {
					fieldType = pointer.To(parser.DataTypeArray)
					itemType = pointer.To(parser.DataTypeString)
				}

				model.Fields[bindFieldJsonName] = &parser.ModelField{
					Name:        bindFieldName,
					Description: description,
					Type:        fieldType,
					ItemType:    itemType,
				}
			}
		}
	}

	return nil
}
