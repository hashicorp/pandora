package pipeline

import "github.com/getkin/kin-openapi/openapi3"

type pipelineTask struct {
	spec          *openapi3.T
	swaggerGitSha string
}
