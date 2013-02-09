using System;
using System.ServiceModel.Configuration;

namespace CalleeLib
{
    public class JsonpBindingExtension : BindingElementExtensionElement
    {
        public override Type BindingElementType
        {
            get { return typeof(JSONPBindingElement); }

        }

        protected override System.ServiceModel.Channels.BindingElement CreateBindingElement()
        {
            return new JSONPBindingElement();
        }
    }
}
