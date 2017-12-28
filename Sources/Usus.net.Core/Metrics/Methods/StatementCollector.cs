using System.Collections.Generic;
using ICSharpCode.Decompiler.CSharp;
using ICSharpCode.Decompiler.CSharp.Syntax;
using Mono.Cecil;

namespace andrena.Usus.net.Core.Metrics.Methods
{
    internal class StatementCollector : AstVisitorBase
    {
        private readonly CSharpDecompiler _decompiler;
        private readonly bool _requireLocations;
        private readonly List<AstNode> _statements;

        public int ResultCount => _statements.Count;

        public StatementCollector(CSharpDecompiler decompiler)
        {
            _decompiler = decompiler;
            _statements = new List<AstNode>();
            _requireLocations = decompiler != null;
        }

        public void Collect(MethodDefinition method)
        {
            _decompiler?.Decompile(method).AcceptVisitor(this);
        }

        protected override void VisitAstNode(AstNode node)
        {
            if (node is EmptyStatement) return;
            if (node is ReturnStatement && (node as ReturnStatement).Expression == null) return;

            RememberStatement(node);
        }

        private void RememberStatement(AstNode node)
        {
            if (_requireLocations)
                RememberStatementWithLocation(node);
            else
                RememberStatementWithoutLocation(node);
        }

        private void RememberStatementWithLocation(AstNode node)
        {
            if (HasLocation(node) || IsConditional(node) || IsDeclaration(node))
                _statements.Add(node);
        }

        private void RememberStatementWithoutLocation(AstNode node)
        {
            if (IsNotBlock(node))
                _statements.Add(node);
        }

        private bool IsNotBlock(AstNode node)
        {
            return !(node is BlockStatement);
        }

        private bool HasLocation(AstNode node)
        {
            return !node.StartLocation.IsEmpty;
        }

        private bool IsConditional(AstNode node)
        {
            return node is ConditionalExpression;
        }

        private bool IsDeclaration(AstNode node)
        {
            var declaration = node as VariableInitializer;
            return declaration?.Initializer != null;
        }
    }
}
