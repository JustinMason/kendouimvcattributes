using System;
using System.Web.Mvc;

namespace KendoUIMvcAttributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class KendoTextBoxAttribute : Attribute, IMetadataAware
    {


        public KendoTextBoxAttribute()
        {
        }

        public void OnMetadataCreated(ModelMetadata metadata)
        {
            metadata.TemplateHint = "KendoTextBox";

            metadata.AdditionalValues["watermark"] = "Enter Text";

        }
    }
}