using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace KendoUIMvcAttributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class KendoMultiSelectAttribute : Attribute, IMetadataAware
    {
        public string Action { get; private set; }
        public string Controller { get; private set; }
        public string CascadeFrom { get; set; }
        public bool UseTextValue { get; set; }
        public string Watermark { get; set; }
        public string TextField { get; set; }
        public string ValueField { get; set; }


        /// <summary>
        /// <para>Provide a comma separated list of values to be included in the Query string when the Dropdown is bound.</para>
        /// <para>Params from model values: ex. "MyProperty,MoreProperties,Another"</para>
        /// <para>Param with alias: ex. "MyModelProperty>>SomeOtherName"</para>
        /// <para>Custom param values: ex. "Custom=3,SomeVar=foo"</para>
        /// <para>Mixed: "MyProperty,SomethingCustom=bar,AnotherModelProp,OriginalProp>>RenamedProp"</para>
        /// </summary>
        public string Params { get; set; }

        public KendoMultiSelectAttribute(string action, string controller)
        {
            Action = action;
            Controller = controller;
            Watermark = " - Select Item - ";
            TextField = "Text";
            ValueField = "Value";
        }

        public void OnMetadataCreated(ModelMetadata metadata)
        {
            metadata.TemplateHint = "KendoMultiSelect";

            metadata.AdditionalValues["action"] = Action;
            metadata.AdditionalValues["controller"] = Controller;
            metadata.AdditionalValues["params"] = Params;
            metadata.AdditionalValues["cascadeFrom"] = CascadeFrom;
            metadata.AdditionalValues["useTextValue"] = UseTextValue;
            metadata.AdditionalValues["watermark"] = Watermark;
            metadata.AdditionalValues["textField"] = TextField;
            metadata.AdditionalValues["valueField"] = ValueField;

        }
    }

}
