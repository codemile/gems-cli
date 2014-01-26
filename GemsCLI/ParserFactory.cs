using System.Collections.Generic;
using GemsCLI.Descriptions;
using GemsCLI.Output;
using GemsCLI.Validators;

namespace GemsCLI
{
    public static class ParserFactory
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pArgs"></param>
        /// <param name="pDescs"></param>
        /// <returns></returns>
        public static Parser Create(IEnumerable<string> pArgs, List<Description> pDescs)
        {
            return Create(ParserOptions.WindowsStyle, pArgs, pDescs);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pOptions"></param>
        /// <param name="pArgs"></param>
        /// <param name="pDescs"></param>
        /// <returns></returns>
        public static Parser Create(ParserOptions pOptions, IEnumerable<string> pArgs, List<Description> pDescs)
        {
            return Create(pOptions, new Validator(new ConsoleOutput(pOptions)), pArgs, pDescs);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pOptions"></param>
        /// <param name="pValidator"></param>
        /// <param name="pArgs"></param>
        /// <param name="pDescs"></param>
        /// <returns></returns>
        public static Parser Create(ParserOptions pOptions, iValidator pValidator, IEnumerable<string> pArgs,
                                    List<Description> pDescs)
        {
            Parser parser = new Parser(pOptions, pDescs, pArgs);
            if (pValidator != null)
            {
                pValidator.Validate(pDescs, parser.Request);
            }
            return parser;
        }
    }
}