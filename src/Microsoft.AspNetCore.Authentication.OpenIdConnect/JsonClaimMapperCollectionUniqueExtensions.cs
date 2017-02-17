// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;

namespace Microsoft.AspNetCore.Authentication
{
    public static class JsonClaimMapperCollectionUniqueExtensions
    {
        public static void MapUniqueJsonKey(this JsonClaimMapperCollection collection, string claimType, string jsonKey)
        {
            collection.MapUniqueJsonKey(claimType, jsonKey, ClaimValueTypes.String);
        }

        public static void MapUniqueJsonKey(this JsonClaimMapperCollection collection, string claimType, string jsonKey, string valueType)
        {
            collection.Add(new UniqueJsonKeyClaimMapper(claimType, valueType, jsonKey));
        }
    }
}
