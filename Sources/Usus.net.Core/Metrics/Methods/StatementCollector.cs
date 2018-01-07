using System.Collections.Generic;
using ICSharpCode.Decompiler.CSharp;
using ICSharpCode.Decompiler.CSharp.Syntax;
using Mono.Cecil;

namespace andrena.Usus.net.Core.Metrics.Methods
{
    internal class StatementCollector : AstVisitorBase
    {
        private readonly CSharpDecompiler _decompiler;
        private readonly List<AstNode> _statements;

        public int ResultCount => _statements.Count;

        public StatementCollector(CSharpDecompiler decompiler)
        {
            _decompiler = decompiler;
            _statements = new List<AstNode>();
        }

        public void Collect(MethodDefinition method)
        {
            _decompiler?.Decompile(method).AcceptVisitor(this);
        }

        protected override void VisitAstNode(AstNode node)
        {
            if (node is EmptyStatement) return;

            RememberStatement(node);
        }

        private void RememberStatement(AstNode node)
        {
			if (IsNotBlock(node) && (node.NodeType == NodeType.Statement || node.NodeType == NodeType.QueryClause))
				_statements.Add(node);
		}

        private static bool IsNotBlock(AstNode node)
        {
            return !(node is BlockStatement);
        }
    }
}
