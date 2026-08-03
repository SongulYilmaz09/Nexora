using MediatR;

namespace Nexora.Application.Features.Tasks.Delete;

public record DeleteTaskCommand(Guid Id) : IRequest;