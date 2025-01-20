using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.UX.Forms.TableFormStates
{
    public class CTableFormState
    {
        protected CTableFormContext context;

        // ........................................................................
        public string StateName { get { return GetType().Name; } }
        // ........................................................................

        // --------------------------------------------------------------------------------------
        public CTableFormState(CTableFormContext p_oContext)
        {
            context = p_oContext;
        }
        // --------------------------------------------------------------------------------------
    }
}
