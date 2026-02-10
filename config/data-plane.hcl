# Copyright IBM Corp. 2021, 2025
# SPDX-License-Identifier: MPL-2.0

service "appconfiguration" {
  name      = "AppConfiguration"
  available = ["1.0"]
}

service "attestation" {
  name      = "Attestation"
  available = ["2020-10-01", "2022-08-01"]
}

service "batch" {
  name = "Batch"
  available = ["2022-01-01.15.0", "2020-03-01.11.0"]
}

service "iotcentral"  {
  name = "IoTCentral"
  available = ["2022-10-31-preview"]
}

service "keyvault" {
  name = "KeyVault"
  available = ["7.4", "7.5-preview.1", "2025-07-01"]
}

service "search" {
  name      = "Search"
  available = ["2025-09-01"]
}

service "synapse" {
  name = "Synapse"
  available = ["2019-06-01-preview", "2020-08-01-preview", "2021-06-01-preview"]
}
