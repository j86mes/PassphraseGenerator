using System;
using System.IO;
using System.Reflection;

namespace PassphraseUtility.WordList
{
    public class EmbeddedWordListProvider
    {
        public Stream GetEmbeddedResourceStream(string resourceName)
        {
            return Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName);
        }
    }
}
