/***************************************************************
 * Author: Faraz Masood Khan 
 * Description: Helper to write beautifully indented SQL queries
 * Project: http://www.fanaticlab.com/projects/crystalmapper/
 * Copyright (c) 2013 FanaticLab
 ***************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CrystalMapper.Linq
{
    /// <summary>
    /// Query writer with preserve indentation
    /// </summary>
    internal class QueryWriter
    {
        private int indent;

        private StringBuilder queryWriter = new StringBuilder();

        public string IndentCharacters = " ";

        /// <summary>
        /// Indentation string
        /// </summary>
        public string Indentation { get; private set; }

        /// <summary>
        /// Indent level
        /// </summary>
        public int Indent
        {
            get { return this.indent; }
            set
            {
                this.indent = value;
                this.ComputeIndentation();
            }
        }

        /// <summary>
        /// Write an object
        /// </summary>
        /// <param name="value">Value to write in query</param>
        /// <returns>QueryWriter</returns>
        public QueryWriter Write(object value)
        {
            this.queryWriter.Append(value);
            return this;
        }

        /// <summary>
        /// Writes blank line
        /// </summary>
        /// <returns>QueryWriter</returns>
        public QueryWriter WriteLine()
        {
            this.queryWriter.AppendLine().Append(this.Indentation);
            return this;
        }

        /// <summary>
        /// Write value and newline
        /// </summary>
        /// <param name="value">Value to write in query</param>
        /// <returns>QueryWriter</returns>
        public QueryWriter WriteLine(object value)
        {
            value = value ?? string.Empty;
            this.queryWriter.AppendLine(value.ToString()).Append(this.Indentation);
            return this;
        }

        /// <summary>
        /// Returns length of last line
        /// </summary>
        /// <returns></returns>
        public int GetLastLineLength()
        {
            string data = this.queryWriter.ToString();
            int indexOfNewLine = data.LastIndexOf(Environment.NewLine);
            if (indexOfNewLine != -1)
                return data.Length - indexOfNewLine - 1;

            return 0;
        }

        /// <summary>
        /// Return SQL query
        /// </summary>
        /// <returns>SQL query</returns>
        public override string ToString()
        {
            return this.queryWriter.ToString();
        }

        private void ComputeIndentation()
        {   
            // Set indentation based on indent level
            Indentation = null;
            for (int i = 0; i < indent; i++)
                Indentation += IndentCharacters;
        }
    }
}
