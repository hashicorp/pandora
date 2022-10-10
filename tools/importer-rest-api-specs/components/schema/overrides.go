package schema

var fieldsWhichShouldBeIgnoredExactMatch = []string{
	"Kind",
	"ProvisioningState",
	"ResourceState",
	"Type",
	"InstanceView",
}

var fieldsWhichShouldBeIgnoredIfContains = []string{
	"ConnectionState",
	"Kind",
	"ProvisioningState",
	"ResourceState",
	"Type",
}

var schemaFieldNameOverrides = map[string]string{
	"etag": "etag",
	"ip":   "ip_address",
}
