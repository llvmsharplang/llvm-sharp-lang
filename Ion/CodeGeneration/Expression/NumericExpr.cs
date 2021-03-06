using Ion.CodeGeneration.Helpers;
using Ion.CognitiveServices;
using Ion.SyntaxAnalysis;
using LLVMSharp;

namespace Ion.CodeGeneration
{
    public class NumericExpr : Expr
    {
        public override ExprType ExprType => ExprType.Numeric;

        public readonly TokenType tokenType;

        public readonly PrimitiveType type;

        public readonly string value;

        public NumericExpr(TokenType tokenType, PrimitiveType type, string value)
        {
            this.tokenType = tokenType;
            this.type = type;
            this.value = value;
        }

        public override LLVMValueRef Emit(PipeContext<LLVMBuilderRef> context)
        {
            // Emit the value.
            LLVMValueRef valueRef = Resolvers.Literal(this.tokenType, this.value, this.type);

            // Return the emitted value.
            return valueRef;
        }
    }
}
