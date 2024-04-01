using System.Reflection;

namespace AssemblyAnalyzer
{
    public class NamespaceInfo
    {
        public string namespaceName { get; set; }
        public List<TypeInfo> typeInfos { get; set; }
        public List<TypeInfo> TypeInfos
        {
            get => typeInfos;
        }
        public NamespaceInfo(string namespaceName)
        {
            this.namespaceName = namespaceName;
            typeInfos = new List<TypeInfo>();
        }   

        public void AddType(TypeInfo type)
        {
            type.fields = new List<FieldInfo>(type.type.GetFields());
            type.properties = new List<PropertyInfo>(type.type.GetProperties());
            type.AddMethods(type.type.GetMethods());
            typeInfos.Add(type);
        }
    }
}
