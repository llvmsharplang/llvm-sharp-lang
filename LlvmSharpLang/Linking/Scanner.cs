using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using LlvmSharpLang.Misc;

namespace LlvmSharpLang.Linking
{
    public class Scanner
    {
        public static ScannerOptions defaultOptions => new ScannerOptions
        {
            Exclude = new string[]
            {
                @"^\."
            },

            Match = new string[]
            {
                @"\.xl$"
            }
        };

        public ScannerOptions Options { get; }

        public Scanner(ScannerOptions options)
        {
            this.Options = options;

            // Initialize options.
            this.Options.Init();
        }

        public Scanner(string root)
        {
            ScannerOptions options = Scanner.defaultOptions;

            options.Root = root;
            this.Options = options;

            // Initialize options.
            this.Options.Init();
        }

        /// <summary>
        /// Determine whether the root path folder
        /// exists.
        /// </summary>
        public bool VerifyRoot()
        {
            return Directory.Exists(this.Options.Root);
        }

        /// <summary>
        /// Scan for matching files within a directory
        /// inside the root folder.
        /// </summary>
        public string[] Scan(string path, bool recursive = true)
        {
            List<string> entries = new List<string>();

            // Join the path with the root path.
            string targetPath = Path.Join(this.Options.Root, path);

            // Set the target path to the root path.
            if (String.IsNullOrEmpty(path))
            {
                targetPath = this.Options.Root;
            }

            // Loop through all entries.
            foreach (var entry in Directory.GetFiles(targetPath))
            {
                // Continue if entry is excluded.
                if (this.Options.IsExcluded(entry))
                {
                    continue;
                }
                // Continue if entry is not matched.
                else if (!this.Options.IsMatch(entry))
                {
                    continue;
                }

                // Register entry in results.
                entries.Add(entry);

                // Scan recursively if applicable.
                if (recursive && Util.IsDirectory(entry))
                {
                    // Join provided path and entry path.
                    string nextTarget = Path.Join(path, entry);

                    // Register recursive result.
                    entries.AddRange(this.Scan(nextTarget));
                }
            }

            // Return an array of matching paths.
            return entries.ToArray();
        }

        public string[] Scan(bool recursive = true)
        {
            return this.Scan(null, recursive);
        }
    }
}