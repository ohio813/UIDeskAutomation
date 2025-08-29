using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Automation;

namespace UIDeskAutomationLib
{
    /// <summary>
    /// Class that represents a Top Level Menu element, like a Contextual menu.
    /// </summary>
    public class UIDA_Menu : ElementBase
    {
        public UIDA_Menu(AutomationElement el)
        {
            base.uiElement = el;
        }
    }
}
