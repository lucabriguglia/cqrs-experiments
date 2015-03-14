using Autofac;
using System;
using System.Threading.Tasks;
using Weapsy.Blog.Bus.Contracts;
using Weapsy.Blog.Commands.Contracts;
using Weapsy.Blog.Commands.Handlers.Contracts;

namespace Weapsy.Blog.Bus
{
	public class CommandSender : ICommandSender
	{
		private readonly IComponentContext _context;

		public CommandSender(IContainer context)
		{
			_context = context;
		}

		public void Send<TCommand>(TCommand command) where TCommand : ICommand
		{
			if (command == null)
			{
				throw new ArgumentNullException("command");
			}

			var commandHandler = _context.Resolve<ICommandHandler<TCommand>>();

			if (commandHandler == null)
			{
				throw new Exception(string.Format("No handlers found for command '{0}'", command.GetType().FullName));
			}

			commandHandler.Handle(command);
        }

		public Task SendAsync<TCommand>(TCommand command) where TCommand : ICommand
		{
			return new TaskFactory().StartNew(() => Send(command));
		}
	}
}
