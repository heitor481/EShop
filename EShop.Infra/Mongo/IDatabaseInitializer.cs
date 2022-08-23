using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Infra.Mongo
{
	public interface IDatabaseInitializer
	{
		Task Initialize();
	}
}
