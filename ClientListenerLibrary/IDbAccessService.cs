using System;
using System.Collections.Generic;

namespace ClientListenerLibrary
{
	public interface IDbAccessService<Entity>
	{
		List<Entity> Read();
		void Create();
		void Update();
		void Delete();
	}
}

