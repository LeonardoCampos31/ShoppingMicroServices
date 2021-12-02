using Shopping.Web.Models;
using Shopping.Web.Models.Product;

namespace Shopping.Web.Services.Interfaces
{
    public interface IBaseService : IDisposable
    {
        ResponseDto responseModel { get; set; }
        Task<T> SendAsync<T>(ApiRequest apiRequest);
    }
}
