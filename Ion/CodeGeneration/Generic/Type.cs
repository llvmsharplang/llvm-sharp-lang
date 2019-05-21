using Ion.CodeGeneration.Helpers;
using Ion.CognitiveServices;
using Ion.Misc;
using LLVMSharp;

namespace Ion.CodeGeneration
{
    public class Type : IUncontextedEntity<LLVMTypeRef>
    {
        protected readonly string value;

        public Type(string value)
        {
            this.value = value;
        }

        public LLVMTypeRef Emit()
        {
            return Resolvers.LlvmTypeFromName(this.value);
        }
    }
}