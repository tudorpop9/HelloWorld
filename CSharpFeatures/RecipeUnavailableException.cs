using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpFeatures
{
    public class RecipeUnavailableException : Exception
    {
        public RecipeUnavailableException()
        {

        }

        public RecipeUnavailableException(string message):base(message)
        {

        }
        public RecipeUnavailableException(string message, Exception inner) : base(message, inner)
        {

        }
        /*
        public RecipeUnavailableException(SerializationInfo info, StreamingContext context): base(info, context)
        {

        }*/


    }

}
