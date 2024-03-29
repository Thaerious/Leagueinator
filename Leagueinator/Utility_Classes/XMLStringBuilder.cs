﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Leagueinator.Utility_Classes {
    public class XMLStringBuilder {
        private readonly StringBuilder sb = new StringBuilder();
        private int Depth => this.CurrentTag.Count;
        public char Indent = '\t';
        private readonly List<IndentedObject> lines = new List<IndentedObject>();
        private readonly Stack<string> CurrentTag = new Stack<string>();

        public XMLStringBuilder OpenTag(string name, params string[] attributes) {
            var text = $"<{name} {attributes.DelString(" ")}>";
            this.lines.Add(new IndentedString(this.Depth, text));
            this.CurrentTag.Push(name);
            return this;
        }

        public XMLStringBuilder OpenTag(string name) {
            var text = $"<{name}>";
            this.lines.Add(new IndentedString(this.Depth, text));
            this.CurrentTag.Push(name);
            return this;
        }

        public XMLStringBuilder AppendLine(string text) {
            this.lines.Add(new IndentedString(this.Depth, text));
            return this;
        }

        public XMLStringBuilder AppendLines(string text) {
            string[] lines = text.Split('\n');

            foreach (string line in lines) {
                this.AppendLine(line);
            }
            return this;
        }

        public XMLStringBuilder InlineTag(string tag, string text = "") {
            var t = "";
            if (text == "") t = $"<{tag}/>";
            else t = $"<{tag}>{text}</{tag}>";

            this.lines.Add(new IndentedString(this.Depth, t));
            return this;
        }

        public XMLStringBuilder InlineTag(string tag, string text, params string[] attributes) {
            var t = $"<{tag} {attributes.DelString(" ")}>{text}</{tag}>";
            this.lines.Add(new IndentedString(this.Depth, t));
            return this;
        }

        public XMLStringBuilder CloseTag(string name) {
            var text = $"</{name}>";
            this.lines.Add(new IndentedString(this.Depth, text));
            return this;
        }

        public XMLStringBuilder CloseTag() {
            var text = $"</{this.CurrentTag.Pop()}>";
            this.lines.Add(new IndentedString(this.Depth, text));
            return this;
        }

        public XMLStringBuilder AppendXML(XMLStringBuilder xsb) {
            foreach (IndentedString iString in xsb.lines) {
                this.lines.Add(new IndentedString(iString.indent + this.Depth, iString.text));
            }
            return this;
        }

        public override string ToString() {
            var sb = new StringBuilder();
            foreach (IndentedString iString in this.lines) {
                sb.AppendLine(iString.ToString());
            }
            return sb.ToString();
        }
    }

    class IndentedObject {
        public object target = "";
        public int indent = 0;
        public char c = '\t';

        public IndentedObject(int indent, object target) {
            this.indent = indent;
            this.target = target;
        }

        public override string ToString() {
            return $"{new String(this.c, this.indent)}{this.target.ToString()}";
        }
    }


    class IndentedString : IndentedObject {

        public string text { get => this.target.ToString(); }

        public IndentedString(int indent, string text) : base(indent, text) { }
    }
}
