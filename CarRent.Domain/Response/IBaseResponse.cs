using CarRent.Domain.Enum;

namespace CarRent.Domain.Response;

public interface IBaseResponse<T>
{
    string Description { get; }
    StatusCode StatusCode { get; }
    T Data { get; }
}
