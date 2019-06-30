using System;

namespace MVVM_Trial.src.model
{
    public class TextConverterModel
    {
        private readonly Func<string, string> _convertFunc;

        public TextConverterModel(Func<string, string> convertFunc)
        {
            _convertFunc = convertFunc;
        }


        public string convertText(String input)
        {
            return _convertFunc(input);
        }
    }
}
