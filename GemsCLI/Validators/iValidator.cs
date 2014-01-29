using System.Collections.Generic;
using GemsCLI.Descriptions;

namespace GemsCLI.Validators
{
    public interface iValidator
    {
        /// <summary>
        /// Performs a validation check on the current request.
        /// </summary>
        /// <param name="pDescs">Collection of description.</param>
        /// <param name="pRequest">Request object containing parameters.</param>
        /// <returns>True if parameter pass validation.</returns>
        bool Validate(ICollection<Description> pDescs, Request pRequest);
    }
}