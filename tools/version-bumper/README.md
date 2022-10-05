## Tool: Version Bumper

**NOTE: at this time this tool is only formatting the existing config, it's not auto-adding new versions until we import all services.** 

This tool will update the Configs for Resource Manager (and other API's in the Future) such that we automatically import new (Stable) versions of Services when they become available.

This does this by:

* Parsing the config (`./config/resource-manager.hcl`)
* Retrieving a list of Services and Service Versions from the `./swagger/specification` Git Submodule.
* If it's a new Service (that is, we're not defining it already) - we pick the latest version available (preferring a Stable version, but accepting a Preview version if necessary).
* If we already define that Service, we only add the version if it's a new Stable version. New Preview Versions can be added by updating the Config directly.

This tool is run automagically by GitHub Actions whenever the Swagger is updated.

### How do I add a new version?

If it's a Stable version, this tool should do that automagically once it's in the Swagger.

If it's a Preview version:

* For a new Service: this tool should do that automagically once it's in the Swagger.
* For an existing Service: you'll need to PR that into the Config.

### How do I remove a version?

This isn't handled automatically - PR that to the Config.

