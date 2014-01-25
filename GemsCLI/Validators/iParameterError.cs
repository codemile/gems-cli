using GemsCLI.Arguments;
using GemsCLI.Enums;

namespace GemsCLI.Validators
{
    public interface iParameterError
    {
        /// <summary>
        /// Called when a validation fails on the parameters.
        /// </summary>
        /// <param name="pDesc">The description of the failed parameter.</param>
        /// <param name="pError">The type of error.</param>
        void Error(Description pDesc, eERROR pError);
    }
}