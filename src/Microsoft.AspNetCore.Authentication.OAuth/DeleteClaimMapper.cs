// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Linq;
using System.Security.Claims;
using Newtonsoft.Json.Linq;

namespace Microsoft.AspNetCore.Authentication
{
    /// <summary>
    /// A JsonClaimMapper that deletes all claims from the given ClaimsIdentity with the given ClaimType.
    /// </summary>
    public class DeleteClaimMapper : JsonClaimMapper
    {
        /// <summary>
        /// Creates a new DeleteClaimMapper.
        /// </summary>
        /// <param name="claimType">The ClaimType of Claims to delete.</param>
        public DeleteClaimMapper(string claimType)
            : base(claimType, ClaimValueTypes.String)
        {
        }

        /// <inheritdoc />
        public override void Map(JObject userData, ClaimsIdentity identity, string issuer)
        {
            foreach (var claim in identity.FindAll(ClaimType).ToList())
            {
                identity.TryRemoveClaim(claim);
            }
        }
    }
}
