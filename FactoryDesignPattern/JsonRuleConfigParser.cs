using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryDesignPattern
{
    public class JsonRuleConfigParser : IRuleConfigParser
    {
        public RuleConfig Parse(string configTxt)
        {
            return new RuleConfig();
        }
    }
}
