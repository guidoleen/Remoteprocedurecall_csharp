using System;

namespace ClientListenerLibrary
{
	public interface IServerActionHandler
	{
		object GetActionResult();
	}
}

