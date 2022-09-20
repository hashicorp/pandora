using System.Collections.Generic;
using Pandora.Definitions.Helpers;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.Compute.Terraform;

public class VirtualMachineScaleSetResourceTests : TerraformResourceTestDefinition
{
    // TODO: output real tests
    public string BasicTestConfig => @"
         
resource 'azurerm_virtual_machine_scale_set' 'test' {
  location            = azurerm_resource_group.test.location
  name                = 'acctest-${local.random_integer}'
  resource_group_name = azurerm_resource_group.test.name
}


    ".AsTerraformTestConfig();

    public string RequiresImportConfig => @"
         
resource 'azurerm_virtual_machine_scale_set' 'import' {
  location            = azurerm_resource_group.test.location
  name                = 'acctest-${local.random_integer}'
  resource_group_name = azurerm_resource_group.test.name
}


    ".AsTerraformTestConfig();

    public string? CompleteConfig => @"

resource 'azurerm_virtual_machine_scale_set' 'test' {
  location            = azurerm_resource_group.test.location
  name                = 'acctest-${local.random_integer}'
  resource_group_name = azurerm_resource_group.test.name

  additional_capabilities {
    hibernation_enabled = false
    ultra_ssd_enabled   = false
  }


  automatic_repairs_policy {
    enabled       = false
    grace_period  = 'foo'
    repair_action = 'foo'
  }

  do_not_run_extensions_on_overprovisioned_v_ms = false

  host_group {
    id = 'foo'
  }


  identity {
    type = 'SystemAssigned, UserAssigned'

    // todo add azurerm_user_assigned_identity.test to template
    identity_ids = [azurerm_user_assigned_identity.test.id]
  }

  orchestration_mode          = 'foo'
  overprovision               = false
  platform_fault_domain_count = 15

  proximity_placement_group {
    id = 'foo'
  }


  scale_in_policy {
    force_deletion = false

    rule = ['foo', 'baz']

  }

  single_placement_group = false

  sku {
    capacity = 15
    name     = 'acctest-${local.random_integer}'
    tier     = 'foo'
  }


  spot_restore_policy {
    enabled         = false
    restore_timeout = 'foo'
  }

  tags = {
    env  = 'Production'
    test = 'Acceptance'
  }

  upgrade_policy {

    automatic_os_upgrade_policy {
      automatic_os_upgrade_enabled = false
      automatic_rollback_disabled  = false
    }

    mode = 'foo'

    rolling_upgrade_policy {
      cross_zone_upgrade_enabled              = false
      max_batch_instance_percent              = 15
      max_unhealthy_instance_percent          = 15
      max_unhealthy_upgraded_instance_percent = 15
      pause_time_between_batches              = 'foo'
      prioritize_unhealthy_instances          = false
    }

  }


  virtual_machine_profile {

    application_profile {

      gallery_application {
        package_reference_id    = 'foo'
        configuration_reference = 'foo'
        order                   = 15
        tags                    = 'foo'
      }

    }


    billing_profile {
      max_price = 10.1
    }


    capacity_reservation {

      capacity_reservation_group {
        id = 'foo'
      }

    }


    diagnostics_profile {

      boot_diagnostics {
        enabled     = false
        storage_uri = 'foo'
      }

    }

    eviction_policy = 'foo'

    extension_profile {

      extension {
        name = 'acctest-${local.random_integer}'

        properties {
          auto_upgrade_minor_version = false
          automatic_upgrade_enabled  = false
          force_update_tag           = 'foo'

          provision_after_extension = ['foo', 'baz']

          publisher            = 'foo'
          suppress_failures    = false
          type                 = 'foo'
          type_handler_version = 'foo'
        }

      }

      extensions_time_budget = 'foo'
    }


    hardware_profile {

      vm_size_properties {
        vcp_us_available = 15
        vcp_us_per_core  = 15
      }

    }

    license_type = 'foo'

    network_profile {

      health_probe {
        id = 'foo'
      }

      network_api_version = 'foo'

      network_interface_configuration {
        name = 'acctest-${local.random_integer}'
        id   = 'foo'

        properties {

          ip_configuration {
            name = 'acctest-${local.random_integer}'
            id   = 'foo'

            properties {

              application_gateway_backend_address_pool {
                id = 'foo'
              }


              application_security_group {
                id = 'foo'
              }


              load_balancer_backend_address_pool {
                id = 'foo'
              }


              load_balancer_inbound_nat_pool {
                id = 'foo'
              }

              primary                    = false
              private_ip_address_version = 'foo'

              public_ip_address_configuration {
                name = 'acctest-${local.random_integer}'

                properties {
                  delete_option = 'foo'

                  dns_settings {
                    domain_name_label = 'foo'
                  }


                  ip_tag {
                    ip_tag_type = 'foo'
                    tag         = 'foo'
                  }

                  idle_timeout_in_minutes   = 15
                  public_ip_address_version = 'foo'

                  public_ip_prefix {
                    id = 'foo'
                  }

                }


                sku {
                  name = 'acctest-${local.random_integer}'
                  tier = 'foo'
                }

              }


              subnet {
                id = 'foo'
              }

            }

          }

          accelerated_networking_enabled = false
          delete_option                  = 'foo'

          dns_settings {

            dns_server = ['foo', 'baz']

          }

          fpga_enabled          = false
          ip_forwarding_enabled = false

          network_security_group {
            id = 'foo'
          }

          primary = false
        }

      }

    }


    os_profile {
      admin_password               = 'foo'
      admin_username               = 'foo'
      computer_name_prefix         = 'foo'
      custom_data                  = 'foo'
      extension_operations_enabled = false

      linux_configuration {
        password_authentication_disabled = false

        patch_settings {
          assessment_mode = 'foo'
          patch_mode      = 'foo'
        }

        provision_vm_agent = false

        ssh {

          public_key {
            key_data = 'foo'
            path     = 'foo'
          }

        }

      }


      secret {

        source_vault {
          id = 'foo'
        }


        vault_certificate {
          certificate_store = 'foo'
          certificate_url   = 'foo'
        }

      }


      windows_configuration {

        additional_unattend_content {
          component_name = 'foo'
          content        = 'foo'
          pass_name      = 'foo'
          setting_name   = 'foo'
        }

        automatic_updates_enabled = false

        patch_settings {
          assessment_mode     = 'foo'
          hotpatching_enabled = false
          patch_mode          = 'foo'
        }

        provision_vm_agent = false
        time_zone          = 'foo'

        win_rm {

          listener {
            certificate_url = 'foo'
            protocol        = 'foo'
          }

        }

      }

    }

    priority = 'foo'

    scheduled_events_profile {

      terminate_notification_profile {
        enabled            = false
        not_before_timeout = 'foo'
      }

    }


    security_profile {
      encryption_at_host = false
      security_type      = 'foo'

      uefi_settings {
        secure_boot_enabled = false
        v_tpm_enabled       = false
      }

    }


    storage_profile {

      data_disk {
        create_option         = 'foo'
        lun                   = 15
        caching               = 'foo'
        disk_iops_read_write  = 15
        disk_m_bps_read_write = 15
        disk_size_gb          = 15

        managed_disk {

          disk_encryption_set {
            id = 'foo'
          }


          security_profile {

            disk_encryption_set {
              id = 'foo'
            }

            security_encryption_type = 'foo'
          }

          storage_account_type = 'foo'
        }

        name                      = 'acctest-${local.random_integer}'
        write_accelerator_enabled = false
      }


      image_reference {
        community_gallery_image_id = 'foo'
        id                         = 'foo'
        offer                      = 'foo'
        publisher                  = 'foo'
        shared_gallery_image_id    = 'foo'
        sku                        = 'foo'
        version                    = 'foo'
      }


      os_disk {
        create_option = 'foo'
        caching       = 'foo'

        diff_disk_settings {
          option    = 'foo'
          placement = 'foo'
        }

        disk_size_gb = 15

        image {
          uri = 'foo'
        }


        managed_disk {

          disk_encryption_set {
            id = 'foo'
          }


          security_profile {

            disk_encryption_set {
              id = 'foo'
            }

            security_encryption_type = 'foo'
          }

          storage_account_type = 'foo'
        }

        name    = 'acctest-${local.random_integer}'
        os_type = 'foo'

        vhd_container = ['foo', 'baz']

        write_accelerator_enabled = false
      }

    }

    user_data = 'foo'
  }

  zone_balance = false
}


	".AsTerraformTestConfig();
    public string? TemplateConfig => @"
        resource 'azurerm_foo' 'bar' {
        }
    ".AsTerraformTestConfig();

    public Dictionary<string, List<string>> OtherTests => new Dictionary<string, List<string>>();
}
