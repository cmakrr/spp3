using System.Reflection;

namespace AssemblyAnalyzer
{
    public class TypeInfo
    {
        public Type type { get; set; }
        public List<MethodInfo> methods { get; set; }
        public List<FieldInfo> fields { get; set; }
        public List<PropertyInfo> properties { get; set; }

        public TypeInfo(Type type)
        {
            this.type = type;
            methods = new List<MethodInfo>();
            fields = new List<FieldInfo>();
            properties = new List<PropertyInfo>();
        }
        
        public void AddMethods(System.Reflection.MethodInfo[] methods)
        {
            foreach(var method in methods)
            {
                this.methods.Add(new MethodInfo(
                    method.Name,
                    method.ReturnType.Name,
                    String.Join(" ", method.GetParameters().Select(p => p.ParameterType.Name))
                ));
            }
        }
    }
}
