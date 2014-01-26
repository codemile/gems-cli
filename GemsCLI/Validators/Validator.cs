using System.Collections.Generic;
using System.Linq;
using GemsCLI.Descriptions;
using GemsCLI.Enums;
using GemsCLI.Output;

namespace GemsCLI.Validators
{
    public class Validator : iValidator
    {
        private readonly iOutputHandler _handler;

        /// <summary>
        /// Selects all the descriptions of parameters that are
        /// required but missing from the request.
        /// </summary>
        /// <returns>Collection of missing required descriptions.</returns>
        private static IEnumerable<Description> MissingRequired(IEnumerable<Description> pList, Request pRequest)
        {
            return from desc in pList
                   where
                       desc.Role == eROLE.NAMED &&
                       desc.Scope == eSCOPE.REQUIRED &&
                       !pRequest.Contains(desc.Name)
                   select desc;
        }

        /// <summary>
        /// Calls the error handler for each description in the collection.
        /// </summary>
        /// <param name="pHandler">Error handler to call.</param>
        /// <param name="pDescs">Collection of parameter descriptions.</param>
        /// <param name="pError">Type of error being reported.</param>
        /// <returns>True if any errors reported.</returns>
        private static bool Report(iOutputHandler pHandler, IEnumerable<Description> pDescs, eERROR pError)
        {
            bool result = false;
            foreach (Description desc in pDescs)
            {
                pHandler.Error(desc, pError);
                result = true;
            }
            return result;
        }

        /// <summary>
        /// Selects all the descriptions of parameters that are
        /// found multiple times, but are marked as single occurrence parameters.
        /// </summary>
        /// <param name="pList">Collection of parameter descriptions.</param>
        /// <param name="pRequest">Requested parameters to validate.</param>
        /// <returns>Collection of descriptions for duplicated parameters.</returns>
        private static IEnumerable<Description> SelectDuplicates(IEnumerable<Description> pList, Request pRequest)
        {
            return from desc in pList
                   where
                       desc.Role == eROLE.NAMED &&
                       desc.Multiplicity == eMULTIPLICITY.ONCE &&
                       pRequest.Count(desc.Name) > 1
                   select desc;
        }

        /// <summary>
        /// Initializes this class with an error handler.
        /// </summary>
        /// <param name="pHandler">Handles errors found in parameters.</param>
        public Validator(iOutputHandler pHandler)
        {
            _handler = pHandler;
        }

        /// <summary>
        /// Performs a validation check on the current request.
        /// </summary>
        /// <param name="pList">Collection of description.</param>
        /// <param name="pRequest">Request object containing parameters.</param>
        /// <returns>True if parameter pass validation.</returns>
        public bool Validate(ICollection<Description> pList, Request pRequest)
        {
            if (_handler == null)
            {
                return true;
            }
            bool result = !Report(_handler, MissingRequired(pList, pRequest), eERROR.REQUIRED);
            result &= !Report(_handler, SelectDuplicates(pList, pRequest), eERROR.DUPLICATE);
            return result;
        }
    }
}