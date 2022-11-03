
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Web;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Components;
using VirtualLeague.Models.ConData;

namespace VirtualLeague
{
    public partial class ConDataService
    {
        private readonly HttpClient httpClient;
        private readonly Uri baseUri;
        private readonly NavigationManager navigationManager;
        public ConDataService(NavigationManager navigationManager, HttpClient httpClient, IConfiguration configuration)
        {
            this.httpClient = httpClient;

            this.navigationManager = navigationManager;
            this.baseUri = new Uri($"{navigationManager.BaseUri}odata/ConData/");
        }

        public async System.Threading.Tasks.Task ExportAspNetRolesToExcel(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/condata/aspnetroles/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/condata/aspnetroles/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportAspNetRolesToCSV(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/condata/aspnetroles/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/condata/aspnetroles/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }
        partial void OnGetAspNetRoles(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Radzen.ODataServiceResult<VirtualLeague.Models.ConData.AspNetRole>> GetAspNetRoles(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"AspNetRoles");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetAspNetRoles(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<VirtualLeague.Models.ConData.AspNetRole>>(response);
        }
        partial void OnCreateAspNetRole(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<VirtualLeague.Models.ConData.AspNetRole> CreateAspNetRole(VirtualLeague.Models.ConData.AspNetRole aspNetRole = default(VirtualLeague.Models.ConData.AspNetRole))
        {
            var uri = new Uri(baseUri, $"AspNetRoles");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(aspNetRole), Encoding.UTF8, "application/json");

            OnCreateAspNetRole(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<VirtualLeague.Models.ConData.AspNetRole>(response);
        }

        public async System.Threading.Tasks.Task ExportAspNetRoleClaimsToExcel(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/condata/aspnetroleclaims/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/condata/aspnetroleclaims/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportAspNetRoleClaimsToCSV(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/condata/aspnetroleclaims/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/condata/aspnetroleclaims/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }
        partial void OnGetAspNetRoleClaims(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Radzen.ODataServiceResult<VirtualLeague.Models.ConData.AspNetRoleClaim>> GetAspNetRoleClaims(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"AspNetRoleClaims");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetAspNetRoleClaims(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<VirtualLeague.Models.ConData.AspNetRoleClaim>>(response);
        }
        partial void OnCreateAspNetRoleClaim(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<VirtualLeague.Models.ConData.AspNetRoleClaim> CreateAspNetRoleClaim(VirtualLeague.Models.ConData.AspNetRoleClaim aspNetRoleClaim = default(VirtualLeague.Models.ConData.AspNetRoleClaim))
        {
            var uri = new Uri(baseUri, $"AspNetRoleClaims");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(aspNetRoleClaim), Encoding.UTF8, "application/json");

            OnCreateAspNetRoleClaim(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<VirtualLeague.Models.ConData.AspNetRoleClaim>(response);
        }

        public async System.Threading.Tasks.Task ExportAspNetUsersToExcel(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/condata/aspnetusers/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/condata/aspnetusers/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportAspNetUsersToCSV(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/condata/aspnetusers/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/condata/aspnetusers/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }
        partial void OnGetAspNetUsers(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Radzen.ODataServiceResult<VirtualLeague.Models.ConData.AspNetUser>> GetAspNetUsers(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"AspNetUsers");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetAspNetUsers(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<VirtualLeague.Models.ConData.AspNetUser>>(response);
        }
        partial void OnCreateAspNetUser(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<VirtualLeague.Models.ConData.AspNetUser> CreateAspNetUser(VirtualLeague.Models.ConData.AspNetUser aspNetUser = default(VirtualLeague.Models.ConData.AspNetUser))
        {
            var uri = new Uri(baseUri, $"AspNetUsers");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(aspNetUser), Encoding.UTF8, "application/json");

            OnCreateAspNetUser(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<VirtualLeague.Models.ConData.AspNetUser>(response);
        }

        public async System.Threading.Tasks.Task ExportAspNetUserClaimsToExcel(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/condata/aspnetuserclaims/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/condata/aspnetuserclaims/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportAspNetUserClaimsToCSV(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/condata/aspnetuserclaims/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/condata/aspnetuserclaims/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }
        partial void OnGetAspNetUserClaims(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Radzen.ODataServiceResult<VirtualLeague.Models.ConData.AspNetUserClaim>> GetAspNetUserClaims(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"AspNetUserClaims");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetAspNetUserClaims(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<VirtualLeague.Models.ConData.AspNetUserClaim>>(response);
        }
        partial void OnCreateAspNetUserClaim(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<VirtualLeague.Models.ConData.AspNetUserClaim> CreateAspNetUserClaim(VirtualLeague.Models.ConData.AspNetUserClaim aspNetUserClaim = default(VirtualLeague.Models.ConData.AspNetUserClaim))
        {
            var uri = new Uri(baseUri, $"AspNetUserClaims");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(aspNetUserClaim), Encoding.UTF8, "application/json");

            OnCreateAspNetUserClaim(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<VirtualLeague.Models.ConData.AspNetUserClaim>(response);
        }

        public async System.Threading.Tasks.Task ExportAspNetUserLoginsToExcel(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/condata/aspnetuserlogins/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/condata/aspnetuserlogins/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportAspNetUserLoginsToCSV(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/condata/aspnetuserlogins/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/condata/aspnetuserlogins/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }
        partial void OnGetAspNetUserLogins(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Radzen.ODataServiceResult<VirtualLeague.Models.ConData.AspNetUserLogin>> GetAspNetUserLogins(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"AspNetUserLogins");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetAspNetUserLogins(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<VirtualLeague.Models.ConData.AspNetUserLogin>>(response);
        }
        partial void OnCreateAspNetUserLogin(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<VirtualLeague.Models.ConData.AspNetUserLogin> CreateAspNetUserLogin(VirtualLeague.Models.ConData.AspNetUserLogin aspNetUserLogin = default(VirtualLeague.Models.ConData.AspNetUserLogin))
        {
            var uri = new Uri(baseUri, $"AspNetUserLogins");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(aspNetUserLogin), Encoding.UTF8, "application/json");

            OnCreateAspNetUserLogin(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<VirtualLeague.Models.ConData.AspNetUserLogin>(response);
        }

        public async System.Threading.Tasks.Task ExportAspNetUserRolesToExcel(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/condata/aspnetuserroles/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/condata/aspnetuserroles/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportAspNetUserRolesToCSV(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/condata/aspnetuserroles/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/condata/aspnetuserroles/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }
        partial void OnGetAspNetUserRoles(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Radzen.ODataServiceResult<VirtualLeague.Models.ConData.AspNetUserRole>> GetAspNetUserRoles(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"AspNetUserRoles");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetAspNetUserRoles(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<VirtualLeague.Models.ConData.AspNetUserRole>>(response);
        }
        partial void OnCreateAspNetUserRole(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<VirtualLeague.Models.ConData.AspNetUserRole> CreateAspNetUserRole(VirtualLeague.Models.ConData.AspNetUserRole aspNetUserRole = default(VirtualLeague.Models.ConData.AspNetUserRole))
        {
            var uri = new Uri(baseUri, $"AspNetUserRoles");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(aspNetUserRole), Encoding.UTF8, "application/json");

            OnCreateAspNetUserRole(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<VirtualLeague.Models.ConData.AspNetUserRole>(response);
        }

        public async System.Threading.Tasks.Task ExportAspNetUserTokensToExcel(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/condata/aspnetusertokens/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/condata/aspnetusertokens/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportAspNetUserTokensToCSV(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/condata/aspnetusertokens/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/condata/aspnetusertokens/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }
        partial void OnGetAspNetUserTokens(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Radzen.ODataServiceResult<VirtualLeague.Models.ConData.AspNetUserToken>> GetAspNetUserTokens(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"AspNetUserTokens");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetAspNetUserTokens(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<VirtualLeague.Models.ConData.AspNetUserToken>>(response);
        }
        partial void OnCreateAspNetUserToken(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<VirtualLeague.Models.ConData.AspNetUserToken> CreateAspNetUserToken(VirtualLeague.Models.ConData.AspNetUserToken aspNetUserToken = default(VirtualLeague.Models.ConData.AspNetUserToken))
        {
            var uri = new Uri(baseUri, $"AspNetUserTokens");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(aspNetUserToken), Encoding.UTF8, "application/json");

            OnCreateAspNetUserToken(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<VirtualLeague.Models.ConData.AspNetUserToken>(response);
        }

        public async System.Threading.Tasks.Task ExportDeviceCodesToExcel(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/condata/devicecodes/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/condata/devicecodes/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportDeviceCodesToCSV(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/condata/devicecodes/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/condata/devicecodes/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }
        partial void OnGetDeviceCodes(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Radzen.ODataServiceResult<VirtualLeague.Models.ConData.DeviceCode>> GetDeviceCodes(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"DeviceCodes");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetDeviceCodes(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<VirtualLeague.Models.ConData.DeviceCode>>(response);
        }
        partial void OnCreateDeviceCode(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<VirtualLeague.Models.ConData.DeviceCode> CreateDeviceCode(VirtualLeague.Models.ConData.DeviceCode deviceCode = default(VirtualLeague.Models.ConData.DeviceCode))
        {
            var uri = new Uri(baseUri, $"DeviceCodes");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(deviceCode), Encoding.UTF8, "application/json");

            OnCreateDeviceCode(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<VirtualLeague.Models.ConData.DeviceCode>(response);
        }

        public async System.Threading.Tasks.Task ExportExportFixtureGeneratorsToExcel(string Team1, string Team2, string Team3, string Team4, string Team5, string Team6, string Team7, string Team8, string Team9, string Team10, string Team11, string Team12, string Team13, string Team14, string Team15, string Team16, string Team17, string Team18, string Team19, string Team20, Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/condata/fixturegenerators/excel(Team1='{Team1}', Team2='{Team2}', Team3='{Team3}', Team4='{Team4}', Team5='{Team5}', Team6='{Team6}', Team7='{Team7}', Team8='{Team8}', Team9='{Team9}', Team10='{Team10}', Team11='{Team11}', Team12='{Team12}', Team13='{Team13}', Team14='{Team14}', Team15='{Team15}', Team16='{Team16}', Team17='{Team17}', Team18='{Team18}', Team19='{Team19}', Team20='{Team20}', fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/condata/fixturegenerators/excel(Team1='{Team1}', Team2='{Team2}', Team3='{Team3}', Team4='{Team4}', Team5='{Team5}', Team6='{Team6}', Team7='{Team7}', Team8='{Team8}', Team9='{Team9}', Team10='{Team10}', Team11='{Team11}', Team12='{Team12}', Team13='{Team13}', Team14='{Team14}', Team15='{Team15}', Team16='{Team16}', Team17='{Team17}', Team18='{Team18}', Team19='{Team19}', Team20='{Team20}', fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportFixtureGeneratorsToCSV(string Team1, string Team2, string Team3, string Team4, string Team5, string Team6, string Team7, string Team8, string Team9, string Team10, string Team11, string Team12, string Team13, string Team14, string Team15, string Team16, string Team17, string Team18, string Team19, string Team20, Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/condata/fixturegenerators/csv(Team1='{Team1}', Team2='{Team2}', Team3='{Team3}', Team4='{Team4}', Team5='{Team5}', Team6='{Team6}', Team7='{Team7}', Team8='{Team8}', Team9='{Team9}', Team10='{Team10}', Team11='{Team11}', Team12='{Team12}', Team13='{Team13}', Team14='{Team14}', Team15='{Team15}', Team16='{Team16}', Team17='{Team17}', Team18='{Team18}', Team19='{Team19}', Team20='{Team20}', fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/condata/fixturegenerators/csv(Team1='{Team1}', Team2='{Team2}', Team3='{Team3}', Team4='{Team4}', Team5='{Team5}', Team6='{Team6}', Team7='{Team7}', Team8='{Team8}', Team9='{Team9}', Team10='{Team10}', Team11='{Team11}', Team12='{Team12}', Team13='{Team13}', Team14='{Team14}', Team15='{Team15}', Team16='{Team16}', Team17='{Team17}', Team18='{Team18}', Team19='{Team19}', Team20='{Team20}', fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }
        partial void OnGetFixtureGenerators(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Radzen.ODataServiceResult<VirtualLeague.Models.ConData.FixtureGenerator>> GetFixtureGenerators(string team1 = default(string), string team2 = default(string), string team3 = default(string), string team4 = default(string), string team5 = default(string), string team6 = default(string), string team7 = default(string), string team8 = default(string), string team9 = default(string), string team10 = default(string), string team11 = default(string), string team12 = default(string), string team13 = default(string), string team14 = default(string), string team15 = default(string), string team16 = default(string), string team17 = default(string), string team18 = default(string), string team19 = default(string), string team20 = default(string), string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"FixtureGeneratorsFunc(Team1='{HttpUtility.UrlEncode(team1.Trim().Replace("'", "''"))}',Team2='{HttpUtility.UrlEncode(team2.Trim().Replace("'", "''"))}',Team3='{HttpUtility.UrlEncode(team3.Trim().Replace("'", "''"))}',Team4='{HttpUtility.UrlEncode(team4.Trim().Replace("'", "''"))}',Team5='{HttpUtility.UrlEncode(team5.Trim().Replace("'", "''"))}',Team6='{HttpUtility.UrlEncode(team6.Trim().Replace("'", "''"))}',Team7='{HttpUtility.UrlEncode(team7.Trim().Replace("'", "''"))}',Team8='{HttpUtility.UrlEncode(team8.Trim().Replace("'", "''"))}',Team9='{HttpUtility.UrlEncode(team9.Trim().Replace("'", "''"))}',Team10='{HttpUtility.UrlEncode(team10.Trim().Replace("'", "''"))}',Team11='{HttpUtility.UrlEncode(team11.Trim().Replace("'", "''"))}',Team12='{HttpUtility.UrlEncode(team12.Trim().Replace("'", "''"))}',Team13='{HttpUtility.UrlEncode(team13.Trim().Replace("'", "''"))}',Team14='{HttpUtility.UrlEncode(team14.Trim().Replace("'", "''"))}',Team15='{HttpUtility.UrlEncode(team15.Trim().Replace("'", "''"))}',Team16='{HttpUtility.UrlEncode(team16.Trim().Replace("'", "''"))}',Team17='{HttpUtility.UrlEncode(team17.Trim().Replace("'", "''"))}',Team18='{HttpUtility.UrlEncode(team18.Trim().Replace("'", "''"))}',Team19='{HttpUtility.UrlEncode(team19.Trim().Replace("'", "''"))}',Team20='{HttpUtility.UrlEncode(team20.Trim().Replace("'", "''"))}')");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetFixtureGenerators(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<VirtualLeague.Models.ConData.FixtureGenerator>>(response);
        }

        public async System.Threading.Tasks.Task ExportFixtureTemplatesToExcel(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/condata/fixturetemplates/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/condata/fixturetemplates/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportFixtureTemplatesToCSV(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/condata/fixturetemplates/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/condata/fixturetemplates/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }
        partial void OnGetFixtureTemplates(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Radzen.ODataServiceResult<VirtualLeague.Models.ConData.FixtureTemplate>> GetFixtureTemplates(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"FixtureTemplates");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetFixtureTemplates(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<VirtualLeague.Models.ConData.FixtureTemplate>>(response);
        }
        partial void OnCreateFixtureTemplate(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<VirtualLeague.Models.ConData.FixtureTemplate> CreateFixtureTemplate(VirtualLeague.Models.ConData.FixtureTemplate fixtureTemplate = default(VirtualLeague.Models.ConData.FixtureTemplate))
        {
            var uri = new Uri(baseUri, $"FixtureTemplates");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(fixtureTemplate), Encoding.UTF8, "application/json");

            OnCreateFixtureTemplate(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<VirtualLeague.Models.ConData.FixtureTemplate>(response);
        }

        public async System.Threading.Tasks.Task ExportKeysToExcel(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/condata/keys/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/condata/keys/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportKeysToCSV(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/condata/keys/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/condata/keys/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }
        partial void OnGetKeys(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Radzen.ODataServiceResult<VirtualLeague.Models.ConData.Key>> GetKeys(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"Keys");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetKeys(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<VirtualLeague.Models.ConData.Key>>(response);
        }
        partial void OnCreateKey(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<VirtualLeague.Models.ConData.Key> CreateKey(VirtualLeague.Models.ConData.Key key = default(VirtualLeague.Models.ConData.Key))
        {
            var uri = new Uri(baseUri, $"Keys");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(key), Encoding.UTF8, "application/json");

            OnCreateKey(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<VirtualLeague.Models.ConData.Key>(response);
        }

        public async System.Threading.Tasks.Task ExportLeagueSeasonsToExcel(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/condata/leagueseasons/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/condata/leagueseasons/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportLeagueSeasonsToCSV(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/condata/leagueseasons/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/condata/leagueseasons/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }
        partial void OnGetLeagueSeasons(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Radzen.ODataServiceResult<VirtualLeague.Models.ConData.LeagueSeason>> GetLeagueSeasons(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"LeagueSeasons");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetLeagueSeasons(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<VirtualLeague.Models.ConData.LeagueSeason>>(response);
        }
        partial void OnCreateLeagueSeason(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<VirtualLeague.Models.ConData.LeagueSeason> CreateLeagueSeason(VirtualLeague.Models.ConData.LeagueSeason leagueSeason = default(VirtualLeague.Models.ConData.LeagueSeason))
        {
            var uri = new Uri(baseUri, $"LeagueSeasons");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(leagueSeason), Encoding.UTF8, "application/json");

            OnCreateLeagueSeason(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<VirtualLeague.Models.ConData.LeagueSeason>(response);
        }

        public async System.Threading.Tasks.Task ExportMatchDaysToExcel(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/condata/matchdays/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/condata/matchdays/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportMatchDaysToCSV(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/condata/matchdays/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/condata/matchdays/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }
        partial void OnGetMatchDays(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Radzen.ODataServiceResult<VirtualLeague.Models.ConData.MatchDay>> GetMatchDays(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"MatchDays");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetMatchDays(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<VirtualLeague.Models.ConData.MatchDay>>(response);
        }
        partial void OnCreateMatchDay(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<VirtualLeague.Models.ConData.MatchDay> CreateMatchDay(VirtualLeague.Models.ConData.MatchDay matchDay = default(VirtualLeague.Models.ConData.MatchDay))
        {
            var uri = new Uri(baseUri, $"MatchDays");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(matchDay), Encoding.UTF8, "application/json");

            OnCreateMatchDay(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<VirtualLeague.Models.ConData.MatchDay>(response);
        }

        public async System.Threading.Tasks.Task ExportPersistedGrantsToExcel(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/condata/persistedgrants/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/condata/persistedgrants/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportPersistedGrantsToCSV(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/condata/persistedgrants/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/condata/persistedgrants/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }
        partial void OnGetPersistedGrants(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Radzen.ODataServiceResult<VirtualLeague.Models.ConData.PersistedGrant>> GetPersistedGrants(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"PersistedGrants");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetPersistedGrants(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<VirtualLeague.Models.ConData.PersistedGrant>>(response);
        }
        partial void OnCreatePersistedGrant(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<VirtualLeague.Models.ConData.PersistedGrant> CreatePersistedGrant(VirtualLeague.Models.ConData.PersistedGrant persistedGrant = default(VirtualLeague.Models.ConData.PersistedGrant))
        {
            var uri = new Uri(baseUri, $"PersistedGrants");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(persistedGrant), Encoding.UTF8, "application/json");

            OnCreatePersistedGrant(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<VirtualLeague.Models.ConData.PersistedGrant>(response);
        }

        public async System.Threading.Tasks.Task ExportSeasonFixturesToExcel(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/condata/seasonfixtures/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/condata/seasonfixtures/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportSeasonFixturesToCSV(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/condata/seasonfixtures/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/condata/seasonfixtures/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }
        partial void OnGetSeasonFixtures(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Radzen.ODataServiceResult<VirtualLeague.Models.ConData.SeasonFixture>> GetSeasonFixtures(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"SeasonFixtures");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetSeasonFixtures(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<VirtualLeague.Models.ConData.SeasonFixture>>(response);
        }
        partial void OnCreateSeasonFixture(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<VirtualLeague.Models.ConData.SeasonFixture> CreateSeasonFixture(VirtualLeague.Models.ConData.SeasonFixture seasonFixture = default(VirtualLeague.Models.ConData.SeasonFixture))
        {
            var uri = new Uri(baseUri, $"SeasonFixtures");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(seasonFixture), Encoding.UTF8, "application/json");

            OnCreateSeasonFixture(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<VirtualLeague.Models.ConData.SeasonFixture>(response);
        }

        public async System.Threading.Tasks.Task ExportExportSeasonFixturesListsToExcel(int? SeasonID, Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/condata/seasonfixtureslists/excel(SeasonID={SeasonID}, fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/condata/seasonfixtureslists/excel(SeasonID={SeasonID}, fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportSeasonFixturesListsToCSV(int? SeasonID, Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/condata/seasonfixtureslists/csv(SeasonID={SeasonID}, fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/condata/seasonfixtureslists/csv(SeasonID={SeasonID}, fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }
        partial void OnGetSeasonFixturesLists(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Radzen.ODataServiceResult<VirtualLeague.Models.ConData.SeasonFixturesList>> GetSeasonFixturesLists(int? seasonId = default(int?), string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"SeasonFixturesListsFunc(SeasonID={seasonId})");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetSeasonFixturesLists(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<VirtualLeague.Models.ConData.SeasonFixturesList>>(response);
        }

        public async System.Threading.Tasks.Task ExportTeamsToExcel(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/condata/teams/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/condata/teams/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportTeamsToCSV(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/condata/teams/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/condata/teams/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }
        partial void OnGetTeams(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Radzen.ODataServiceResult<VirtualLeague.Models.ConData.Team>> GetTeams(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"Teams");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetTeams(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<VirtualLeague.Models.ConData.Team>>(response);
        }
        partial void OnCreateTeam(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<VirtualLeague.Models.ConData.Team> CreateTeam(VirtualLeague.Models.ConData.Team team = default(VirtualLeague.Models.ConData.Team))
        {
            var uri = new Uri(baseUri, $"Teams");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(team), Encoding.UTF8, "application/json");

            OnCreateTeam(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<VirtualLeague.Models.ConData.Team>(response);
        }

        public async System.Threading.Tasks.Task ExportVirtualLeagueResultsToExcel(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/condata/virtualleagueresults/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/condata/virtualleagueresults/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async System.Threading.Tasks.Task ExportVirtualLeagueResultsToCSV(Radzen.Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/condata/virtualleagueresults/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/condata/virtualleagueresults/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }
        partial void OnGetVirtualLeagueResults(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<Radzen.ODataServiceResult<VirtualLeague.Models.ConData.VirtualLeagueResult>> GetVirtualLeagueResults(string filter = default(string), string orderby = default(string), string expand = default(string), int? top = default(int?), int? skip = default(int?), bool? count = default(bool?), string format = default(string), string select = default(string))
        {
            var uri = new Uri(baseUri, $"VirtualLeagueResults");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:filter, top:top, skip:skip, orderby:orderby, expand:expand, select:select, count:count);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetVirtualLeagueResults(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<Radzen.ODataServiceResult<VirtualLeague.Models.ConData.VirtualLeagueResult>>(response);
        }
        partial void OnCreateVirtualLeagueResult(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<VirtualLeague.Models.ConData.VirtualLeagueResult> CreateVirtualLeagueResult(VirtualLeague.Models.ConData.VirtualLeagueResult virtualLeagueResult = default(VirtualLeague.Models.ConData.VirtualLeagueResult))
        {
            var uri = new Uri(baseUri, $"VirtualLeagueResults");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, uri);


            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(virtualLeagueResult), Encoding.UTF8, "application/json");

            OnCreateVirtualLeagueResult(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<VirtualLeague.Models.ConData.VirtualLeagueResult>(response);
        }
        partial void OnDeleteAspNetRole(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> DeleteAspNetRole(string id = default(string))
        {
            var uri = new Uri(baseUri, $"AspNetRoles('{HttpUtility.UrlEncode(id.Trim().Replace("'", "''"))}')");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteAspNetRole(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnGetAspNetRoleById(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<VirtualLeague.Models.ConData.AspNetRole> GetAspNetRoleById(string expand = default(string), string id = default(string))
        {
            var uri = new Uri(baseUri, $"AspNetRoles('{HttpUtility.UrlEncode(id.Trim().Replace("'", "''"))}')");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:null, top:null, skip:null, orderby:null, expand:expand, select:null, count:null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetAspNetRoleById(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<VirtualLeague.Models.ConData.AspNetRole>(response);
        }
        partial void OnUpdateAspNetRole(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> UpdateAspNetRole(string id = default(string), VirtualLeague.Models.ConData.AspNetRole aspNetRole = default(VirtualLeague.Models.ConData.AspNetRole))
        {
            var uri = new Uri(baseUri, $"AspNetRoles('{HttpUtility.UrlEncode(id.Trim().Replace("'", "''"))}')");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);

            httpRequestMessage.Headers.Add("If-Match", aspNetRole.ETag);

            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(aspNetRole), Encoding.UTF8, "application/json");

            OnUpdateAspNetRole(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnDeleteAspNetRoleClaim(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> DeleteAspNetRoleClaim(int? id = default(int?))
        {
            var uri = new Uri(baseUri, $"AspNetRoleClaims({id})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteAspNetRoleClaim(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnGetAspNetRoleClaimById(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<VirtualLeague.Models.ConData.AspNetRoleClaim> GetAspNetRoleClaimById(string expand = default(string), int? id = default(int?))
        {
            var uri = new Uri(baseUri, $"AspNetRoleClaims({id})");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:null, top:null, skip:null, orderby:null, expand:expand, select:null, count:null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetAspNetRoleClaimById(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<VirtualLeague.Models.ConData.AspNetRoleClaim>(response);
        }
        partial void OnUpdateAspNetRoleClaim(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> UpdateAspNetRoleClaim(int? id = default(int?), VirtualLeague.Models.ConData.AspNetRoleClaim aspNetRoleClaim = default(VirtualLeague.Models.ConData.AspNetRoleClaim))
        {
            var uri = new Uri(baseUri, $"AspNetRoleClaims({id})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);

            httpRequestMessage.Headers.Add("If-Match", aspNetRoleClaim.ETag);

            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(aspNetRoleClaim), Encoding.UTF8, "application/json");

            OnUpdateAspNetRoleClaim(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnDeleteAspNetUser(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> DeleteAspNetUser(string id = default(string))
        {
            var uri = new Uri(baseUri, $"AspNetUsers('{HttpUtility.UrlEncode(id.Trim().Replace("'", "''"))}')");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteAspNetUser(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnGetAspNetUserById(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<VirtualLeague.Models.ConData.AspNetUser> GetAspNetUserById(string expand = default(string), string id = default(string))
        {
            var uri = new Uri(baseUri, $"AspNetUsers('{HttpUtility.UrlEncode(id.Trim().Replace("'", "''"))}')");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:null, top:null, skip:null, orderby:null, expand:expand, select:null, count:null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetAspNetUserById(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<VirtualLeague.Models.ConData.AspNetUser>(response);
        }
        partial void OnUpdateAspNetUser(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> UpdateAspNetUser(string id = default(string), VirtualLeague.Models.ConData.AspNetUser aspNetUser = default(VirtualLeague.Models.ConData.AspNetUser))
        {
            var uri = new Uri(baseUri, $"AspNetUsers('{HttpUtility.UrlEncode(id.Trim().Replace("'", "''"))}')");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);

            httpRequestMessage.Headers.Add("If-Match", aspNetUser.ETag);

            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(aspNetUser), Encoding.UTF8, "application/json");

            OnUpdateAspNetUser(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnDeleteAspNetUserClaim(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> DeleteAspNetUserClaim(int? id = default(int?))
        {
            var uri = new Uri(baseUri, $"AspNetUserClaims({id})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteAspNetUserClaim(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnGetAspNetUserClaimById(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<VirtualLeague.Models.ConData.AspNetUserClaim> GetAspNetUserClaimById(string expand = default(string), int? id = default(int?))
        {
            var uri = new Uri(baseUri, $"AspNetUserClaims({id})");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:null, top:null, skip:null, orderby:null, expand:expand, select:null, count:null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetAspNetUserClaimById(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<VirtualLeague.Models.ConData.AspNetUserClaim>(response);
        }
        partial void OnUpdateAspNetUserClaim(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> UpdateAspNetUserClaim(int? id = default(int?), VirtualLeague.Models.ConData.AspNetUserClaim aspNetUserClaim = default(VirtualLeague.Models.ConData.AspNetUserClaim))
        {
            var uri = new Uri(baseUri, $"AspNetUserClaims({id})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);

            httpRequestMessage.Headers.Add("If-Match", aspNetUserClaim.ETag);

            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(aspNetUserClaim), Encoding.UTF8, "application/json");

            OnUpdateAspNetUserClaim(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnDeleteAspNetUserLogin(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> DeleteAspNetUserLogin(string loginProvider = default(string), string providerKey = default(string))
        {
            var uri = new Uri(baseUri, $"AspNetUserLogins(LoginProvider='{HttpUtility.UrlEncode(loginProvider.Trim().Replace("'", "''"))}',ProviderKey='{HttpUtility.UrlEncode(providerKey.Trim().Replace("'", "''"))}')");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteAspNetUserLogin(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnGetAspNetUserLoginByLoginProviderAndProviderKey(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<VirtualLeague.Models.ConData.AspNetUserLogin> GetAspNetUserLoginByLoginProviderAndProviderKey(string loginProvider = default(string), string providerKey = default(string))
        {
            var uri = new Uri(baseUri, $"AspNetUserLogins(LoginProvider='{HttpUtility.UrlEncode(loginProvider.Trim().Replace("'", "''"))}',ProviderKey='{HttpUtility.UrlEncode(providerKey.Trim().Replace("'", "''"))}')");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetAspNetUserLoginByLoginProviderAndProviderKey(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<VirtualLeague.Models.ConData.AspNetUserLogin>(response);
        }
        partial void OnUpdateAspNetUserLogin(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> UpdateAspNetUserLogin(string loginProvider = default(string), string providerKey = default(string), VirtualLeague.Models.ConData.AspNetUserLogin aspNetUserLogin = default(VirtualLeague.Models.ConData.AspNetUserLogin))
        {
            var uri = new Uri(baseUri, $"AspNetUserLogins(LoginProvider='{HttpUtility.UrlEncode(loginProvider.Trim().Replace("'", "''"))}',ProviderKey='{HttpUtility.UrlEncode(providerKey.Trim().Replace("'", "''"))}')");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);

            httpRequestMessage.Headers.Add("If-Match", aspNetUserLogin.ETag);

            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(aspNetUserLogin), Encoding.UTF8, "application/json");

            OnUpdateAspNetUserLogin(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnDeleteAspNetUserRole(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> DeleteAspNetUserRole(string userId = default(string), string roleId = default(string))
        {
            var uri = new Uri(baseUri, $"AspNetUserRoles(UserId='{HttpUtility.UrlEncode(userId.Trim().Replace("'", "''"))}',RoleId='{HttpUtility.UrlEncode(roleId.Trim().Replace("'", "''"))}')");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteAspNetUserRole(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnGetAspNetUserRoleByUserIdAndRoleId(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<VirtualLeague.Models.ConData.AspNetUserRole> GetAspNetUserRoleByUserIdAndRoleId(string userId = default(string), string roleId = default(string))
        {
            var uri = new Uri(baseUri, $"AspNetUserRoles(UserId='{HttpUtility.UrlEncode(userId.Trim().Replace("'", "''"))}',RoleId='{HttpUtility.UrlEncode(roleId.Trim().Replace("'", "''"))}')");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetAspNetUserRoleByUserIdAndRoleId(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<VirtualLeague.Models.ConData.AspNetUserRole>(response);
        }
        partial void OnUpdateAspNetUserRole(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> UpdateAspNetUserRole(string userId = default(string), string roleId = default(string), VirtualLeague.Models.ConData.AspNetUserRole aspNetUserRole = default(VirtualLeague.Models.ConData.AspNetUserRole))
        {
            var uri = new Uri(baseUri, $"AspNetUserRoles(UserId='{HttpUtility.UrlEncode(userId.Trim().Replace("'", "''"))}',RoleId='{HttpUtility.UrlEncode(roleId.Trim().Replace("'", "''"))}')");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);

            httpRequestMessage.Headers.Add("If-Match", aspNetUserRole.ETag);

            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(aspNetUserRole), Encoding.UTF8, "application/json");

            OnUpdateAspNetUserRole(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnDeleteAspNetUserToken(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> DeleteAspNetUserToken(string userId = default(string), string loginProvider = default(string), string name = default(string))
        {
            var uri = new Uri(baseUri, $"AspNetUserTokens(UserId='{HttpUtility.UrlEncode(userId.Trim().Replace("'", "''"))}',LoginProvider='{HttpUtility.UrlEncode(loginProvider.Trim().Replace("'", "''"))}',Name='{HttpUtility.UrlEncode(name.Trim().Replace("'", "''"))}')");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteAspNetUserToken(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnGetAspNetUserTokenByUserIdAndLoginProviderAndName(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<VirtualLeague.Models.ConData.AspNetUserToken> GetAspNetUserTokenByUserIdAndLoginProviderAndName(string userId = default(string), string loginProvider = default(string), string name = default(string))
        {
            var uri = new Uri(baseUri, $"AspNetUserTokens(UserId='{HttpUtility.UrlEncode(userId.Trim().Replace("'", "''"))}',LoginProvider='{HttpUtility.UrlEncode(loginProvider.Trim().Replace("'", "''"))}',Name='{HttpUtility.UrlEncode(name.Trim().Replace("'", "''"))}')");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetAspNetUserTokenByUserIdAndLoginProviderAndName(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<VirtualLeague.Models.ConData.AspNetUserToken>(response);
        }
        partial void OnUpdateAspNetUserToken(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> UpdateAspNetUserToken(string userId = default(string), string loginProvider = default(string), string name = default(string), VirtualLeague.Models.ConData.AspNetUserToken aspNetUserToken = default(VirtualLeague.Models.ConData.AspNetUserToken))
        {
            var uri = new Uri(baseUri, $"AspNetUserTokens(UserId='{HttpUtility.UrlEncode(userId.Trim().Replace("'", "''"))}',LoginProvider='{HttpUtility.UrlEncode(loginProvider.Trim().Replace("'", "''"))}',Name='{HttpUtility.UrlEncode(name.Trim().Replace("'", "''"))}')");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);

            httpRequestMessage.Headers.Add("If-Match", aspNetUserToken.ETag);

            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(aspNetUserToken), Encoding.UTF8, "application/json");

            OnUpdateAspNetUserToken(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnDeleteDeviceCode(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> DeleteDeviceCode(string userCode = default(string))
        {
            var uri = new Uri(baseUri, $"DeviceCodes('{HttpUtility.UrlEncode(userCode.Trim().Replace("'", "''"))}')");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteDeviceCode(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnGetDeviceCodeByUserCode(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<VirtualLeague.Models.ConData.DeviceCode> GetDeviceCodeByUserCode(string expand = default(string), string userCode = default(string))
        {
            var uri = new Uri(baseUri, $"DeviceCodes('{HttpUtility.UrlEncode(userCode.Trim().Replace("'", "''"))}')");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:null, top:null, skip:null, orderby:null, expand:expand, select:null, count:null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetDeviceCodeByUserCode(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<VirtualLeague.Models.ConData.DeviceCode>(response);
        }
        partial void OnUpdateDeviceCode(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> UpdateDeviceCode(string userCode = default(string), VirtualLeague.Models.ConData.DeviceCode deviceCode = default(VirtualLeague.Models.ConData.DeviceCode))
        {
            var uri = new Uri(baseUri, $"DeviceCodes('{HttpUtility.UrlEncode(userCode.Trim().Replace("'", "''"))}')");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);

            httpRequestMessage.Headers.Add("If-Match", deviceCode.ETag);

            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(deviceCode), Encoding.UTF8, "application/json");

            OnUpdateDeviceCode(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnDeleteFixtureTemplate(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> DeleteFixtureTemplate(int? templateId = default(int?))
        {
            var uri = new Uri(baseUri, $"FixtureTemplates({templateId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteFixtureTemplate(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnGetFixtureTemplateByTemplateId(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<VirtualLeague.Models.ConData.FixtureTemplate> GetFixtureTemplateByTemplateId(string expand = default(string), int? templateId = default(int?))
        {
            var uri = new Uri(baseUri, $"FixtureTemplates({templateId})");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:null, top:null, skip:null, orderby:null, expand:expand, select:null, count:null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetFixtureTemplateByTemplateId(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<VirtualLeague.Models.ConData.FixtureTemplate>(response);
        }
        partial void OnUpdateFixtureTemplate(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> UpdateFixtureTemplate(int? templateId = default(int?), VirtualLeague.Models.ConData.FixtureTemplate fixtureTemplate = default(VirtualLeague.Models.ConData.FixtureTemplate))
        {
            var uri = new Uri(baseUri, $"FixtureTemplates({templateId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);

            httpRequestMessage.Headers.Add("If-Match", fixtureTemplate.ETag);

            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(fixtureTemplate), Encoding.UTF8, "application/json");

            OnUpdateFixtureTemplate(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnDeleteKey(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> DeleteKey(string id = default(string))
        {
            var uri = new Uri(baseUri, $"Keys('{HttpUtility.UrlEncode(id.Trim().Replace("'", "''"))}')");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteKey(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnGetKeyById(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<VirtualLeague.Models.ConData.Key> GetKeyById(string expand = default(string), string id = default(string))
        {
            var uri = new Uri(baseUri, $"Keys('{HttpUtility.UrlEncode(id.Trim().Replace("'", "''"))}')");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:null, top:null, skip:null, orderby:null, expand:expand, select:null, count:null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetKeyById(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<VirtualLeague.Models.ConData.Key>(response);
        }
        partial void OnUpdateKey(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> UpdateKey(string id = default(string), VirtualLeague.Models.ConData.Key key = default(VirtualLeague.Models.ConData.Key))
        {
            var uri = new Uri(baseUri, $"Keys('{HttpUtility.UrlEncode(id.Trim().Replace("'", "''"))}')");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);

            httpRequestMessage.Headers.Add("If-Match", key.ETag);

            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(key), Encoding.UTF8, "application/json");

            OnUpdateKey(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnDeleteLeagueSeason(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> DeleteLeagueSeason(int? seasonId = default(int?))
        {
            var uri = new Uri(baseUri, $"LeagueSeasons({seasonId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteLeagueSeason(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnGetLeagueSeasonBySeasonId(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<VirtualLeague.Models.ConData.LeagueSeason> GetLeagueSeasonBySeasonId(string expand = default(string), int? seasonId = default(int?))
        {
            var uri = new Uri(baseUri, $"LeagueSeasons({seasonId})");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:null, top:null, skip:null, orderby:null, expand:expand, select:null, count:null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetLeagueSeasonBySeasonId(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<VirtualLeague.Models.ConData.LeagueSeason>(response);
        }
        partial void OnUpdateLeagueSeason(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> UpdateLeagueSeason(int? seasonId = default(int?), VirtualLeague.Models.ConData.LeagueSeason leagueSeason = default(VirtualLeague.Models.ConData.LeagueSeason))
        {
            var uri = new Uri(baseUri, $"LeagueSeasons({seasonId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);

            httpRequestMessage.Headers.Add("If-Match", leagueSeason.ETag);

            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(leagueSeason), Encoding.UTF8, "application/json");

            OnUpdateLeagueSeason(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnDeleteMatchDay(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> DeleteMatchDay(int? matchDayId = default(int?))
        {
            var uri = new Uri(baseUri, $"MatchDays({matchDayId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteMatchDay(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnGetMatchDayByMatchDayId(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<VirtualLeague.Models.ConData.MatchDay> GetMatchDayByMatchDayId(string expand = default(string), int? matchDayId = default(int?))
        {
            var uri = new Uri(baseUri, $"MatchDays({matchDayId})");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:null, top:null, skip:null, orderby:null, expand:expand, select:null, count:null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetMatchDayByMatchDayId(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<VirtualLeague.Models.ConData.MatchDay>(response);
        }
        partial void OnUpdateMatchDay(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> UpdateMatchDay(int? matchDayId = default(int?), VirtualLeague.Models.ConData.MatchDay matchDay = default(VirtualLeague.Models.ConData.MatchDay))
        {
            var uri = new Uri(baseUri, $"MatchDays({matchDayId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);

            httpRequestMessage.Headers.Add("If-Match", matchDay.ETag);

            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(matchDay), Encoding.UTF8, "application/json");

            OnUpdateMatchDay(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnDeletePersistedGrant(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> DeletePersistedGrant(string key = default(string))
        {
            var uri = new Uri(baseUri, $"PersistedGrants('{HttpUtility.UrlEncode(key.Trim().Replace("'", "''"))}')");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeletePersistedGrant(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnGetPersistedGrantByKey(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<VirtualLeague.Models.ConData.PersistedGrant> GetPersistedGrantByKey(string expand = default(string), string key = default(string))
        {
            var uri = new Uri(baseUri, $"PersistedGrants('{HttpUtility.UrlEncode(key.Trim().Replace("'", "''"))}')");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:null, top:null, skip:null, orderby:null, expand:expand, select:null, count:null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetPersistedGrantByKey(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<VirtualLeague.Models.ConData.PersistedGrant>(response);
        }
        partial void OnUpdatePersistedGrant(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> UpdatePersistedGrant(string key = default(string), VirtualLeague.Models.ConData.PersistedGrant persistedGrant = default(VirtualLeague.Models.ConData.PersistedGrant))
        {
            var uri = new Uri(baseUri, $"PersistedGrants('{HttpUtility.UrlEncode(key.Trim().Replace("'", "''"))}')");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);

            httpRequestMessage.Headers.Add("If-Match", persistedGrant.ETag);

            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(persistedGrant), Encoding.UTF8, "application/json");

            OnUpdatePersistedGrant(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnDeleteSeasonFixture(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> DeleteSeasonFixture(Int64? fixtureId = default(Int64?))
        {
            var uri = new Uri(baseUri, $"SeasonFixtures({fixtureId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteSeasonFixture(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnGetSeasonFixtureByFixtureId(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<VirtualLeague.Models.ConData.SeasonFixture> GetSeasonFixtureByFixtureId(string expand = default(string), Int64? fixtureId = default(Int64?))
        {
            var uri = new Uri(baseUri, $"SeasonFixtures({fixtureId})");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:null, top:null, skip:null, orderby:null, expand:expand, select:null, count:null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetSeasonFixtureByFixtureId(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<VirtualLeague.Models.ConData.SeasonFixture>(response);
        }
        partial void OnUpdateSeasonFixture(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> UpdateSeasonFixture(Int64? fixtureId = default(Int64?), VirtualLeague.Models.ConData.SeasonFixture seasonFixture = default(VirtualLeague.Models.ConData.SeasonFixture))
        {
            var uri = new Uri(baseUri, $"SeasonFixtures({fixtureId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);

            httpRequestMessage.Headers.Add("If-Match", seasonFixture.ETag);

            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(seasonFixture), Encoding.UTF8, "application/json");

            OnUpdateSeasonFixture(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnDeleteTeam(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> DeleteTeam(int? teamId = default(int?))
        {
            var uri = new Uri(baseUri, $"Teams({teamId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteTeam(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnGetTeamByTeamId(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<VirtualLeague.Models.ConData.Team> GetTeamByTeamId(string expand = default(string), int? teamId = default(int?))
        {
            var uri = new Uri(baseUri, $"Teams({teamId})");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:null, top:null, skip:null, orderby:null, expand:expand, select:null, count:null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetTeamByTeamId(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<VirtualLeague.Models.ConData.Team>(response);
        }
        partial void OnUpdateTeam(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> UpdateTeam(int? teamId = default(int?), VirtualLeague.Models.ConData.Team team = default(VirtualLeague.Models.ConData.Team))
        {
            var uri = new Uri(baseUri, $"Teams({teamId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);

            httpRequestMessage.Headers.Add("If-Match", team.ETag);

            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(team), Encoding.UTF8, "application/json");

            OnUpdateTeam(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnDeleteVirtualLeagueResult(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> DeleteVirtualLeagueResult(Int64? recordId = default(Int64?))
        {
            var uri = new Uri(baseUri, $"VirtualLeagueResults({recordId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

            OnDeleteVirtualLeagueResult(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }
        partial void OnGetVirtualLeagueResultByRecordId(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<VirtualLeague.Models.ConData.VirtualLeagueResult> GetVirtualLeagueResultByRecordId(string expand = default(string), Int64? recordId = default(Int64?))
        {
            var uri = new Uri(baseUri, $"VirtualLeagueResults({recordId})");
            uri = Radzen.ODataExtensions.GetODataUri(uri: uri, filter:null, top:null, skip:null, orderby:null, expand:expand, select:null, count:null);

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

            OnGetVirtualLeagueResultByRecordId(httpRequestMessage);

            var response = await httpClient.SendAsync(httpRequestMessage);

            return await Radzen.HttpResponseMessageExtensions.ReadAsync<VirtualLeague.Models.ConData.VirtualLeagueResult>(response);
        }
        partial void OnUpdateVirtualLeagueResult(HttpRequestMessage requestMessage);


        public async System.Threading.Tasks.Task<HttpResponseMessage> UpdateVirtualLeagueResult(Int64? recordId = default(Int64?), VirtualLeague.Models.ConData.VirtualLeagueResult virtualLeagueResult = default(VirtualLeague.Models.ConData.VirtualLeagueResult))
        {
            var uri = new Uri(baseUri, $"VirtualLeagueResults({recordId})");

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Patch, uri);

            httpRequestMessage.Headers.Add("If-Match", virtualLeagueResult.ETag);

            httpRequestMessage.Content = new StringContent(Radzen.ODataJsonSerializer.Serialize(virtualLeagueResult), Encoding.UTF8, "application/json");

            OnUpdateVirtualLeagueResult(httpRequestMessage);

            return await httpClient.SendAsync(httpRequestMessage);
        }
    }
}
