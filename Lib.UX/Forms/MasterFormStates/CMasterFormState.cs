using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.UX.Forms.TableFormStates
{
    public class CMasterFormState
    {
        protected CMasterFormContext context;

        // ........................................................................
        public string StateName { get { return GetType().Name; } }
        // ........................................................................

        // --------------------------------------------------------------------------------------
        public CMasterFormState(CMasterFormContext p_oContext)
        {
            context = p_oContext;
        }
        // --------------------------------------------------------------------------------------
    }
}
