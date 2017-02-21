// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Security.Claims;
using Newtonsoft.Json.Linq;

namespace Microsoft.AspNetCore.Authentication.OAuth
{
    /// <summary>
    /// A JsonClaimMapper that selects the value from the json user data by running the given Func resolver.
    /// </summary>
    public class JsonCustomClaimMapper : JsonClaimMapper
    {
        /// <summary>
        /// Creates a new JsonCustomClaimMapper.
        /// </summary>
        /// <param name="claimType">The value to use for Claim.Type when creating a Claim.</param>
        /// <param name="valueType">The value to use for Claim.ValueType when creating a Claim.</param>
        /// <param name="resolver">The Func that will be called to select value from the given json user data.</param>
        public JsonCustomClaimMapper(string claimType, string valueType, Func<JObject, string> resolver)
            : base(claimType, valueType)
        {
            Resolver = resolver;
        }

        /// <summary>
        /// The Func that will be called to select value from the given json user data.
        /// </summary>
        public Func<JObject, string> Resolver { get; }

        /// <inheritdoc />
        public override void Map(JObject userData, ClaimsIdentity identity, string issuer)
        {
            var value = Resolver(userData);
            if (!string.IsNullOrEmpty(value))
            {
                identity.AddClaim(new Claim(ClaimType, value, ValueType, issuer));
            }
        }
    }
}
