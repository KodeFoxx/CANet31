using MediatR.Pipeline;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace Kf.CANet31.Core.Application.Behaviors
{
    public sealed class LogStartRequestBehavior<TRequest>
        : LogRequestBehavior<TRequest>, IRequestPreProcessor<TRequest>
    {
        public LogStartRequestBehavior(ILogger<TRequest> logger)
            : base(logger)
        { }

        public Task Process(
            TRequest request,
            CancellationToken cancellationToken
        )
            => LogBehaviorForRequest(BehaviorNames.StartRequest);
    }
}
