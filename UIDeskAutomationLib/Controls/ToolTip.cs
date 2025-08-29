using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Automation;

namespace UIDeskAutomationLib
{
    /// <summary>
    /// Represents a ToolTip control.
    /// </summary>
    public class UIDA_ToolTip: ElementBase
    {
        public UIDA_ToolTip(AutomationElement el)
        {
            this.uiElement = el;
        }
    }
}
