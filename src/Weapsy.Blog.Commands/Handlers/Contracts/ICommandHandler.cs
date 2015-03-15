using Weapsy.Blog.Commands.Contracts;

namespace Weapsy.Blog.Commands.Handlers.Contracts
{
	public interface ICommandHandler<in TCommand> where TCommand : ICommand
	{
		void Handle(TCommand command);
	}
}