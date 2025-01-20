using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.UX.Forms
{
    public class CDataFormContext
    {
   
        // ........................................................................
        //[PATTERNS]: State: The context object keeps an interface reference to the current state
        internal IFormState? __state = null;
        public IFormState? State { get { return __state; } set { __state = value; } }
        // ........................................................................

        // --------------------------------------------------------------------------------------
        public CDataFormContext()
        {
        }
        // --------------------------------------------------------------------------------------
        //[ADVANCED OO] Up to this point we have only used references to objects. This method has one parameter
        //              which receives a reference to a class type that was provided by
        //              the client call (the caller) using typeof() on a class identifier.
        //              This is called dynamic class loading. The class type is used as the value
        //              that can be dynamically loaded at runtime into a variable.
        public void Initialize(Type p_tStateClass)
        {
            //[ADVANCED OO] The next line is a dynamic creation of an object, or dynamic instantiation.
            //[C#] The mechanism that supports dynamic class loading and instantiation is called reflection.
            //      The CreateInstance() method accepts a class and after a  list o any parameters for the constructor.
            //                                         class type  ,  param1 , ...
            Object? oState = Activator.CreateInstance(p_tStateClass, this);
            this.__state = oState as IFormState;
        }
        // --------------------------------------------------------------------------------------
        //[PATTERNS]: State: The context performs some action on the current state.
        public void PerformAction(String p_sAction)
        {
            if (__state != null) 
                __state.PerformAction(p_sAction);
        }
        // --------------------------------------------------------------------------------------

    }
}
