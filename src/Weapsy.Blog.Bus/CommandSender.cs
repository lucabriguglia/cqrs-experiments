using System;
using System.Threading.Tasks;
using Weapsy.Blog.Bus.Contracts;
using Weapsy.Blog.Commands.Contracts;

namespace Weapsy.Blog.Bus
{
	public class CommandSender : ICommandSender<ICommand>
	{
		public void Send(ICommand command)
		{
			throw new NotImplementedException();
		}

		public Task SendAsync(ICommand command)
		{
			return new TaskFactory().StartNew(() => Send(command));
		}
	}
}
