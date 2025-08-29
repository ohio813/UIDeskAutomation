using System;
using System.Collections.Generic;
using System.Windows.Automation;

namespace UIDeskAutomationLib
{
    /// <summary>
    /// UI Automation properties
    /// </summary>
    public enum UIDA_Property
    {
        /// <summary>
        /// Identifies the AcceleratorKey property, which is a string containing the accelerator key (also called shortcut key) combinations for the automation element.
        /// Shortcut key combinations invoke an action. For example, CTRL+O is often used to invoke the Open file common dialog box.
        /// </summary>
        AcceleratorKey,

        /// <summary>
        /// Identifies the AccessKey property, which is a string containing the access key character for the automation element.
        /// An access key (sometimes called a mnemonic) is a character in the text of a menu, menu item, or label of a control such as a button, that activates the associated menu function. For example, to open the File menu, for which the access key is typically F, the user would press ALT+F.
        /// </summary>
        AccessKey,

        /// <summary>
        /// Identifies the AutomationId property, which is a string containing the UI Automation identifier (ID) for the automation element.
        /// </summary>
        AutomationId,

        /// <summary>
        /// Identifies the ClassName property, which is a string containing the class name for the automation element as assigned by the control developer.
        /// </summary>
        ClassName,

        /// <summary>
        /// Identifies the FrameworkId property, which is a string containing the name of the underlying UI framework that the automation element belongs to.
        /// The FrameworkId enables client applications to process automation elements differently depending on the particular UI framework. Examples of property values include "Win32", "WinForm", and "DirectUI".
        /// </summary>
        FrameworkId,
		
		/// <summary>
        /// Identifies the HelpText property, which is a help text string associated with the automation element.
        /// </summary>
        HelpText,

        /// <summary>
        /// Identifies the ItemStatus property, which is a text string describing the status of an item of the automation element.
        /// ItemStatus enables a client to ascertain whether an element is conveying status about an item as well as what the status is. For example, an item associated with a contact in a messaging application might be "Busy" or "Connected".
        /// </summary>
        ItemStatus,

        /// <summary>
        /// Identifies the ItemType property, which is a text string describing the type of the automation element.
        /// ItemType is used to obtain information about items in a list, tree view, or data grid. For example, an item in a file directory view might be a "Document File" or a "Folder".
        /// </summary>
        ItemType,

        //ProcessId,
    }

    public partial class ElementBase
    {
        private static Dictionary<UIDA_Property, AutomationProperty> mapPropertyIds = null;

        internal static Dictionary<UIDA_Property, AutomationProperty> MapPropertyIds
        {
            get
            {
                if (mapPropertyIds != null)
                {
                    return mapPropertyIds;
                }

                mapPropertyIds = new Dictionary<UIDA_Property, AutomationProperty>();
                mapPropertyIds.Add(UIDA_Property.AcceleratorKey, AutomationElement.AcceleratorKeyProperty);
                mapPropertyIds.Add(UIDA_Property.AccessKey, AutomationElement.AccessKeyProperty);
                //mapPropertyIds.Add(UIDA_Property.AriaRole, AutomationElement.AriaRoleProperty);
                mapPropertyIds.Add(UIDA_Property.AutomationId, AutomationElement.AutomationIdProperty);
                mapPropertyIds.Add(UIDA_Property.ClassName, AutomationElement.ClassNameProperty);
                mapPropertyIds.Add(UIDA_Property.FrameworkId, AutomationElement.FrameworkIdProperty);
                //mapPropertyIds.Add(UIDA_Property.FullDescription, AutomationElement.FullDescriptionProperty);
                mapPropertyIds.Add(UIDA_Property.HelpText, AutomationElement.HelpTextProperty);
                mapPropertyIds.Add(UIDA_Property.ItemStatus, AutomationElement.ItemStatusProperty);
                mapPropertyIds.Add(UIDA_Property.ItemType, AutomationElement.ItemTypeProperty);
                //mapPropertyIds.Add(UIDA_Property.LocalizedLandmarkType, AutomationElement.LocalizedLandmarkTypeProperty);
                //mapPropertyIds.Add(UIDA_Property.ProcessId, AutomationElement.ProcessIdProperty);
                //mapPropertyIds.Add(UIDA_Property.ProviderDescription, AutomationElement.ProviderDescriptionProperty);
                return mapPropertyIds;
            }
        }

        /// <summary>
        /// Finds the first child given the value of a property.
        /// </summary>
        /// <param name="property">The property</param>
        /// <param name="value">The value of the property</param>
        /// <param name="ignoreCase">true - search case insensitive, false - case sensitive</param>
        /// <returns>A UIDA_Generic object. You can call As...() functions to cast to whatever element type you want.</returns>
        public UIDA_Generic FindFirstChild(UIDA_Property property, string value, bool ignoreCase = false)
        {
			PropertyCondition condition = null;
            if (ignoreCase == true)
            {
                condition = new PropertyCondition(MapPropertyIds[property], value, PropertyConditionFlags.IgnoreCase);
            }
            else
			{
				condition = new PropertyCondition(MapPropertyIds[property], value);
			}

			AutomationElement elementFound = this.uiElement.FindFirst(TreeScope.Children, condition);
            if (elementFound == null) 
            {
                return null;
            }
            return new UIDA_Generic(elementFound);
        }

        /// <summary>
        /// Finds the first descendant given the value of a property.
        /// </summary>
        /// <param name="property">The property</param>
        /// <param name="value">The value of the property</param>
        /// <param name="ignoreCase">true - search case insensitive, false - case sensitive</param>
        /// <returns>A UIDA_Generic object. You can call As...() functions to cast to whatever element type you want.</returns>
        public UIDA_Generic FindFirstDescendant(UIDA_Property property, string value, bool ignoreCase = false)
        {
            PropertyCondition condition = null;
            if (ignoreCase == true)
            {
                condition = new PropertyCondition(MapPropertyIds[property], value, PropertyConditionFlags.IgnoreCase);
            }
            else
			{
				condition = new PropertyCondition(MapPropertyIds[property], value);
			}

            AutomationElement elementFound = this.uiElement.FindFirst(TreeScope.Descendants, condition);
            if (elementFound == null)
            {
                return null;
            }
            return new UIDA_Generic(elementFound);
        }

        /// <summary>
        /// Finds all children given the value of a property.
        /// </summary>
        /// <param name="property">The property</param>
        /// <param name="value">The value of the property</param>
        /// <param name="ignoreCase">true - search case insensitive, false - case sensitive</param>
        /// <returns>A UIDA_Generic objects array. You can call As...() functions for any object in the array to cast to whatever element type you want.</returns>
        public UIDA_Generic[] FindAllChildren(UIDA_Property property, string value, bool ignoreCase = false)
        {
            PropertyCondition condition = null;
            if (ignoreCase == true)
            {
                condition = new PropertyCondition(MapPropertyIds[property], value, PropertyConditionFlags.IgnoreCase);
            }
            else
			{
				condition = new PropertyCondition(MapPropertyIds[property], value);
			}

            AutomationElementCollection collection = this.uiElement.FindAll(TreeScope.Children, condition);
            if (collection == null)
            {
                return null;
            }

            List<UIDA_Generic> children = new List<UIDA_Generic>();
            foreach (AutomationElement el in collection)
            {
                children.Add(new UIDA_Generic(el));
            }
            return children.ToArray();
        }

        /// <summary>
        /// Finds all descendants given the value of a property.
        /// </summary>
        /// <param name="property">The property</param>
        /// <param name="value">The value of the property</param>
        /// <param name="ignoreCase">true - search case insensitive, false - case sensitive</param>
        /// <returns>A UIDA_Generic objects array. You can call As...() functions for any object in the array to cast to whatever element type you want.</returns>
        public UIDA_Generic[] FindAllDescendants(UIDA_Property property, string value, bool ignoreCase = false)
        {
            PropertyCondition condition = null;
            if (ignoreCase == true)
            {
                condition = new PropertyCondition(MapPropertyIds[property], value, PropertyConditionFlags.IgnoreCase);
            }
            else
			{
				condition = new PropertyCondition(MapPropertyIds[property], value);
			}

            AutomationElementCollection collection = this.uiElement.FindAll(TreeScope.Descendants, condition);
            if (collection == null)
            {
                return null;
            }

            List<UIDA_Generic> children = new List<UIDA_Generic>();
            foreach (AutomationElement el in collection)
            {
                children.Add(new UIDA_Generic(el));
            }
            return children.ToArray();
        }
    }
}
