// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using Newtonsoft.Json.Linq;
using System.Security.Claims;

namespace Microsoft.AspNetCore.Authentication.OAuth
{
    public class NestedJsonClaimResolver : JsonClaimResolver
    {
        public NestedJsonClaimResolver(string claimName, string claimType, string jsonKey, string subKey)
            : base(claimName, claimType, jsonKey)
        {
            SubKey = subKey;
        }

        public string SubKey { get; }

        public override void Apply(JObject data, ClaimsIdentity identity, string issuer)
        {
            var value = GetValue(data, JsonKey, SubKey);
            if (!string.IsNullOrEmpty(value))
            {
                identity.AddClaim(new Claim(ClaimName, value, ClaimType, issuer));
            }
        }

        // Get the given subProperty from a property.
        private static string GetValue(JObject user, string propertyName, string subProperty)
        {
            JToken value;
            if (user.TryGetValue(propertyName, out value))
            {
                var subObject = JObject.Parse(value.ToString());
                if (subObject != null && subObject.TryGetValue(subProperty, out value))
                {
                    return value.ToString();
                }
            }
            return null;
        }
    }
}
