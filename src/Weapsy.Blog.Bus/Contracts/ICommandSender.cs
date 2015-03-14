using System.Threading.Tasks;
using Weapsy.Blog.Commands.Contracts;

namespace Weapsy.Blog.Bus.Contracts
{
	public interface ICommandSender
	{
		void Send<TCommand>(TCommand command) where TCommand : ICommand;
		Task SendAsync<TCommand>(TCommand command) where TCommand : ICommand;
	}
}
