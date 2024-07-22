// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package combine

import (
	"fmt"
)

func maps(first map[string]string, second map[string]string) (map[string]string, error) {
	vals := make(map[string]string, 0)
	for k, v := range first {
		vals[k] = v
	}
	for k, v := range second {
		existing, ok := vals[k]
		if !ok {
			vals[k] = v
			continue
		}

		if existing != v {
			return nil, fmt.Errorf("duplicate key %q with different value - first %q - second %q", k, existing, v)
		}
	}

	return vals, nil
}
