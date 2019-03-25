using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ksu.Cis300.TrieLibrary
{
    /// <summary>
    /// public class for trie with one child.
    /// </summary>
    public class TrieWithOneChild : ITrie
    {
        /// <summary>
        /// Indicates whether the trie rooted at this node contains the empty string.
        /// </summary>
        private bool _hasEmptyString;

        /// <summary>
        /// a private ITrie representing the only child.
        /// </summary>
        private ITrie _onlyChild;

        /// <summary>
        /// a private char representing the label.
        /// </summary>
        private char _label;

        /// <summary>
        /// the constructor for trie with one child.
        /// </summary>
        /// <param name="s">a string s.</param>
        /// <param name="hasEmpty">the bool for has empty string.</param>
        public TrieWithOneChild(string s, bool hasEmpty)
        {
            if (s == "" || s[0] < 'a' || s[0] > 'z')
            {
                throw new ArgumentException();
            }

            _hasEmptyString = hasEmpty;
            _label = s[0];
            _onlyChild = new TrieWithNoChildren();
            _onlyChild = _onlyChild.Add(s.Substring(1));
        }

        /// <summary>
        /// public method that adds a string to the ITrie.
        /// </summary>
        /// <param name="s">a string that is being checked</param>
        /// <returns>depending on if the string is empty or is a proper letter returns this, an exception, or new trie with many children.</returns>
        public ITrie Add(string s)
        {
            if (s == "")
            {
                _hasEmptyString = true;
                return this;
            }
            else if (s[0] < 'a' || s[0] > 'z')
            {
                throw new ArgumentException();
            }
            else if (s[0] == _label)
            {
                _onlyChild = _onlyChild.Add(s.Substring(1));
                return this;
            }
            else
            {
                return new TrieWithManyChildren(s, _hasEmptyString, _label, _onlyChild);
            }
        }

        /// <summary>
        /// the contains method for the trie with one child. checks to see if ti contains the string.
        /// </summary>
        /// <param name="s">the string s being checked.</param>
        /// <returns>returns a bool saying if it is correctly implementd.</returns>
            public bool Contains(string s)
        {
            if (s == "")
            {
                return _hasEmptyString;
            }
            else if (s[0] == _label)
            {
                return _onlyChild.Contains(s.Substring(1)); 
            }
            else
            {
                return false;
            }
        }
    }
}
