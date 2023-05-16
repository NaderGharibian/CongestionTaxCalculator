using System.Threading;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IHandlerUseCase<in TRequest ,  TResponse>  
        where TRequest : class, new()
        where TResponse : class, new()
    {
        /// <summary>
        /// Handles a request
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Response from the request</returns>
        Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken = default);
    }
 
    public interface IHandlerUseCase<T>
      where T: class
    {
        Task<T> Handle(CancellationToken cancellationToken = default);
    }
    public interface IHandlerUseCase
    {
        Task Handle(CancellationToken cancellationToken = default);
    }




}
