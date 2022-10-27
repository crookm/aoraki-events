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

data "azurerm_resource_group" "rg" {
  name = "personal-aoraki"
}

resource "azurerm_eventgrid_domain" "domain" {
  name = "aoraki"

  location            = data.azurerm_resource_group.rg.location
  resource_group_name = data.azurerm_resource_group.rg.name

  tags = {
    Project = "AORAKI"
    Purpose = "Data"
    Tier    = "PROD"
  }
}
