using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AssemblyAnalyzer
{
    public class Analyzer
    {
        public static AnalyzerResult Analyze(string path)
        {
            Assembly currAssembly = null;
            try
            {
                currAssembly = Assembly.LoadFrom(path);
            } catch
            {
                throw new LoadingException("Could not load assembly");
            }
            AnalyzerResult assemblyInfo = new AnalyzerResult(currAssembly.GetName().FullName);
            Type[] types;
            try
            {
                types = currAssembly.GetTypes();
            } catch(ReflectionTypeLoadException e)
            {
                throw new LoadingException("Could not get types");
            }
            foreach (Type type in types)
            {
                string nSpace = type.Namespace;
                if (nSpace == null)
                {
                    nSpace = "Empty";
                }
                try
                {   
                    if (type.GetCustomAttribute<CompilerGeneratedAttribute>() == null)
                    {
                        assemblyInfo.AddType(type, nSpace);
                    }
                } catch (FileNotFoundException ex)
                {
                    assemblyInfo.AddType(type, nSpace);
                }
            }
            return assemblyInfo;
        }
    }

}
