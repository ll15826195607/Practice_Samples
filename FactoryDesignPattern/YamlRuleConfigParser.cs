using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryDesignPattern
{
    public class YamlRuleConfigParser : IRuleConfigParser
    {
        public RuleConfig  Parse(String confingTxt)
        {
            return new RuleConfig();
        }
    }
}
