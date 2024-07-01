package versions

type ApiVersion = string

const (
	ApiVersionStable ApiVersion = "stable"
	ApiVersionBeta   ApiVersion = "beta"
)

var Supported = []string{ApiVersionStable, ApiVersionBeta}

var upstreamVersions = map[ApiVersion]string{
	ApiVersionStable: "v1.0",
	ApiVersionBeta:   "beta",
}

func IsPreview(version ApiVersion) bool {
	return version != ApiVersionStable
}
func Upstream(version ApiVersion) string {
	return upstreamVersions[version]
}
