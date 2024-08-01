// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace TakeAway.IdentityServer
{
    public static class Config
    {
        public static IEnumerable<ApiResource> ApiResources => new ApiResource[]
        {
            new ApiResource("ResourceCatalog"){Scopes={"CatalogFullPermission"}},
            new ApiResource("ResourceCatalog2"){Scopes={"CatalogReadPermission"}},
            new ApiResource("ResourceOrder"){Scopes={"OrderFullPermission"}},
            new ApiResource("ResourceDiscount"){Scopes={"DiscountFullPermission"}},
            new ApiResource("ResourceCargo"){Scopes={"CargoFullPermission"}},
            new ApiResource("ResourceBasket"){Scopes={"BasketFullPermission"}},
            new ApiResource("ResourceComment"){Scopes={"CommentFullPermission"}},
            new ApiResource("ResourceMessage"){Scopes={"MessageFullPermission"}},
            new ApiResource("ResourceOselot"){Scopes={"OselotFullPermission"}},
            new ApiResource(IdentityServerConstants.LocalApi.ScopeName)
        };

        public static IEnumerable<IdentityResource> IdentityResources => new IdentityResource[]
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Profile(),
            new IdentityResources.Email(),
        };

        public static IEnumerable<ApiScope> ApiScopes => new ApiScope[]
        {
            new ApiScope("CatalogFullPermission","Full authority for catalog operations."),
            new ApiScope("OrderFullPermission","Full authority for order operations."),
            new ApiScope("DiscountFullPermission","Full authority for discount operations."),
            new ApiScope("CargoFullPermission","Full authority for cargo operations."),
            new ApiScope("BasketFullPermission","Full authority for basket operations."),
            new ApiScope("CommentFullPermission","Full authority for comment operations."),
            new ApiScope("MessageFullPermission","Full authority for message operations."),
            new ApiScope("OselotFullPermission","Full authority for oselot operations."),
            new ApiScope("CatalogReadPermission","Read authority for catalog operations."),
            new ApiScope(IdentityServerConstants.LocalApi.ScopeName)
        };

        public static IEnumerable<Client> Clients => new Client[]
        {
            new Client
            {
                ClientId="TakeAwayVisitorId",
                ClientName="TakeAwayVisitorUser",
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                ClientSecrets= {new Secret("takeawaysecret".Sha256())},
                AllowedScopes = { "CatalogReadPermission", "CatalogFullPermission", IdentityServerConstants.LocalApi.ScopeName},
                AllowAccessTokensViaBrowser = true,
            },
            new Client
            {
                ClientId="TakeAwayAdminId",
                ClientName="TakeAwayAdminUser",
                AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                ClientSecrets= {new Secret("takeawaysecret".Sha256())},
                AllowedScopes = {
                    "CatalogFullPermission",
                    "OrderFullPermission",
                    "DiscountFullPermission",
                    "CargoFullPermission",
                    "BasketFullPermission",
                    "CommentFullPermission",
                    "MessageFullPermission",
                    "OselotFullPermission",
                    "CatalogReadPermission",
                    IdentityServerConstants.LocalApi.ScopeName,
                    IdentityServerConstants.StandardScopes.Email,
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile,
                },
                AccessTokenLifetime = 6000
            },
        };
    }
}