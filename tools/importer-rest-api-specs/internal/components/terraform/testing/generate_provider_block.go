// Copyright IBM Corp. 2021, 2025
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
