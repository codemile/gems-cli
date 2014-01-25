namespace GemsCLI.Types
{
    public class ParamInt : iParamType
    {
        /// <summary>
        /// Default value
        /// </summary>
        private readonly int _default;

        /// <summary>
        /// Max value range
        /// </summary>
        private readonly int _max;

        /// <summary>
        /// Min value range
        /// </summary>
        private readonly int _min;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="pDefault">The default value</param>
        public ParamInt(int pDefault = 0)
            : this(int.MinValue, int.MaxValue, pDefault)
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="pMin">The min value</param>
        /// <param name="pMax">The max value</param>
        /// <param name="pDefault">The default value</param>
        public ParamInt(int pMin, int pMax, int pDefault = 0)
        {
            _min = pMin;
            _max = pMax;
            _default = pDefault;
        }
    }
}