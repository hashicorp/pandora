package featureflags

// AllowConstantsWithoutXMSEnum specifies whether Constants should be parsed out without
// an x-ms-enum extension. This is intended to be a temporary stop-gap whilst the data
// issues are resolved - since the Swagger should define canonical names for these Enums.
const AllowConstantsWithoutXMSEnum = true
