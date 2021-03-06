using System;
using Ion.CodeGeneration;
using Ion.CognitiveServices;
using Ion.Misc;
using Ion.SyntaxAnalysis;

namespace Ion.Parsing
{
    public class StringExprParser : IParser<StringExpr>
    {
        public StringExpr Parse(ParserContext context)
        {
            // Ensure current token is string literal.
            context.Stream.EnsureCurrent(SyntaxAnalysis.TokenType.LiteralString);

            // Capture string literal token.
            Token token = context.Stream.Current;

            // Skip string literal token.
            context.Stream.Skip();

            // Remove string quotes.
            string value = Util.ExtractStringLiteralValue(token);

            // Create the string expression entity.
            StringExpr stringExpr = new StringExpr(token.Type, value);

            // Return the string expression entity.
            return stringExpr;
        }
    }
}
