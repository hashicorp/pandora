// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

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
