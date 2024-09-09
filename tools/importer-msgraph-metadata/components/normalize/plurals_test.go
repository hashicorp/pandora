package normalize

import "testing"

func TestSingularize(t *testing.T) {
	testCases := map[string]string{
		// Plurals to be singularized
		"Apps":         "App",
		"Applications": "Application",
		"Caches":       "Cache",
		"Entities":     "Entity",
		"Modalities":   "Modality",
		"Options":      "Option",
		"Premises":     "Premise",
		"Principals":   "Principal",
		"Services":     "Service",
		"Severities":   "Severity",
		"Successes":    "Success",

		// Composite plurals to be singularized
		"FolderProperties": "FolderProperty",
		"SecurityPolicies": "SecurityPolicy",
		"ServerDetails":    "ServerDetail",
		"UserKinds":        "UserKind",

		// Singulars to remain the same
		"Access":        "Access",
		"Application":   "Application",
		"Compatibility": "Compatibility",
		"By":            "By",
		"Data":          "Data",
		"Group":         "Group",
		"Metadata":      "Metadata",
		"Orderby":       "Orderby",
		"Ref":           "Ref",
		"Reference":     "Reference",
		"Sms":           "Sms",
		"Sortby":        "Sortby",

		// Composite singulars to remain the same
		"OrderBy":       "OrderBy",
		"ReminderSms":   "ReminderSms",
		"SecurityGroup": "SecurityGroup",
		"UserData":      "UserData",

		// Already a singular, mistakenly treated as plural
		"Success": "Success",
	}

	for input, expected := range testCases {
		result := Singularize(input)
		if result != expected {
			t.Errorf("Singularize(%q): got %q, expected %q", input, result, expected)
		}
	}
}

func TestPluralize(t *testing.T) {
	testCases := map[string]string{
		// Singulars to be pluralized
		"Access":        "Accesses",
		"App":           "Apps",
		"Application":   "Applications",
		"Compatibility": "Compatibility",
		"Cache":         "Caches",
		"Detail":        "Details",
		"Entity":        "Entities",
		"Kind":          "Kinds",
		"Modality":      "Modalities",
		"Option":        "Options",
		"Policy":        "Policies",
		"Premise":       "Premises",
		"Principal":     "Principals",
		"Property":      "Properties",
		"Service":       "Services",
		"Severity":      "Severities",
		"Success":       "Successes",

		// Composite plurals to stay the same
		"FolderProperty": "FolderProperties",
		"SystemService":  "SystemServices",
		"UserDetail":     "UserDetails",

		// Plurals to remain the same
		"Applications": "Applications",
		"By":           "By",
		"Data":         "Data",
		"Groups":       "Groups",
		"Metadata":     "Metadata",
		"Orderby":      "Orderby",
		"Properties":   "Properties",
		"Refs":         "Refs",
		"References":   "References",
		"Sortby":       "Sortby",
		"Successes":    "Successes",

		// Composite plurals to remain the same
		"FolderProperties": "FolderProperties",
		"OrderBy":          "OrderBy",
		"UserData":         "UserData",
	}

	for input, expected := range testCases {
		result := Pluralize(input)
		if result != expected {
			t.Errorf("Pluralize(%q): got %q, expected %q", input, result, expected)
		}
	}
}
