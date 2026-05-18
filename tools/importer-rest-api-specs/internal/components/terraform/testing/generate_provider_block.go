// Copyright IBM Corp. 2023, 2026
// SPDX-License-Identifier: MPL-2.0

package testing

import "fmt"

func (tb testBuilder) generateProviderBlock(_ *testDependencies) (*string, error) {
	out := fmt.Sprintf(`
provider "%s" {
  features {}
}
`, tb.providerPrefix)
	return &out, nil
}
