// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Security.Claims;
using Newtonsoft.Json.Linq;

namespace Microsoft.AspNetCore.Authentication.OAuth
{
    public class JsonClaimResolver : ClaimResolver<JObject>
    {
        public JsonClaimResolver(string claimName, string claimType, string jsonKey)
            : base(claimName, claimType)
        {
            JsonKey = jsonKey;
        }

        public string JsonKey { get; }

        public override void Apply(JObject data, ClaimsIdentity identity, string issuer)
        {
            var value = data.Value<string>(JsonKey);
            if (!string.IsNullOrEmpty(value))
            {
                identity.AddClaim(new Claim(ClaimName, value, ClaimType, issuer));
            }
        }
    }
}
