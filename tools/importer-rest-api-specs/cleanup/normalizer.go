package cleanup

import (
	"strings"
)

func NormalizeConstantKey(input string) string {
	output := input
	output = StringifyNumberInput(output)

	output = strings.ReplaceAll(output, "*", "Any")
	// TODO: add more if we find them

	output = NormalizeName(output)
	return output
}

func NormalizeName(input string) string {
	output := input

	// we should probably iterate over the string and if we find one of these tokens
	// then capitalize the next letter, but this is sufficient for now

	// TODO: basic but fine for now, ultimately we should check this is a valid type name
	// but tbh, the compiler will catch these when we generate them so that's a later problem
	output = strings.TrimPrefix(output, "$")

	// foreach of these characters, work through and Capitalize the segments as necessary
	// e.g. `Azure-kusto` becomes `AzureKusto`
	charactersToReplace := []string{
		" ",
		"_",
		"-", // note: different to below
		"–", // note: different to above
		"_",
		"[",
		"]",
		"(",
		")",
		"@",
		"+",
		",",
		"/",
		":",
		"$",
		"'",
		".",
	}
	for _, find := range charactersToReplace {
		split := strings.Split(output, find)
		newVal := ""
		for _, word := range split {
			word = strings.ReplaceAll(word, find, "")
			word = strings.Title(word)
			newVal += word
		}
		output = newVal
	}

	output = NormalizeSegment(output, false)
	output = strings.Title(output)
	return output
}

func NormalizeSegmentName(input string) string {
	output := input
	output = NormalizeSegment(output, true)
	output = NormalizeName(output)

	if strings.HasSuffix(output, "Name") {
		output = strings.TrimSuffix(output, "Name")
	}

	// todo: something better than this
	if strings.HasSuffix(output, "s") {
		if !strings.HasSuffix(output, "ies") {
			output = strings.TrimSuffix(output, "s")
		}
		if strings.HasSuffix(output, "sse") {
			output = strings.TrimSuffix(output, "e")
		}
	}

	output = strings.Title(output)
	return output
}

// NormalizeSegment normalizes the segments in the URI, since this data isn't normalized at review time :shrug:
func NormalizeSegment(input string, camelCase bool) string {
	fixed := map[string]string{
		// these are intentionally camel-cased
		"apiversion":             "apiVersion",
		"appsettings":            "appSettings",
		"artifacttypes":          "artifactTypes",
		"authproviders":          "authProviders",
		"connectionstrings":      "connectionStrings",
		"configreferences":       "configReferences",
		"continuouswebjobs":      "continuousWebJobs",
		"functionappsettings":    "functionAppSettings",
		"hybridconnection":       "hybridConnection",
		"mediaservice":           "mediaService",
		"migratemysql":           "migrateMySql",
		"operationresults":       "operationResults",
		"premieraddons":          "premierAddons",
		"resourcegroups":         "resourceGroups",
		"serverfarms":            "serverFarms",
		"siteextensions":         "siteExtensions",
		"sourcecontrols":         "sourceControls",
		"subscriptions":          "subscriptions", // e.g. /Subscriptions -> /subscriptions
		"trafficmanagerprofiles": "trafficManagerProfiles",
		"triggeredwebjobs":       "triggeredWebJobs",
		"virtualmachines":        "virtualMachines",
		"webjobs":                "webJobs",
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

func NormalizeServiceName(input string) string {
	fixed := map[string]string{
		// NOTE: these are intentionally lower-cased
		"analysisservices": "AnalysisServices",
		"appconfiguration": "AppConfiguration",
		"eventhub":         "EventHub",
		"powerbidedicated": "PowerBIDedicated",
		"signalr":          "SignalR",
		"vmware":           "VMware",
	}

	if v, ok := fixed[strings.ToLower(input)]; ok {
		return strings.Title(v)
	}

	return input
}

func StringifyNumberInput(input string) string {
	vals := map[int32]string{
		'.': "Point",
		'-': "Negative",
		'0': "Zero",
		'1': "One",
		'2': "Two",
		'3': "Three",
		'4': "Four",
		'5': "Five",
		'6': "Six",
		'7': "Seven",
		'8': "Eight",
		'9': "Nine",
	}
	output := ""
	for _, c := range input {
		v, ok := vals[c]
		if !ok {
			output += string(c)
			continue
		}
		output += v
	}
	return output
}
