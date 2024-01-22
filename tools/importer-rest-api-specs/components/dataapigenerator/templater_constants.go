// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package dataapigenerator

import (
	"fmt"
	"sort"
	"strings"

	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

func codeForConstant(namespace, constantName string, details resourcemanager.ConstantDetails) (*string, error) {
	code := make([]string, 0)

	sortedKeys := make([]string, 0)
	for key := range details.Values {
		sortedKeys = append(sortedKeys, key)
	}
	sort.Strings(sortedKeys)

	for _, key := range sortedKeys {
		value := details.Values[key]
		code = append(code, fmt.Sprintf("\t\t[Description(%q)]\n\t\t%s,", value, key))
	}

	attributes := make([]string, 0)
	constantFieldType, err := mapConstantFieldType(details.Type)
	if err != nil {
		return nil, fmt.Errorf("mapping constant field type %q: %+v", string(details.Type), err)
	}
	attributes = append(attributes, fmt.Sprintf("\t[ConstantType(%s)]", *constantFieldType))

	out := fmt.Sprintf(`using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace %[1]s;

%[4]s
internal enum %[2]sConstant
{
%[3]s
}
`, namespace, constantName, strings.Join(code, "\n\n"), strings.Join(attributes, "\n"))
	return &out, nil
}

func mapConstantFieldType(input resourcemanager.ConstantType) (*string, error) {
	result := func(in string) (*string, error) {
		return &in, nil
	}
	if input == resourcemanager.FloatConstant {
		return result("ConstantTypeAttribute.ConstantType.Float")
	}

	if input == resourcemanager.IntegerConstant {
		return result("ConstantTypeAttribute.ConstantType.Integer")
	}

	if input == resourcemanager.StringConstant {
		return result("ConstantTypeAttribute.ConstantType.String")
	}

	return nil, fmt.Errorf("unmapped Constant Type %q", string(input))
}
