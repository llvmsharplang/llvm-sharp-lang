using System;
using Ion.CodeGeneration.Helpers;
using Ion.Parsing;

namespace Ion.CodeGeneration
{
    public class Import : IReaction<Module>
    {
        public PathResult Path { get; }

        public Import(PathResult path)
        {
            this.Path = path;
        }

        public void Invoke(Module context)
        {
            // TODO
        }
    }
}
