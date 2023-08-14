package models

type ServicesDefinition struct {
	Services map[string]ServiceSummary `json:"services"`
}

type ServiceSummary struct {
	// Generate specifies whether this API should be generated or not
	Generate bool `json:"generate"`

	// Uri is the Uri used to access more information about this Service
	Uri string `json:"uri"`
}
