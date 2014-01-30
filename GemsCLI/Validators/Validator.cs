using System.Collections.Generic;
using System.Linq;
using GemsCLI.Arguments;
using GemsCLI.Descriptions;
using GemsCLI.Enums;
using GemsCLI.Output;

namespace GemsCLI.Validators
{
    public class Validator : iValidator
    {
        /// <summary>
        /// Provides handling of the console output.
        /// </summary>
        private readonly OutputMessages _messages;

        /// <summary>
        /// Selects all the descriptions of parameters that are
        /// required but missing from the request.
        /// </summary>
        /// <returns>Collection of missing required descriptions.</returns>
        public static IEnumerable<Description> MissingRequired(IEnumerable<Description> pList, Request pRequest)
        {
            return from desc in pList
                   where
                       desc.Scope == eSCOPE.REQUIRED &&
                       !pRequest.Contains(desc.Name)
                   select desc;
        }

        /// <summary>
        /// Prints an error message that relates to the description.
        /// </summary>
        /// <param name="pDescs">Collection of parameter descriptions.</param>
        /// <param name="pError">Type of error being reported.</param>
        /// <returns>True if any errors reported.</returns>
        private bool Report(IEnumerable<Description> pDescs, eERROR pError)
        {
            bool result = false;
            foreach (Description desc in pDescs)
            {
                _messages.Error(desc, pError);
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
        public static IEnumerable<Description> SelectDuplicates(IEnumerable<Description> pList, Request pRequest)
        {
            return from desc in pList
                   where
                       desc.Role == eROLE.NAMED &&
                       desc.Multiplicity == eMULTIPLICITY.ONCE &&
                       pRequest.Count(desc.Name) > 1
                   select desc;
        }

        /// <summary>
        /// Selects all the descriptions of arguments the require a value, the request contains that
        /// named parameter but no value was provided.
        /// </summary>
        /// <param name="pDescs"></param>
        /// <param name="pRequest"></param>
        /// <returns></returns>
        public static IEnumerable<Description> SelectMissingValue(IEnumerable<Description> pDescs, Request pRequest)
        {
            // There are two kinds of missing values.
            // A named without a value, and a passed that was omitted. 

            IEnumerable<Description> missingNamed = from named in pRequest.Named()
                                                    where named.Desc != null &&
                                                          named.Desc.Type != null &&
                                                          named.Value == null
                                                    select named.Desc;

            IEnumerable<Description> missingPassed = from desc in pDescs
                                                     where desc.Role == eROLE.PASSED &&
                                                           !pRequest.Contains(desc.Name)
                                                     select desc;

            return missingNamed.Union(missingPassed);
        }

        /// <summary>
        /// Initializes this class with an error handler.
        /// </summary>
        /// <param name="pMessages">Handles errors found in parameters.</param>
        public Validator(OutputMessages pMessages)
        {
            _messages = pMessages;
        }

        /// <summary>
        /// Performs a validation check on the current request.
        /// </summary>
        /// <param name="pDescs">Collection of description.</param>
        /// <param name="pRequest">Request object containing parameters.</param>
        /// <returns>True if parameter pass validation.</returns>
        public bool Validate(ICollection<Description> pDescs, Request pRequest)
        {
            if (_messages == null)
            {
                return true;
            }

            bool result = !Report(MissingRequired(pDescs, pRequest), eERROR.REQUIRED);
            result &= !Report(SelectDuplicates(pDescs, pRequest), eERROR.DUPLICATE);
            result &= !Report(SelectMissingValue(pDescs, pRequest), eERROR.MISSING_VALUE);

            // check for arguments on the command line that have no matching description
            foreach (Argument unknown in from arg in pRequest where arg.Desc == null select arg)
            {
                _messages.Unknown(unknown);
                result = false;
            }

            return result;
        }
    }
}