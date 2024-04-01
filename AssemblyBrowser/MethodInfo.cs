namespace AssemblyAnalyzer
{
    public class MethodInfo
    {
        public string Name { get; set; }
        public string returnType { get; set; }
        public string paramTypes { get; set; }

        public MethodInfo(string name, string returnType, string paramTypes)
        {
            this.Name = name;
            this.returnType = returnType;
            this.paramTypes = paramTypes;
        }
    }
}
