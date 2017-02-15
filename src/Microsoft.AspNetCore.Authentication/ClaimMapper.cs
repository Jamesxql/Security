// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Security.Claims;

namespace Microsoft.AspNetCore.Authentication
{
    public abstract class ClaimMapper<T>
    {
        public ClaimMapper(string claimName, string claimType)
        {
            ClaimName = claimName;
            ClaimType = claimType;
        }

        public string ClaimName { get; }

        public string ClaimType { get; }

        public abstract void Map(T data, ClaimsIdentity identity, string issuer);
    }
}
