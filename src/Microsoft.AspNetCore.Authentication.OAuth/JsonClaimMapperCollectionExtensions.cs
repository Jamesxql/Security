// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.OAuth;
using Newtonsoft.Json.Linq;

namespace Microsoft.AspNetCore.Authentication
{
    public static class JsonClaimMapperCollectionExtensions
    {
        public static void MapJsonKey(this JsonClaimMapperCollection collection, string claimType, string jsonKey)
        {
            collection.MapJsonKey(claimType, jsonKey, ClaimValueTypes.String);
        }

        public static void MapJsonKey(this JsonClaimMapperCollection collection, string claimType, string jsonKey, string valueType)
        {
            collection.Add(new JsonKeyClaimMapper(claimType, valueType, jsonKey));
        }

        public static void MapJsonSubKey(this JsonClaimMapperCollection collection, string claimType, string jsonKey, string subKey)
        {
            collection.MapJsonSubKey(claimType, jsonKey, subKey, ClaimValueTypes.String);
        }

        public static void MapJsonSubKey(this JsonClaimMapperCollection collection, string claimType, string jsonKey, string subKey, string valueType)
        {
            collection.Add(new JsonSubKeyClaimMapper(claimType, valueType, jsonKey, subKey));
        }

        public static void MapCustomJson(this JsonClaimMapperCollection collection, string claimType, Func<JObject, string> resolver)
        {
            collection.MapCustomJson(claimType, ClaimValueTypes.String, resolver);
        }

        public static void MapCustomJson(this JsonClaimMapperCollection collection, string claimType, string valueType, Func<JObject, string> resolver)
        {
            collection.Add(new JsonCustomClaimMapper(claimType, valueType, resolver));
        }
    }
}
