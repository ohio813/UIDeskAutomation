using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Automation;

namespace UIDeskAutomationLib
{
    /// <summary>
    /// Represents a ToolBar control.
    /// </summary>
    public class UIDA_ToolBar: ElementBase
    {
        public UIDA_ToolBar(AutomationElement el)
        {
            this.uiElement = el;
        }
    }
}
