using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Automation;

namespace UIDeskAutomationLib
{
    /// <summary>
    /// This class represents a Static Text control.
    /// </summary>
    public class UIDA_Text: ElementBase
    {
        public UIDA_Text(AutomationElement el)
        {
            this.uiElement = el;
        }
		
		/// <summary>
        /// Gets the text of the control.
        /// </summary>
        /// <returns>text of the control</returns>
		public string Text
		{
			get
			{
				return this.GetText();
			}
		}
    }
}
