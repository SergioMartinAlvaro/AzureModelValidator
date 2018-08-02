using System.Reflection;

namespace FunctionApp1
{
    public class ModelValidator<T>
    {

        public T DeserializedObject { get; set; }
        public PropertyInfo[] Attributes { get; set; }

        public ModelValidator(T _DeserializedObject) {
            DeserializedObject = _DeserializedObject;
        }

        public bool IsValidModel()
        {
            Attributes = ExtractProperties();
            return ValidateModel();

        }

        private PropertyInfo[] ExtractProperties()
        {
            return this.DeserializedObject.GetType().GetProperties();
        }

        private dynamic GetAttributeValue(string AttributeName)
        {
            return DeserializedObject.GetType().GetProperty(AttributeName).GetValue(DeserializedObject, null);
        }

        private bool ValidateModel()
        {
            bool valid = true;

            foreach(PropertyInfo Attribute in Attributes)
            {
                if(IsAttributeNull(Attribute.Name))
                {
                    valid = false;
                    break;
                }
            }

            return valid;
        }

        private bool IsAttributeNull(string AttributeName)
        {
            bool isNull = false;

            if(GetAttributeValue(AttributeName) == null)
            {
                isNull = true; 
            } else
            {
                isNull = false;
            }

            return isNull;
        }


    }
}
