using System;
using System.Collections.Generic;
using System.Text;

namespace Leagueinator.Utility_Classes {
    public class XMLStringBuilder {
        private readonly StringBuilder sb = new StringBuilder();
        private int Depth => this.CurrentTag.Count;
        public char Indent = '\t';
        private readonly List<IndentedString> lines = new List<IndentedString>();
        private readonly Stack<string> CurrentTag = new Stack<string>();

        public XMLStringBuilder OpenTag(string name, params string[] attributes) {
            var text = $"<{name}";

            foreach (var attr in attributes) {
                text += ($" {attr}");
            }

            text += ">";

            lines.Add(new IndentedString(Depth, text));
            CurrentTag.Push(name);
            return this;
        }

        public XMLStringBuilder OpenTag(string name) {
            var text = $"<{name}>";
            lines.Add(new IndentedString(Depth, text));
            CurrentTag.Push(name);
            return this;
        }

        public XMLStringBuilder AppendLine(string text) {
            lines.Add(new IndentedString(Depth, text));
            return this;
        }

        public XMLStringBuilder AppendLines(string text) {
            string[] lines = text.Split('\n');

            foreach (string line in lines) {
                AppendLine(line);
            }
            return this;
        }

        public XMLStringBuilder InlineTag(string tag, string text) {
            var t = $"<{tag}>{text}</{tag}>";
            lines.Add(new IndentedString(Depth, t));
            return this;
        }

        public XMLStringBuilder CloseTag(string name) {
            var text = $"</{name}>";
            lines.Add(new IndentedString(Depth, text));
            return this;
        }

        public XMLStringBuilder CloseTag() {
            var text = $"</{this.CurrentTag.Pop()}>";
            lines.Add(new IndentedString(Depth, text));
            return this;
        }

        public XMLStringBuilder AppendXML(XMLStringBuilder xsb) {
            foreach (IndentedString iString in xsb.lines) {
                lines.Add(new IndentedString(iString.indent + Depth, iString.text));
            }
            return this;
        }

        public override string ToString() {
            var sb = new StringBuilder();
            foreach (IndentedString iString in lines) {
                sb.AppendLine(iString.ToString());
            }
            return sb.ToString();
        }
    }

    class IndentedString {
        public string text = "";
        public int indent = 0;
        public char c = '\t';

        public IndentedString(int indent, string text) {
            this.indent = indent;
            this.text = text;
        }

        public override string ToString() {
            return $"{new String(c, indent)}{text}";
        }
    }
}
