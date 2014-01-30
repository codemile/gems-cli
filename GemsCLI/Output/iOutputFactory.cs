namespace GemsCLI.Output
{
    public interface iOutputFactory
    {
        /// <summary>
        /// Creates an output handler object.
        /// </summary>
        /// <returns>The new object.</returns>
        iOutputStream Create();
    }
}