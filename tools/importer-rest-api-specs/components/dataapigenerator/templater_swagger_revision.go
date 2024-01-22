// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package dataapigenerator

import "fmt"

func codeForRevisionIdFile(namespace, swaggerGitSha string) string {
	return fmt.Sprintf(`namespace %[1]s;

%[3]s

// Generated from Swagger revision %[2]q
`, namespace, swaggerGitSha, restApiSpecsLicence)
}
