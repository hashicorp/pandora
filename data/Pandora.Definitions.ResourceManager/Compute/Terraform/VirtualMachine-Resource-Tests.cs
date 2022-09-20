using System.Collections.Generic;
using Pandora.Definitions.Helpers;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.Compute.Terraform;

public class VirtualMachineResourceTests : TerraformResourceTestDefinition
{
    // TODO: output real tests
    public string BasicTestConfig => @"
         
resource 'azurerm_virtual_machine' 'test' {
  location            = azurerm_resource_group.test.location
  name                = 'acctest-${local.random_integer}'
  resource_group_name = azurerm_resource_group.test.name
}


    ".AsTerraformTestConfig();

    public string RequiresImportConfig => @"
         
resource 'azurerm_virtual_machine' 'import' {
  location            = azurerm_resource_group.test.location
  name                = 'acctest-${local.random_integer}'
  resource_group_name = azurerm_resource_group.test.name
}


    ".AsTerraformTestConfig();

    public string? CompleteConfig => @"

resource 'azurerm_virtual_machine' 'test' {
  location            = azurerm_resource_group.test.location
  name                = 'acctest-${local.random_integer}'
  resource_group_name = azurerm_resource_group.test.name

  additional_capabilities {
    hibernation_enabled = false
    ultra_ssd_enabled   = false
  }


  application_profile {

    gallery_application {
      package_reference_id    = 'foo'
      configuration_reference = 'foo'
      order                   = 15
      tags                    = 'foo'
    }

  }


  availability_set {
    id = 'foo'
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

  eviction_policy        = 'foo'
  extensions_time_budget = 'foo'

  hardware_profile {
    vm_size = 'foo'

    vm_size_properties {
      vcp_us_available = 15
      vcp_us_per_core  = 15
    }

  }


  host {
    id = 'foo'
  }


  host_group {
    id = 'foo'
  }


  identity {
    type = 'SystemAssigned, UserAssigned'

    // todo add azurerm_user_assigned_identity.test to template
    identity_ids = [azurerm_user_assigned_identity.test.id]
  }


  network_profile {
    network_api_version = 'foo'

    network_interface {
      id = 'foo'

      properties {
        delete_option = 'foo'
        primary       = false
      }

    }


    network_interface_configuration {
      name = 'acctest-${local.random_integer}'

      properties {

        ip_configuration {
          name = 'acctest-${local.random_integer}'

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

                idle_timeout_in_minutes     = 15
                public_ip_address_version   = 'foo'
                public_ip_allocation_method = 'foo'

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


        dscp_configuration {
          id = 'foo'
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
    computer_name                = 'foo'
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

    require_guest_provision_signal = false

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

  platform_fault_domain = 15
  priority              = 'foo'

  proximity_placement_group {
    id = 'foo'
  }


  scale_set {
    id = 'foo'
  }


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
      create_option = 'foo'
      lun           = 15
      caching       = 'foo'
      delete_option = 'foo'
      detach_option = 'foo'
      disk_size_gb  = 15

      image {
        uri = 'foo'
      }


      managed_disk {

        disk_encryption_set {
          id = 'foo'
        }

        id = 'foo'

        security_profile {

          disk_encryption_set {
            id = 'foo'
          }

          security_encryption_type = 'foo'
        }

        storage_account_type = 'foo'
      }

      name           = 'acctest-${local.random_integer}'
      to_be_detached = false

      vhd {
        uri = 'foo'
      }

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
      delete_option = 'foo'

      diff_disk_settings {
        option    = 'foo'
        placement = 'foo'
      }

      disk_size_gb = 15

      encryption_settings {

        disk_encryption_key {
          secret_url = 'foo'

          source_vault {
            id = 'foo'
          }

        }

        enabled = false

        key_encryption_key {
          key_url = 'foo'

          source_vault {
            id = 'foo'
          }

        }

      }


      image {
        uri = 'foo'
      }


      managed_disk {

        disk_encryption_set {
          id = 'foo'
        }

        id = 'foo'

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

      vhd {
        uri = 'foo'
      }

      write_accelerator_enabled = false
    }

  }

  tags = {
    env  = 'Production'
    test = 'Acceptance'
  }
  user_data = 'foo'
}


	",AsTerraformTestConfig();
    public string? TemplateConfig => @"
        resource 'azurerm_foo' 'bar' {
        }
    ".AsTerraformTestConfig();

    public Dictionary<string, List<string>> OtherTests => new Dictionary<string, List<string>>();
}
