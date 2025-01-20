using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.UX.Forms.TableFormStates
{
    public class CTableFormStateHasChanges: CTableFormState, IFormState
    {
        // --------------------------------------------------------------------------------------
        public CTableFormStateHasChanges(CTableFormContext p_oContext) : base(p_oContext)
        {
            //[PATTERNS: State: In the constructor of the state we make any changes to the context, to reflect this state.
            if (this.context.LoadTable != null)
                this.context.LoadTable.Enabled = false;

            if (this.context.SaveTable != null)
                this.context.SaveTable.Enabled = true;
        }
        // --------------------------------------------------------------------------------------

        #region //IFormState\\
        // --------------------------------------------------------------------------------------
        public void PerformAction(String p_sAction)
        {
            bool bIsTransitioningToNextState = (p_sAction == "TableLoaded");
            if (bIsTransitioningToNextState)
                this.context.State = this.NextState();
        }
        // --------------------------------------------------------------------------------------
        public IFormState NextState()
        {
            return new CTableFormStateLoaded(this.context);
        }
        // --------------------------------------------------------------------------------------
        #endregion
    }
}
