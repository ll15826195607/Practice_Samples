using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryDesignPattern
{
    public class RuleConfigParserFactory
    {
        private static readonly Dictionary<String, IRuleConfigParser> cachedParsers = new Dictionary<String, IRuleConfigParser>();
        static RuleConfigParserFactory()
        {
            cachedParsers.Add("JSON", new JsonRuleConfigParser());
            cachedParsers.Add("XML", new XmlRuleConfigParser());
            cachedParsers.Add("YAML", new YamlRuleConfigParser());
        }

        /// <summary>
        /// 方法一
        /// </summary>
        public static IRuleConfigParser CreateParser(String configFormat)
        {
            String bwf = configFormat.ToUpper();
            if (bwf.Equals("XML"))
            {
                return new XmlRuleConfigParser();
            }
            else if (bwf.Equals("JSON"))
            {
                return new JsonRuleConfigParser();
            }
            else if (bwf.Equals("YAML"))
            {
                return new YamlRuleConfigParser();
            }
            else
            {
                return null;
            }
        }

        public static IRuleConfigParser CreateParser2(String configFormat)
        {
            if (cachedParsers.ContainsKey(configFormat))
            {
                return cachedParsers[configFormat];
            }
            else
            {
                return null;
            }
        }
    }
}
