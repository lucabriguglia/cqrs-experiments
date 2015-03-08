using System.Threading.Tasks;
using Weapsy.Blog.Commands.Contracts;

namespace Weapsy.Blog.Bus.Contracts
{
	public interface ICommandSender<T> where T : ICommand
	{
		void Send(T command);
		Task SendAsync(T command);
	}
}
