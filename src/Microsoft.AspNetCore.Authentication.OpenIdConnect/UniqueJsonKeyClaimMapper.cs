// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Newtonsoft.Json.Linq;

namespace Microsoft.AspNetCore.Authentication.OpenIdConnect
{
    public class UniqueJsonKeyClaimMapper : JsonClaimMapper
    {
        public UniqueJsonKeyClaimMapper(string claimType, string valueType, string jsonKey)
            : base(claimType, valueType)
        {
            JsonKey = jsonKey;
        }

        public string JsonKey { get; }

        public override void Map(JObject data, ClaimsIdentity identity, string issuer)
        {
            var value = data.Value<string>(JsonKey);
            if (string.IsNullOrEmpty(value))
            {
                // Not found
                return;
            }

            var claim = identity.FindFirst(c => string.Equals(c.Type, JsonKey, System.StringComparison.OrdinalIgnoreCase));
            if (claim != null && string.Equals(claim.Value, value, System.StringComparison.Ordinal))
            {
                // Duplicate
                return;
            }

            claim = identity.FindFirst(c =>
            {
                // If this claimType is mapped by the JwtSeurityTokenHandler, then this property will be set
                return c.Properties.TryGetValue(JwtSecurityTokenHandler.ShortClaimTypeProperty, out var shortType)
                    && string.Equals(shortType, JsonKey, System.StringComparison.OrdinalIgnoreCase);
            });
            if (claim != null && string.Equals(claim.Value, value, System.StringComparison.Ordinal))
            {
                // Duplicate with an alternate name.
                return;
            }

            identity.AddClaim(new Claim(ClaimType, value, ValueType, issuer));
        }
    }
}
