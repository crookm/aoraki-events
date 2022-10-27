terraform {
  required_version = ">= 0.14.0"
  required_providers {
    azurerm = {
      source  = "hashicorp/azurerm"
      version = "=3.0.0"
    }
  }

  backend "remote" {
    organization = "aoraki"

    workspaces {
      name = "events"
    }
  }
}

provider "azurerm" {
  features {}
  subscription_id = "6578c5cc-29fa-48c3-a658-556e20bfd3cb"
}

resource "azurerm_resource_group" "rg" {
  name     = "aoraki-events"
  location = "australia east"

  tags = local.tags
}

resource "azurerm_eventgrid_domain" "domain" {
  name = "aoraki"

  location            = azurerm_resource_group.rg.location
  resource_group_name = azurerm_resource_group.rg.name

  # only allows RBAC
  local_auth_enabled = false
  identity {
    type = "SystemAssigned"
  }

  tags = local.tags
}
