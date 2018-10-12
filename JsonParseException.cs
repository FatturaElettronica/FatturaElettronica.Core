using System;
using Newtonsoft.Json;

namespace FatturaElettronica.Common
{
    /// <summary>
    /// Json parsing exception
    /// </summary>
    public class JsonParseException : Exception
    {
        private JsonReader reader;

        public int LineNumber { get; }
        public int LinePosition { get; }

        public JsonParseException(string message, JsonReader reader) : base(message)
        {
            this.reader = reader;

            if (reader is JsonTextReader)
            {
                var textReader = reader as JsonTextReader;

                this.LineNumber = textReader.LineNumber;
                this.LinePosition = textReader.LinePosition;
            }
        }


    }
}