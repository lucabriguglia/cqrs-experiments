using System;
using System.Collections.Generic;

namespace Weapsy.Blog.Domain
{
	public static class DomainEvents
	{
		[ThreadStatic]
		private static List<Delegate> _actions;
		private static List<Delegate> Actions
		{
			get
			{
				if (_actions == null)
				{
					_actions = new List<Delegate>();
				}
				return _actions;
			}
		}

		public static IDisposable Register<T>(Action<T> callback)
		{
			Actions.Add(callback);
			return new DomainEventRegistrationRemover(() => Actions.Remove(callback));
		}

		public static void Raise<T>(T eventArgs)
		{
			try
			{
				//IEnumerable<IEventHandler<T>> registeredHandlers = ServiceLocator.Current.GetAllInstances<IEventHandler<T>>();
				//foreach (IEventHandler<T> handler in registeredHandlers)
				//{
				//	handler.Handle(eventArgs);
				//}
			}
			catch (NullReferenceException)
			{
				//When service locator is not set, ignore it.
			}

			foreach (var action in Actions)
			{
				var typedAction = action as Action<T>;
				if (typedAction != null)
				{
					typedAction(eventArgs);
				}
			}
		}

		private sealed class DomainEventRegistrationRemover : IDisposable
		{
			private readonly Action _callOnDispose;

			public DomainEventRegistrationRemover(Action toCall)
			{
				_callOnDispose = toCall;
			}

			public void Dispose()
			{
				_callOnDispose();
			}
		}
	}
}
