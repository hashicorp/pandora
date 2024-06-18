// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package transforms

import (
	"fmt"
	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	"sort"
)

func determineExampleValue(input map[string]string) (*string, error) {
	if len(input) == 0 {
		return nil, fmt.Errorf("the constant had no values to pick an example from, this is an invalid state when parsing the constant")
	}

	values := make([]string, 0)
	for _, v := range input {
		values = append(values, v)
	}
	sort.Strings(values)
	return pointer.To(values[0]), nil
}
