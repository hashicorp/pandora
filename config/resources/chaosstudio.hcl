# Copyright IBM Corp. 2021, 2025
# SPDX-License-Identifier: MPL-2.0

service "ChaosStudio" {
  terraform_package = "chaosstudio"

  api "2023-11-01" {
    package "Targets" {
      definition "chaos_studio_target" {
        id                  = "/{scope}/providers/Microsoft.Chaos/targets/{targetName}"
        display_name        = "Chaos Studio Target"
        website_subcategory = "Chaos Studio"
        description         = "Manages a Chaos Studio Target"
        generate_create     = false
        generate_update     = false
        overrides "name" {
          updated_name = "target_type"
          description = "The name of the Chaos Studio Target. This has the format of [publisher]-[targetType] e.g. `Microsoft-StorageAccount`. For supported values please see this Target Type column in [this table](https://learn.microsoft.com/azure/chaos-studio/chaos-studio-fault-providers)."
        }
        overrides "scope" {
          updated_name = "target_resource_id"
        }
        test_data {
          basic_variables {
            strings = {
              "target_type" = "Microsoft-AzureKubernetesServiceChaosMesh"
            }
          }
        }
      }
    }
  }
}