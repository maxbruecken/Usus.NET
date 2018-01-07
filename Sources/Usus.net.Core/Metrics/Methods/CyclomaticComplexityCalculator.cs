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
            _decompiler?.Decompile(method).AcceptVisitor(this);
        }

        public override void VisitIfElseStatement(IfElseStatement ifElseStatement)
        {
            Result++;
            base.VisitIfElseStatement(ifElseStatement);
        }

        public override void VisitConditionalExpression(ConditionalExpression conditionalExpression)
        {
            Result++;
            base.VisitConditionalExpression(conditionalExpression);
        }

        public override void VisitBinaryOperatorExpression(BinaryOperatorExpression binaryOperatorExpression)
        {
            if (binaryOperatorExpression.Operator == BinaryOperatorType.BitwiseAnd || binaryOperatorExpression.Operator == BinaryOperatorType.BitwiseOr)
                Result++;
            if (binaryOperatorExpression.Operator == BinaryOperatorType.ConditionalAnd || binaryOperatorExpression.Operator == BinaryOperatorType.ConditionalOr)
                Result++;
            base.VisitBinaryOperatorExpression(binaryOperatorExpression);
        }

        public override void VisitWhileStatement(WhileStatement whileStatement)
        {
            Result++;
            base.VisitWhileStatement(whileStatement);
        }

        public override void VisitDoWhileStatement(DoWhileStatement doWhileStatement)
        {
            Result++;
            base.VisitDoWhileStatement(doWhileStatement);
        }

        public override void VisitForStatement(ForStatement forStatement)
        {
            Result++;
            base.VisitForStatement(forStatement);
        }

        public override void VisitForeachStatement(ForeachStatement foreachStatement)
        {
            Result++;
            base.VisitForeachStatement(foreachStatement);
        }

        public override void VisitCatchClause(CatchClause catchClause)
        {
            Result++;
            base.VisitCatchClause(catchClause);
        }

        public override void VisitCaseLabel(CaseLabel caseLabel)
        {
            if (!caseLabel.Expression.IsNull)
                Result++;
            base.VisitCaseLabel(caseLabel);
        }

	    public override void VisitQueryFromClause(QueryFromClause queryFromClause)
	    {
		    Result++;
		    base.VisitQueryFromClause(queryFromClause);
	    }
    }
}
