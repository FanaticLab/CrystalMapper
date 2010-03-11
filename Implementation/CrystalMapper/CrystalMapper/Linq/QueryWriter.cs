using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CrystalMapper.Linq
{
    internal class QueryWriter
    {
        private int indent;

        private StringBuilder queryWriter = new StringBuilder();

        public string IndentCharacters = " ";

        public string Indentation { get; private set; }

        public int Indent
        {
            get { return this.indent; }
            set
            {
                this.indent = value;
                this.ComputeIndentation();
            }
        }

        public QueryWriter Write(object value)
        {
            this.queryWriter.Append(value);
            return this;
        }

        public QueryWriter WriteLine()
        {
            this.queryWriter.AppendLine().Append(this.Indentation);
            return this;
        }

        public QueryWriter WriteLine(object value)
        {
            value = value ?? string.Empty;
            this.queryWriter.AppendLine(value.ToString()).Append(this.Indentation);
            return this;
        }

        public int GetLastLineLength()
        {
            string data = this.queryWriter.ToString();
            int indexOfNewLine = data.LastIndexOf(Environment.NewLine);
            if (indexOfNewLine != -1)
                return data.Length - indexOfNewLine - 1;

            return 0;
        }

        public override string ToString()
        {
            return this.queryWriter.ToString();
        }

        private void ComputeIndentation()
        {
            Indentation = null;
            for (int i = 0; i < indent; i++)
                Indentation += IndentCharacters;
        }
    }
}
