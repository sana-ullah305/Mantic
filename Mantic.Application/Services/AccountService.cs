using Mantic.Application.DTOs.Request.Account;
using Mantic.Application.DTOs.Response.Account;
using Mantic.Application.DTOs.Response;
using Mantic.Application.Extensions;
using System.Net.Http.Json;

namespace Mantic.Application.Services
{
    public class AccountService(HttpClientService httpClientService) : IAccountService
    {
        public async Task CreateAdmin()
        {
            try
            {
                var client = httpClientService.GetPublicClient();
                await client.PostAsync(Constant.CreateAdminRoute, null);
            }
            catch (Exception e)
            {

            }
        }

        public async Task<GeneralResponse> CreateAccountAsync(CreateAccountDTO model)
        {
            try
            {
                var publicClient = httpClientService.GetPublicClient();
                var response = await publicClient.PostAsJsonAsync(Constant.RegisterRoute, model);
                string error = CheckResponseStatus(response);
                if (!string.IsNullOrEmpty(error))
                    return new GeneralResponse(Flag: false, Message: error);
                var result = await response.Content.ReadFromJsonAsync<GeneralResponse>();
                return result!;

            }
            catch (Exception ex)
            {
                return new GeneralResponse(Flag: false, Message: ex.Message);
            }
        }

        public async Task<LoginResponse> LoginAccountAsync(LoginDTO model)
        {
            try
            {
                //Making an HTTP POST request to a public endpoint
                var publicClient = httpClientService.GetPublicClient();

                //The request is sent to the Constant.LoginRoute URL with the model data serialized as JSON.
                var response = await publicClient.PostAsJsonAsync(Constant.LoginRoute, model);
                string error = CheckResponseStatus(response);
                if (!string.IsNullOrEmpty(error))
                    return new LoginResponse(false, error);

                //An asynchronous method that reads the content and deserializes it into a LoginResponse object.
                var result = await response.Content.ReadFromJsonAsync<LoginResponse>();
                return result;
            }
            catch (Exception e)
            {
                return new LoginResponse(false, e.Message);
            }
        }

        public async Task<LoginResponse> RefreshTokenAsync(RefreshTokenDTO model)
        {


            try
            {
                var publicClient = httpClientService.GetPublicClient();
                var response = await publicClient.PostAsJsonAsync(Constant.RefreshTokenRoute, model);
                string error = CheckResponseStatus(response);
                if (!string.IsNullOrEmpty(error))
                    return new LoginResponse(false, error);
                var result = await response.Content.ReadFromJsonAsync<LoginResponse>();
                return result!;
            }
            catch (Exception ex)
            {
                return new LoginResponse(false, ex.Message);
            }


        }

        private static string CheckResponseStatus(HttpResponseMessage response)
        {
            if (!response.IsSuccessStatusCode)
                return
                    $"Sorry unknown error occured.{Environment.NewLine} Error Description:{Environment.NewLine} Status Code: .{response.StatusCode} .{Environment.NewLine} Reason Phrase: .{response.ReasonPhrase}";
            else
                return null;
        }






        public async Task<IEnumerable<GetRoleDTO>> GetRolesAsync()
        {
            try
            {
                var privateClient = await httpClientService.GetPrivateClient();
                var response = await privateClient.GetAsync(Constant.GetRolesRoute);
                string error = CheckResponseStatus(response);
                if (!string.IsNullOrEmpty(error))
                    throw new Exception(error);
                var result = await response.Content.ReadFromJsonAsync<IEnumerable<GetRoleDTO>>();
                return result!;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }



        public async Task<IEnumerable<GetUsersWithRolesResponseDTO>> GetUsersWithRolesAsync()
        {
            try
            {
                //The request is private and the token is added to the header 
                var privateClient = await httpClientService.GetPrivateClient();
                var response = await privateClient.GetAsync(Constant.GetUserWithRolesRoute);
                string error = CheckResponseStatus(response);
                if (!string.IsNullOrEmpty(error))
                    throw new Exception(error);
                var result = await response.Content.ReadFromJsonAsync<IEnumerable<GetUsersWithRolesResponseDTO>>();
                return result!;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<GeneralResponse> ChangeUserRoleAsync(ChangeUserRoleRequestDTO model)
        {


            try
            {
                var privateClient = await httpClientService.GetPrivateClient();
                var response = await privateClient.PostAsJsonAsync(Constant.ChangeUserRoleRoute, model);
                string error = CheckResponseStatus(response);
                if (!string.IsNullOrEmpty(error))
                    return new GeneralResponse(false, error);
                var result = await response.Content.ReadFromJsonAsync<GeneralResponse>();
                return result!;

            }
            catch (Exception ex)
            {
                return new GeneralResponse(false, ex.Message);
            }
        }
    }
}
