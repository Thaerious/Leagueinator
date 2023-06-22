using System;
using System.Collections.Generic;
using System.Text;

namespace Leagueinator.Utility_Classes {
    public class XMLStringBuilder {
        private StringBuilder sb = new StringBuilder();
        private int depth = 0;
        public char indent = '\t';
        private List<IndentedString> lines = new List<IndentedString>();

        public void OpenTag(string name, params string[] attributes) {
            var text = $"<{name}";

            foreach (var attr in attributes) {
                text = text + ($" {attr}");
            }

            text = text + ">";

            lines.Add(new IndentedString(depth, text));
            depth++;
        }

        public void OpenTag(string name) {
            var text = $"<{name}>";
            lines.Add(new IndentedString(depth, text));
            depth++;
        }

        public void AppendLine(string text) {
            lines.Add(new IndentedString(depth, text));
        }

        public void AppendLines(string text) {
            string[] lines = text.Split('\n');

            foreach (string line in lines) {
                this.AppendLine(line);
            }
        }

        public void InlineTag(string tag, string text) {
            var t = $"<{tag}>{text}</{tag}>";
            lines.Add(new IndentedString(depth, t));
        }

        public void CloseTag(string name) {
            depth--;
            var text = $"</{name}>";
            lines.Add(new IndentedString(depth, text));
        }

        public void AppendXML(XMLStringBuilder xsb) {
            foreach (IndentedString iString in xsb.lines) {
                lines.Add(new IndentedString(iString.indent + depth, iString.text));
            }
        }

        public override string ToString() {
            var sb = new StringBuilder();
            foreach (IndentedString iString in this.lines) {
                sb.AppendLine(iString.ToString());
            }
            return sb.ToString();
        }
    }

    public class IndentedString {
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
