using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using RestSharp;
using System.Net;
using Newtonsoft.Json;
using RegionSyd.Web.Models;
using RegionSyd.Web.Services.Interfaces;

namespace RegionSyd.Web.Services
{
    public static class TokenService 
    {

        public const string ClientId = "VoeY963xpRlOMEW91YC7JG6ApdiJd3M1";
        public const string ClientSecret = "usoiR1AZax8QcTyhTP8woA6oe_HKdkpmVK_VkWbd-CAbWPxvUnyYGym-sGTF8D5e";
        public const string Url = "https://localhost:7297/api/";

        public static async Task<string> GetAccessToken()
        {

            var client = new RestClient("https://dev-9wu0y2-q.us.auth0.com/oauth/token");
            var request = new RestRequest("https://dev-9wu0y2-q.us.auth0.com/oauth/token", Method.Post);
            request.AddHeader("content-type", "application/x-www-form-urlencoded");
            request.AddParameter("application/x-www-form-urlencoded", $"grant_type=client_credentials&client_id=%24%7Baccount.clientId%7D&client_secret={ClientSecret}&audience={ClientId}", ParameterType.RequestBody);
            RestResponse response = client.Execute(request);


            if (response.StatusCode == HttpStatusCode.OK)
            {
                var token = JsonConvert.DeserializeObject<TokenResponse>(response.Content);

                return token.access_token;

            }
            else return string.Empty;
        }

    }
}
