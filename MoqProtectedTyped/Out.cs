using System;
using System.Collections.Generic;
using System.Text;

namespace MoqProtectedTyped
{
	public class Out {
		public static Out<T> From<T>(T t)
		{
			return new Out<T> { Value = t };
		}
	}

	public class Out<T>
	{
		internal Out() { }
		public T Value { get; set; }
	}
}
