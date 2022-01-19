package generator

import (
	"fmt"
	"path"
)

func OutputRevisionId(workingDirectory, namespace, swaggerGitSha string) error {
	revisionIdCode := codeForRevisionIdFile(namespace, swaggerGitSha)
	revisionIdFileName := path.Join(workingDirectory, namespace, "SwaggerRevision.cs")
	if err := writeToFile(revisionIdFileName, revisionIdCode); err != nil {
		return fmt.Errorf("writing Swagger Revision ID for %q: %+v", revisionIdFileName, err)
	}

	return nil
}

func codeForRevisionIdFile(namespace, swaggerGitSha string) string {
	return fmt.Sprintf(`namespace %[1]s;

// Generated from Swagger revision %[2]q
`, namespace, swaggerGitSha)
}
