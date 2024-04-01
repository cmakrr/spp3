namespace AssemblyAnalyzer
{
    [Serializable]
    public class LoadingException: Exception 
    {
        public LoadingException() { }

        public LoadingException(string message) : base(message)
        {

        }

    }

}
