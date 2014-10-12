namespace GemsCLI.Output
{
    public class ConsoleFactory : iOutputFactory
    {
        /// <summary>
        /// Creates an output handler object.
        /// </summary>
        /// <returns>The new object.</returns>
        public iOutputStream Create()
        {
#if __MonoCS__
			return new ConsoleStream();
#else
			#if DEBUG
			return new DebugStream();
			#else
			return new ConsoleStream();
			#endif
#endif
        }
    }
}