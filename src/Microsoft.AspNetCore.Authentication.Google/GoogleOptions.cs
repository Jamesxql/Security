// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Http;

namespace Microsoft.AspNetCore.Builder
{
    /// <summary>
    /// Configuration options for <see cref="GoogleMiddleware"/>.
    /// </summary>
    public class GoogleOptions : OAuthOptions
    {
        /// <summary>
        /// Initializes a new <see cref="GoogleOptions"/>.
        /// </summary>
        public GoogleOptions()
        {
            AuthenticationScheme = GoogleDefaults.AuthenticationScheme;
            DisplayName = AuthenticationScheme;
            CallbackPath = new PathString("/signin-google");
            AuthorizationEndpoint = GoogleDefaults.AuthorizationEndpoint;
            TokenEndpoint = GoogleDefaults.TokenEndpoint;
            UserInformationEndpoint = GoogleDefaults.UserInformationEndpoint;
            Scope.Add("openid");
            Scope.Add("profile");
            Scope.Add("email");

            ClaimMaps.MapJsonKey(ClaimTypes.NameIdentifier, "id");
            ClaimMaps.MapJsonKey(ClaimTypes.Name, "displayName");
            ClaimMaps.MapJsonSubKey(ClaimTypes.GivenName, "name", "givenName");
            ClaimMaps.MapJsonSubKey(ClaimTypes.Surname, "name", "familyName");
            ClaimMaps.MapJsonKey("urn:google:profile", "url");
            ClaimMaps.MapCustomJson(ClaimTypes.Email, GoogleHelper.GetEmail);
        }

        /// <summary>
        /// access_type. Set to 'offline' to request a refresh token.
        /// </summary>
        public string AccessType { get; set; }
    }
}