package dataapigenerator

import (
	"fmt"
	"path"
)

func outputRevisionId(workingDirectory, namespace, swaggerGitSha string) error {
	revisionIdCode := codeForRevisionIdFile(namespace, swaggerGitSha)
	revisionIdFileName := path.Join(workingDirectory, namespace, "SwaggerRevision.cs")
	if err := writeToFile(revisionIdFileName, revisionIdCode); err != nil {
		return fmt.Errorf("writing Swagger Revision ID for %q: %+v", revisionIdFileName, err)
	}

	return nil
}
