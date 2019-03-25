using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ksu.Cis300.TrieLibrary
{
    public class TrieWithOneChild : ITrie
    {
        public ITrie Add(string s)
        {
            if (s == "")
            {
                _result = true;
                return this;
            }
            else if (s[0] == _label)
            {
               _child = _child.Add(s.Substring(1));
                return this;
            }
            else 
            {
                return new TrieWithManyChildren(s, _result, _label, _child);
            }
        }

        public bool Contains(string s)
        {
            if (s == "")
            {
                _result = true;
                return _result;
            }
            if (s[0] == _label)
            {
                bool check = _child.Contains(s);
                return check;
            }
            return false;
        }

        private bool _result;
        private ITrie _child;
        private char _label; 


        public TrieWithOneChild(string s, bool result)
        {
            if (s == "" || s[0] < 'a' || s[0] > 'z')
            {
                throw new ArgumentException();
            }

            _result = result;
            _label = s[0];
            _child = new TrieWithNoChildren();
            _child.Add(s.Substring(1));
        } 
    }
}
