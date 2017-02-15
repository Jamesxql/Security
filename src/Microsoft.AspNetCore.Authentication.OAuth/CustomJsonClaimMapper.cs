// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Security.Claims;
using Newtonsoft.Json.Linq;

namespace Microsoft.AspNetCore.Authentication.OAuth
{
    public class CustomJsonClaimMapper : ClaimMapper<JObject>
    {
        public CustomJsonClaimMapper(string claimName, string claimType, Func<JObject, string> resolver)
            : base(claimName, claimType)
        {
            Resolver = resolver;
        }

        public Func<JObject, string> Resolver { get; }

        public override void Map(JObject data, ClaimsIdentity identity, string issuer)
        {
            var value = Resolver(data);
            if (!string.IsNullOrEmpty(value))
            {
                identity.AddClaim(new Claim(ClaimName, value, ClaimType, issuer));
            }
        }
    }
}
