package normalize

import "testing"

func TestSingularize(t *testing.T) {
	testCases := map[string]string{
		// Plurals to be singularized
		"Access":        "Access",
		"Apps":          "App",
		"Applications":  "Application",
		"By":            "By",
		"Caches":        "Cache",
		"Data":          "Data",
		"Details":       "Detail",
		"Compatibility": "Compatibility",
		"Entities":      "Entity",
		"Kinds":         "Kind",
		"Metadata":      "Metadata",
		"Modalities":    "Modality",
		"Options":       "Option",
		"Orderby":       "Orderby",
		"Policies":      "Policy",
		"Premises":      "Premise",
		"Principals":    "Principal",
		"Properties":    "Property",
		"Services":      "Service",
		"Severities":    "Severity",
		"Sortby":        "Sortby",
		"Success":       "Success",
		"Successes":     "Success",

		// Singulars to remain the same
		"Application": "Application",
		"Group":       "Group",
		"Property":    "Property",
		"Ref":         "Ref",
		"Reference":   "Reference",
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
		"By":            "By",
		"Compatibility": "Compatibility",
		"Cache":         "Caches",
		"Data":          "Data",
		"Detail":        "Details",
		"Entity":        "Entities",
		"Kind":          "Kinds",
		"Metadata":      "Metadata",
		"Modality":      "Modalities",
		"Option":        "Options",
		"Orderby":       "Orderby",
		"Policy":        "Policies",
		"Premise":       "Premises",
		"Principal":     "Principals",
		"Property":      "Properties",
		"Service":       "Services",
		"Severity":      "Severities",
		"Sortby":        "Sortby",
		"Success":       "Successes",
		"Successes":     "Successes",

		// Plurals to remain the same
		"Applications": "Applications",
		"Groups":       "Groups",
		"Properties":   "Properties",
		"Refs":         "Refs",
		"References":   "References",
	}

	for input, expected := range testCases {
		result := Pluralize(input)
		if result != expected {
			t.Errorf("Pluralize(%q): got %q, expected %q", input, result, expected)
		}
	}
}
