using ICSharpCode.Decompiler.CSharp;
using ICSharpCode.Decompiler.CSharp.Syntax;
using Mono.Cecil;

namespace andrena.Usus.net.Core.Metrics.Methods
{
    internal class CyclomaticComplexityCalculator : AstVisitorBase
    {
        private readonly CSharpDecompiler _decompiler;

        public int Result { get; private set; }

        public CyclomaticComplexityCalculator(CSharpDecompiler decompiler)
        {
            _decompiler = decompiler;
            Result = 1;
        }

        public void Calculate(MethodDefinition method)
        {
            _decompiler.Decompile(method).AcceptVisitor(this);
        }

        public override void VisitIfElseStatement(IfElseStatement ifElseStatement)
        {
            Result++;
            VisitStatementAndChildren(ifElseStatement);
        }

        public override void VisitConditionalExpression(ConditionalExpression conditionalExpression)
        {
            Result++;
            VisitStatementAndChildren(conditionalExpression);
        }

        public override void VisitBinaryOperatorExpression(BinaryOperatorExpression binaryOperatorExpression)
        {
            if (binaryOperatorExpression.Operator == BinaryOperatorType.BitwiseAnd || binaryOperatorExpression.Operator == BinaryOperatorType.BitwiseOr)
                Result++;
            if (binaryOperatorExpression.Operator == BinaryOperatorType.ConditionalAnd || binaryOperatorExpression.Operator == BinaryOperatorType.ConditionalOr)
                Result++;
            VisitStatementAndChildren(binaryOperatorExpression);
        }

        public override void VisitWhileStatement(WhileStatement whileStatement)
        {
            Result++;
            VisitStatementAndChildren(whileStatement);
        }

        public override void VisitDoWhileStatement(DoWhileStatement doWhileStatement)
        {
            Result++;
            VisitStatementAndChildren(doWhileStatement);
        }

        public override void VisitForStatement(ForStatement forStatement)
        {
            Result++;
            VisitStatementAndChildren(forStatement);
        }

        public override void VisitForeachStatement(ForeachStatement foreachStatement)
        {
            Result++;
            VisitStatementAndChildren(foreachStatement);
        }

        public override void VisitCatchClause(CatchClause catchClause)
        {
            Result++;
            VisitStatementAndChildren(catchClause);
        }

        public override void VisitCaseLabel(CaseLabel caseLabel)
        {
            if (!caseLabel.Expression.IsNull)
                Result++;
            VisitStatementAndChildren(caseLabel);
        }
    }
}
