package pipeline

type ApiVersion = string

const (
	ApiVersion1_0  ApiVersion = "v1.0"
	ApiVersionBeta ApiVersion = "beta"
)

var SupportedVersions = []string{ApiVersion1_0, ApiVersionBeta}
