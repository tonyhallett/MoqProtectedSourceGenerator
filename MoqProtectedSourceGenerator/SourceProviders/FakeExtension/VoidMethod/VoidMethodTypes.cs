using System;

namespace MoqProtectedSourceGenerator
{
    public class VoidMethodTypes
    {
        public const string VoidMethodInterface = @"
    public interface IVoidMethod<T> where T : class
	{
		ISetup<T> Setup();
		void Verify(Times? times = null, string failMessage = null);
	}
";

        public const string VoidMethodBuilderInterface = @"
    public interface IVoidMethodBuilder<T> where T : class
	{
		IVoidMethod<T> Build([System.Runtime.CompilerServices.CallerFilePath] string sourceFilePath = """",
		[System.Runtime.CompilerServices.CallerLineNumber] int sourceLineNumber = 0);
	}
";
        public const string VoidMethodBuilder = @"

	public class VoidMethodBuilder<T> : IVoidMethodBuilder<T>, IVoidMethod<T> where T : class
	{
		private readonly Func<string, int, ISetup<T>> setup;
		private readonly Action<string, int, Times?, string> verify;
		private string sourceFilePath;
		private int sourceLineNumber;


		public VoidMethodBuilder(Func<string, int, ISetup<T>> setup, Action<string, int, Times?, string> verify)
		{
			this.setup = setup;
			this.verify = verify;
		}
		public IVoidMethod<T> Build([System.Runtime.CompilerServices.CallerFilePath] string sourceFilePath = """",
		[System.Runtime.CompilerServices.CallerLineNumber] int sourceLineNumber = 0)
		{
			this.sourceFilePath = sourceFilePath;
			this.sourceLineNumber = sourceLineNumber;
			return this;
		}

		public ISetup<T> Setup()
		{
			return this.setup(sourceFilePath, sourceLineNumber);
		}

		public void Verify(Times? times = null, string failMessage = null)
		{
			this.verify(sourceFilePath, sourceLineNumber, times, failMessage);
		}
	}
";
        public static string Get()
        {
            return VoidMethodInterface + Environment.NewLine + VoidMethodBuilderInterface + Environment.NewLine + VoidMethodBuilder;
        }

    }
}
