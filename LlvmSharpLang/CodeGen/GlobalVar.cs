using LLVMSharp;
using LlvmSharpLang.CodeGen.Structure;

namespace LlvmSharpLang.CodeGen
{
    public class GlobalVar : Named, IEntity<LLVMValueRef, LLVMModuleRef>
    {
        public Type Type { get; protected set; }

        public Expr Value { get; set; }

        public GlobalVar(Type type)
        {
            this.Type = type;
        }

        public LLVMValueRef Emit(LLVMModuleRef context)
        {
            // Create the global variable.
            LLVMValueRef globalVar = LLVM.AddGlobal(context, this.Type.Emit(), this.Name);

            // Set the linkage to common.
            globalVar.SetLinkage(LLVMLinkage.LLVMCommonLinkage);

            // Assign value if applicable.
            if (this.Value != null)
            {
                globalVar.SetInitializer(this.Value.Emit());
            }

            return globalVar;
        }
    }
}