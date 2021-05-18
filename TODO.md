Importer Bugs
  - Nested models with generic names conflict (Data Protection)
  - OAPIGen bug

API
  - Nilable Dates e.g. `DateTime?`
  - Nilable Enums e.g. `ProvisioningState?`
  - Maps of String:Object e.g. `Dictionary<string, UserIdentity>?`
  - Operations can be long running with response objects (but they should likely be ignored)

- Binary Data (e.g. []byte)
  - Importer
  - API
  - Generator / SDK
- UUID's
  - Importer
  - API
  - Generator / SDK
- Discriminators (e.g. Data Protection / Data Factory)
- Header values for OptionsObjects
  - Also parsing values out of the headers if needs be (e.g. Storage)
- Common Resource ID Types
  - Resource Group ID
  - Subscription ID
  - Management Group ID
- Generating the Service/Version Definition file
- Finding Services and Versions via Reflection rather than hard-coding
