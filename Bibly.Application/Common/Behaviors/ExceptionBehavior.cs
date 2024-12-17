
using System.Reflection.Metadata.Ecma335;

namespace Bibly.Application.Common.Behaviors;

public class ExceptionBehavior<TRequest,TResponse> 
    : IPipelineBehavior<TRequest, TResponse> where TRequest: IRequest<TResponse> 
{
    public ExceptionBehavior()
    {        
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        try
        {
            return await next();
            
        }
        catch (Exception ex)
        {

            throw;
        }
    }
}
