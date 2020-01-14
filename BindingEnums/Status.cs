using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace BindingEnums
{
    public enum Status
    {
        [Description("This is horrible")]
        Horrible,
        [Description("This is bad")]
        Bad,
        [Description("This is so so")]
        SoSo,
        [Description("This is Good")]
        Good,
        [Description("This is Better")]
        Better,
        [Description("This is Best")]
        Best
    }
}
