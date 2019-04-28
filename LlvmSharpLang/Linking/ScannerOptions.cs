using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace LlvmSharpLang.Linking
{
    public class ScannerOptions
    {
        /// <summary>
        /// The root, starting path of the scanner.
        /// </summary>
        public string Root { get; set; }

        /// <summary>
        /// The Regex string pattern(s) that will be
        /// used to determine which files to match.
        /// </summary>
        public string[] Match { get; set; }

        /// <summary>
        /// The Regex string pattern(s) that will be used
        /// to determine which files to exclude from
        /// matching.
        /// </summary>
        public string[] Exclude { get; set; }

        public Regex[] CompiledMatches { get; protected set; }

        public Regex[] CompiledExclusions { get; protected set; }

        public void Init()
        {
            List<Regex> compiledMatches = new List<Regex>();
            List<Regex> compiledExclusions = new List<Regex>();

            // Populate compiled matches.
            foreach (var match in this.Match)
            {
                compiledMatches.Add(new Regex(match));
            }

            // Populate compiled exclusions.
            foreach (var exclusion in this.Exclude)
            {
                compiledExclusions.Add(new Regex(exclusion));
            }

            // Assign populated bounds.
            this.CompiledMatches = compiledMatches.ToArray();
            this.CompiledExclusions = compiledExclusions.ToArray();
        }

        /// <summary>
        /// Determine whether a path matches an
        /// exclusion.
        /// </summary>
        public bool IsExcluded(string path)
        {
            // Obtain the basename of the path.
            string baseName = Path.GetFileName(path);

            // Loop through all compiled exclusions.
            foreach (var exclude in this.CompiledExclusions)
            {
                // Test exclusion pattern against the path's basename.
                if (exclude.IsMatch(baseName))
                {
                    return true;
                }
            }

            // No exclusion matched.
            return false;
        }

        /// <summary>
        /// Determine whether a path matches.
        /// </summary>
        public bool IsMatch(string path)
        {
            // Obtain the basename of the path.
            string baseName = Path.GetFileName(path);

            // Loop through all compiled exclusions.
            foreach (var match in this.CompiledMatches)
            {
                // Test match pattern against the path's basename.
                if (match.IsMatch(baseName))
                {
                    return true;
                }
            }

            // No match.
            return false;
        }
    }
}