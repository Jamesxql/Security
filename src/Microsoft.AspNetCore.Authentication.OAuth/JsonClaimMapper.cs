// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Security.Claims;
using Newtonsoft.Json.Linq;

namespace Microsoft.AspNetCore.Authentication
{
    public abstract class JsonClaimMapper
    {
        public JsonClaimMapper(string claimType, string valueType)
        {
            ClaimType = claimType;
            ValueType = valueType;
        }

        public string ClaimType { get; }

        public string ValueType { get; }

        public abstract void Map(JObject data, ClaimsIdentity identity, string issuer);
    }
}
