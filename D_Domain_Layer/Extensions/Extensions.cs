using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace D_Domain_Layer.Extensions
{
    public static class Extensions
    {
        public static string GetDescription(this Enum value)
        {
            var attribute = 
                value.GetType()
                     .GetTypeInfo()
                     .GetMember(value.ToString())
                     .FirstOrDefault(member => member.MemberType == MemberTypes.Field)
                    .GetCustomAttributes(typeof(DescriptionAttribute),false)
                    .SingleOrDefault()
                    as DescriptionAttribute;

            return attribute?.Description ?? value.ToString();

        }
    }
}
