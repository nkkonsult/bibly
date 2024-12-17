namespace Bibly.Application.Common.Behaviors;
public class ExceptionBehavior<TRequest, TResponse>
    : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
{
    public ExceptionBehavior()
    {

    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        try
        {
            // log tout est OK
            return await next();
        }
        catch (Exception ex)
        {
            // log error
            throw;
        }
    }
}
