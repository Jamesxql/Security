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
        public static void MapJsonKey(this ClaimMapperCollection<JObject> collection, string claimName, string jsonKey)
        {
            collection.MapJsonKey(claimName, jsonKey, ClaimValueTypes.String);
        }

        public static void MapJsonKey(this ClaimMapperCollection<JObject> collection, string claimName, string jsonKey, string claimType)
        {
            collection.Add(new JsonKeyClaimMapper(claimName, claimType, jsonKey));
        }

        public static void MapJsonSubKey(this ClaimMapperCollection<JObject> collection, string claimName, string jsonKey, string subKey)
        {
            collection.MapJsonSubKey(claimName, jsonKey, subKey, ClaimValueTypes.String);
        }

        public static void MapJsonSubKey(this ClaimMapperCollection<JObject> collection, string claimName, string jsonKey, string subKey, string claimType)
        {
            collection.Add(new JsonSubKeyClaimMapper(claimName, claimType, jsonKey, subKey));
        }

        public static void MapCustomJson(this ClaimMapperCollection<JObject> collection, string claimName, Func<JObject, string> resolver)
        {
            collection.MapCustomJson(claimName, ClaimValueTypes.String, resolver);
        }

        public static void MapCustomJson(this ClaimMapperCollection<JObject> collection, string claimName, string claimType, Func<JObject, string> resolver)
        {
            collection.Add(new JsonCustomClaimMapper(claimName, claimType, resolver));
        }
    }
}
