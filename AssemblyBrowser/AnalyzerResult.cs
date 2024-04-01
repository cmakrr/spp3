using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AssemblyAnalyzer
{
    public class AnalyzerResult
    {
        public string assemblyName { get; set; }
        public ICollection<NamespaceInfo> namespacesCollection {
            get => _namespaces.Values;
        }
        public ConcurrentDictionary<string, NamespaceInfo> namespacesDictionary { get => _namespaces; }

        private ConcurrentDictionary<string, NamespaceInfo> _namespaces;
        public void AddType(Type type, string nSpace)
        {
            NamespaceInfo nsp = _namespaces.GetOrAdd(nSpace, new NamespaceInfo(nSpace));
            nsp.AddType(new TypeInfo(type));
        }
        public AnalyzerResult(string assemblyName)
        {
            this.assemblyName = assemblyName;
            _namespaces = new();
        }
    }
}
