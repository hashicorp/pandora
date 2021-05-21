package cleanup

import "strings"

func NormalizeName(input string) string {
	output := input

	// we should probably iterate over the string and if we find one of these tokens
	// then capitalize the next letter, but this is sufficient for now

	// TODO: basic but fine for now, ultimately we should check this is a valid type name
	// but tbh, the compiler will catch these when we generate them so that's a later problem
	output = strings.TrimPrefix(output, "$")
	output = strings.ReplaceAll(output, "_", "")
	output = strings.ReplaceAll(output, "-", "")
	output = strings.ReplaceAll(output, ".", "")
	output = strings.ReplaceAll(output, "/", "")
	output = strings.ReplaceAll(output, ",", "")
	output = strings.ReplaceAll(output, " ", "")
	output = NormalizeSegment(output, false)
	output = strings.Title(output)
	return output
}

// normalizeSegment normalizes the segments in the URI, since this data isn't normalized at review time :shrug:
func NormalizeSegment(input string, camelCase bool) string {
	fixed := map[string]string{
		// these are intentionally camel-cased
		"apiversion":          "apiVersion",
		"appsettings":         "appSettings",
		"artifacttypes":       "artifactTypes",
		"authproviders":       "authProviders",
		"connectionstrings":   "connectionStrings",
		"configreferences":    "configReferences",
		"continuouswebjobs":   "continuousWebJobs",
		"functionappsettings": "functionAppSettings",
		"hybridconnection":    "hybridConnection",
		"mediaservice":        "mediaService",
		"migratemysql":        "migrateMySql",
		"operationresults":    "operationResults",
		"premieraddons":       "premierAddons",
		"resourcegroups":      "resourceGroups",
		"serverfarms":         "serverFarms",
		"siteextensions":      "siteExtensions",
		"sourcecontrols":      "sourceControls",
		"triggeredwebjobs":    "triggeredWebJobs",
		"virtualmachines":     "virtualMachines",
		"webjobs":             "webJobs",
	}

	if v, ok := fixed[strings.ToLower(input)]; ok {
		if camelCase {
			return v
		} else {
			return strings.Title(v)
		}
	}

	return input
}
