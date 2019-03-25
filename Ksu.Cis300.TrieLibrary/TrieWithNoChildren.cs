using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ksu.Cis300.TrieLibrary
{
    /// <summary>
    /// public class for a trie with no children.
    /// </summary>
    public class TrieWithNoChildren : ITrie
    {
        /// <summary>
        /// indicates whether the empty string is stored in the trie rooted at this node.
        /// </summary>
        private bool _hasEmptyString;

        /// <summary>
        /// method for adding the string s.
        /// </summary>
        /// <param name="s">the string to be checking and added.</param>
        /// <returns>this if the string is empty and a trie with one child if not.</returns>
        public ITrie Add(string s)
        {
            if (s == "")
            {
                _hasEmptyString = true;
                return this;
            }
            else
            {
                return new TrieWithOneChild(s, _hasEmptyString);
            }
        }

        /// <summary>
        /// sees if the trie contains the string.
        /// </summary>
        /// <param name="s">the string that is being checked.</param>
        /// <returns>a bool, which is always false.</returns>
        public bool Contains(string s)
        {
            if (s == "")
            {
                return _hasEmptyString;
            }
            else
            {
                return false;
            }
        }
    }
}
