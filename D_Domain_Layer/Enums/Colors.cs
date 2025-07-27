using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D_Domain_Layer.Enums
{

    //var action = ActionCode.Edit;
    //var actionDescription = action.GetDescription(); 
    public enum Colors
    {
        [Description("Red")]
        Red,
        [Description("Green")]
        Green,
        [Description("Blue")]
        Blue,
        [Description("Yellow")]
        Yellow,
        [Description("Black")]
        Black,
        [Description("White")]
        White,
        [Description("Orange")]
        Orange,
        [Description("Purple")]
        Purple,
        [Description("Pink")]
        Pink,
        [Description("Brown")]
        Brown,
        [Description("Gray")]
        Gray,
        [Description("Cyan")]
        Cyan,
        [Description("Magenta")]
        Magenta,
        [Description("Lime")]
        Lime,
        [Description("Teal")]
        Teal
    }
}
