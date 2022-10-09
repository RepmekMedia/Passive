using JSLibrary.AuthenticationHandlers.Credentials.Interfaces;
using JSLibrary.AuthenticationHandlers.Responses.Interfaces;

namespace PassiveAPI.Managements.Interfaces
{
    public interface ITokenManagement
    {
        Task<bool> ValidateAsync(IClientCredentials clientCredentials, CancellationToken cancellationToken = default);

        Task<ITokenResponse> GenerateAsync(IClientCredentials userLogin, CancellationToken cancellationToken = default);
    }
}
