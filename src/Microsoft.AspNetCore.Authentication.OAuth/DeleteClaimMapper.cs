// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Linq;
using System.Security.Claims;
using Newtonsoft.Json.Linq;

namespace Microsoft.AspNetCore.Authentication
{
    public class DeleteClaimMapper : JsonClaimMapper
    {
        public DeleteClaimMapper(string claimType)
            : base(claimType, ClaimValueTypes.String)
        {
        }

        public override void Map(JObject data, ClaimsIdentity identity, string issuer)
        {
            foreach (var claim in identity.FindAll(ClaimType).ToList())
            {
                identity.TryRemoveClaim(claim);
            }
        }
    }
}
