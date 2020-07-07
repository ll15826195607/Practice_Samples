using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryDesignPattern
{
    public class RuleConfigSource
    {
        public RuleConfig Load(String ruleConfigFilePath)
        {
            String extension = GetFileExtension(ruleConfigFilePath);
            IRuleConfigParser parser = RuleConfigParserFactory.CreateParser(extension);
            if (parser == null)
            {
                throw new InvalidDataException(String.Format("Rule Config File Format Is Not supported: {0}", ruleConfigFilePath));
            }

            String configText = String.Empty;
            RuleConfig ruleConfig = parser.Parse(configText);
            return ruleConfig;
        }

        private String GetFileExtension(String filePath)
        {
            return "JSON";
        }
    }
}
