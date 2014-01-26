using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using GemsCLI.Arguments;
using GemsCLI.Descriptions;
using GemsCLI.Help;
using GemsCLI.Output;
using GemsCLI.Validators;

namespace GemsCLI
{
    public static class RequestFactory
    {
        /// <summary>
        /// Creates descriptions of parameters from the public property members of an
        /// object.
        /// </summary>
        /// <typeparam name="T">The object type to inspect.</typeparam>
        /// <param name="pOptions">The parser option</param>
        /// <param name="pInfos">Collection of properties</param>
        /// <returns>Parameter descriptions in syntax format.</returns>
        private static string ReflectDescriptions<T>(CLIOptions pOptions, IEnumerable<PropertyInfo> pInfos)
            where T : class, new()
        {
            List<string> desc = new List<string>();
            foreach (PropertyInfo info in pInfos)
            {
                desc.Add(
                    string.Format(
                        "{0}{1}:{2}",
                        pOptions.Prefix,
                        info.Name.ToLower(),
                        info.PropertyType.Name.ToLower()
                        ));
            }
            return string.Join(" ", desc);
        }

        private static PropertyInfo ReflectProperty(IEnumerable<PropertyInfo> pInfos, string pName)
        {
            return pInfos.FirstOrDefault(pInfo=>pInfo.Name.ToLower() == pName);
        }

        /// <summary>
        /// An easy factory method that uses an object's properties to
        /// define the command line arguments required for the application.
        /// </summary>
        /// <typeparam name="T">The object class to initialize.</typeparam>
        /// <param name="pOptions">The parser options</param>
        /// <param name="pArgs">The command line arguments.</param>
        /// <returns>A new class T with it's properties populated.</returns>
        public static T Create<T>(CLIOptions pOptions, IEnumerable<string> pArgs) where T : class, new()
        {
            PropertyInfo[] infos = typeof (T).GetProperties();
            string pattern = ReflectDescriptions<T>(pOptions, infos);
            List<Description> descs = DescriptionFactory.Create(pOptions, new HelpReflection(typeof (T)), pattern);
            Request request = Create(pArgs, descs);

            T instance = Activator.CreateInstance<T>();

            foreach (Description desc in descs)
            {
                PropertyInfo info = ReflectProperty(infos, desc.Name);
                if (!request.Contains(desc.Name) || info == null)
                {
                    continue;
                }
                // TODO: Support multiples
                info.SetValue(instance, Convert.ChangeType(request[desc.Name][0].Value, info.PropertyType));
            }

            return instance;
        }

        /// <summary>
        /// </summary>
        /// <param name="pArgs"></param>
        /// <param name="pDescs"></param>
        /// <returns></returns>
        public static Request Create(IEnumerable<string> pArgs, List<Description> pDescs)
        {
            return Create(CLIOptions.WindowsStyle, pArgs, pDescs);
        }

        /// <summary>
        /// </summary>
        /// <param name="pOptions"></param>
        /// <param name="pArgs"></param>
        /// <param name="pDescs"></param>
        /// <returns></returns>
        public static Request Create(CLIOptions pOptions, IEnumerable<string> pArgs, List<Description> pDescs)
        {
            return Create(pOptions, new Validator(new ConsoleOutput(pOptions)), pArgs, pDescs);
        }

        /// <summary>
        /// </summary>
        /// <param name="pOptions"></param>
        /// <param name="pValidator"></param>
        /// <param name="pArgs"></param>
        /// <param name="pDescs"></param>
        /// <returns></returns>
        public static Request Create(CLIOptions pOptions, iValidator pValidator, IEnumerable<string> pArgs,
                                     List<Description> pDescs)
        {
            IEnumerable<Argument> arguments = ArgumentFactory.Create(pOptions.Prefix, pOptions.EqualChar, pArgs);
            Request request = new Request(arguments);
            if (pValidator != null)
            {
                pValidator.Validate(pDescs, request);
            }
            return request;
        }
    }
}