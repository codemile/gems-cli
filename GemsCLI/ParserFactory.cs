using System.Collections.Generic;
using GemsCLI.Descriptions;
using GemsCLI.Validators;

namespace GemsCLI
{
    public static class ParserFactory
    {
        public static Parser Create(IEnumerable<string> pArgs, DescriptionList pDescs)
        {
            return Create(ParserOptions.WindowsStyle, pArgs, pDescs);
        }

        public static Parser Create(ParserOptions pOptions, IEnumerable<string> pArgs, DescriptionList pDescs)
        {
            return Create(pOptions, new Validator(new ConsoleHandler(pOptions)), pArgs, pDescs);
        }

        public static Parser Create(ParserOptions pOptions, iValidator pValidator, IEnumerable<string> pArgs,
                                    DescriptionList pDescs)
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