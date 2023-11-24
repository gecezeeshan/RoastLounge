using Application.Common.Interfaces;
using FluentValidation;
using MediatR;
using MediatR.Pipeline;
using Microsoft.Extensions.Logging;

namespace Application.Common.Behaviours
{
    public class LoggingBehaviour<TRequest, TResponse> : IRequestPreProcessor<TRequest> where TRequest : notnull
    {
        public readonly ILogger _logger;
        public readonly ICurrentUserService _currentUserService;

        public LoggingBehaviour(ILogger<TRequest> logger,ICurrentUserService currentUserService)
        {
            _logger = logger;
            _currentUserService= currentUserService;
        }

        public async Task Process(TRequest request, CancellationToken cancellationToken)
        {
            var requestName = typeof(TRequest).Name;

            var userId = _currentUserService.UserId ?? string.Empty;
            var userName = _currentUserService.UserName ?? string.Empty;

            await Task.Run(() =>
            {
                    _logger.LogInformation("Resturant Request: {Name} {@UserId} {@UserName} {@Request}",
                     requestName, userId, userName, request);

            });
        }
    }

}