using ICSharpCode.Decompiler.CSharp.Syntax;
using ICSharpCode.Decompiler.CSharp.Syntax.PatternMatching;

namespace andrena.Usus.net.Core.Metrics
{
    public abstract class AstVisitorBase : IAstVisitor
    {
        public virtual void VisitAnonymousMethodExpression(AnonymousMethodExpression anonymousMethodExpression)
        {
            VisitStatementAndChildren(anonymousMethodExpression);
        }

        protected virtual void VisitAstNode(AstNode node)
        {
        }

        protected void VisitStatementAndChildren(AstNode node)
        {

            foreach (var child in node.Children)
            {
                child.AcceptVisitor(this);
            }
        }

        public virtual void VisitAnonymousTypeCreateExpression(AnonymousTypeCreateExpression anonymousTypeCreateExpression)
        {
            VisitStatementAndChildren(anonymousTypeCreateExpression);
        }

        public virtual void VisitArrayCreateExpression(ArrayCreateExpression arrayCreateExpression)
        {
            VisitStatementAndChildren(arrayCreateExpression);
        }

        public virtual void VisitArrayInitializerExpression(ArrayInitializerExpression arrayInitializerExpression)
        {
            VisitStatementAndChildren(arrayInitializerExpression);
        }

        public virtual void VisitAsExpression(AsExpression asExpression)
        {
            VisitStatementAndChildren(asExpression);
        }

        public virtual void VisitAssignmentExpression(AssignmentExpression assignmentExpression)
        {
            VisitStatementAndChildren(assignmentExpression);
        }

        public virtual void VisitBaseReferenceExpression(BaseReferenceExpression baseReferenceExpression)
        {
            VisitStatementAndChildren(baseReferenceExpression);
        }

        public virtual void VisitBinaryOperatorExpression(BinaryOperatorExpression binaryOperatorExpression)
        {
            VisitStatementAndChildren(binaryOperatorExpression);
        }

        public virtual void VisitCastExpression(CastExpression castExpression)
        {
            VisitStatementAndChildren(castExpression);
        }

        public virtual void VisitCheckedExpression(CheckedExpression checkedExpression)
        {
            VisitStatementAndChildren(checkedExpression);
        }

        public virtual void VisitConditionalExpression(ConditionalExpression conditionalExpression)
        {
            VisitStatementAndChildren(conditionalExpression);
        }

        public virtual void VisitDefaultValueExpression(DefaultValueExpression defaultValueExpression)
        {
            VisitStatementAndChildren(defaultValueExpression);
        }

        public virtual void VisitDirectionExpression(DirectionExpression directionExpression)
        {
            VisitStatementAndChildren(directionExpression);
        }

        public virtual void VisitIdentifierExpression(IdentifierExpression identifierExpression)
        {
            VisitStatementAndChildren(identifierExpression);
        }

        public virtual void VisitIndexerExpression(IndexerExpression indexerExpression)
        {
            VisitStatementAndChildren(indexerExpression);
        }

        public virtual void VisitInvocationExpression(InvocationExpression invocationExpression)
        {
            VisitStatementAndChildren(invocationExpression);
        }

        public virtual void VisitIsExpression(IsExpression isExpression)
        {
            VisitStatementAndChildren(isExpression);
        }

        public virtual void VisitLambdaExpression(LambdaExpression lambdaExpression)
        {
            VisitStatementAndChildren(lambdaExpression);
        }

        public virtual void VisitMemberReferenceExpression(MemberReferenceExpression memberReferenceExpression)
        {
            VisitStatementAndChildren(memberReferenceExpression);
        }

        public virtual void VisitNamedArgumentExpression(NamedArgumentExpression namedArgumentExpression)
        {
            VisitStatementAndChildren(namedArgumentExpression);
        }

        public virtual void VisitNamedExpression(NamedExpression namedExpression)
        {
            VisitStatementAndChildren(namedExpression);
        }

        public virtual void VisitNullReferenceExpression(NullReferenceExpression nullReferenceExpression)
        {
            VisitStatementAndChildren(nullReferenceExpression);
        }

        public virtual void VisitObjectCreateExpression(ObjectCreateExpression objectCreateExpression)
        {
            VisitStatementAndChildren(objectCreateExpression);
        }

        public virtual void VisitOutVarDeclarationExpression(OutVarDeclarationExpression outVarDeclarationExpression)
        {
            VisitStatementAndChildren(outVarDeclarationExpression);
        }

        public virtual void VisitParenthesizedExpression(ParenthesizedExpression parenthesizedExpression)
        {
            VisitStatementAndChildren(parenthesizedExpression);
        }

        public virtual void VisitPointerReferenceExpression(PointerReferenceExpression pointerReferenceExpression)
        {
            VisitStatementAndChildren(pointerReferenceExpression);
        }

        public virtual void VisitPrimitiveExpression(PrimitiveExpression primitiveExpression)
        {
            VisitStatementAndChildren(primitiveExpression);
        }

        public virtual void VisitSizeOfExpression(SizeOfExpression sizeOfExpression)
        {
            VisitStatementAndChildren(sizeOfExpression);
        }

        public virtual void VisitStackAllocExpression(StackAllocExpression stackAllocExpression)
        {
            VisitStatementAndChildren(stackAllocExpression);
        }

        public virtual void VisitThisReferenceExpression(ThisReferenceExpression thisReferenceExpression)
        {
            VisitStatementAndChildren(thisReferenceExpression);
        }

        public virtual void VisitThrowExpression(ThrowExpression throwExpression)
        {
            VisitStatementAndChildren(throwExpression);
        }

        public virtual void VisitTypeOfExpression(TypeOfExpression typeOfExpression)
        {
            VisitStatementAndChildren(typeOfExpression);
        }

        public virtual void VisitTypeReferenceExpression(TypeReferenceExpression typeReferenceExpression)
        {
            VisitStatementAndChildren(typeReferenceExpression);
        }

        public virtual void VisitUnaryOperatorExpression(UnaryOperatorExpression unaryOperatorExpression)
        {
            VisitStatementAndChildren(unaryOperatorExpression);
        }

        public virtual void VisitUncheckedExpression(UncheckedExpression uncheckedExpression)
        {
            VisitStatementAndChildren(uncheckedExpression);
        }

        public virtual void VisitUndocumentedExpression(UndocumentedExpression undocumentedExpression)
        {
            VisitStatementAndChildren(undocumentedExpression);
        }

        public virtual void VisitQueryExpression(QueryExpression queryExpression)
        {
            VisitStatementAndChildren(queryExpression);
        }

        public virtual void VisitQueryContinuationClause(QueryContinuationClause queryContinuationClause)
        {
            VisitStatementAndChildren(queryContinuationClause);
        }

        public virtual void VisitQueryFromClause(QueryFromClause queryFromClause)
        {
            VisitStatementAndChildren(queryFromClause);
        }

        public virtual void VisitQueryLetClause(QueryLetClause queryLetClause)
        {
            VisitStatementAndChildren(queryLetClause);
        }

        public virtual void VisitQueryWhereClause(QueryWhereClause queryWhereClause)
        {
            VisitStatementAndChildren(queryWhereClause);
        }

        public virtual void VisitQueryJoinClause(QueryJoinClause queryJoinClause)
        {
            VisitStatementAndChildren(queryJoinClause);
        }

        public virtual void VisitQueryOrderClause(QueryOrderClause queryOrderClause)
        {
            VisitStatementAndChildren(queryOrderClause);
        }

        public virtual void VisitQueryOrdering(QueryOrdering queryOrdering)
        {
            VisitStatementAndChildren(queryOrdering);
        }

        public virtual void VisitQuerySelectClause(QuerySelectClause querySelectClause)
        {
            VisitStatementAndChildren(querySelectClause);
        }

        public virtual void VisitQueryGroupClause(QueryGroupClause queryGroupClause)
        {
            VisitStatementAndChildren(queryGroupClause);
        }

        public virtual void VisitAttribute(Attribute attribute)
        {
            VisitStatementAndChildren(attribute);
        }

        public virtual void VisitAttributeSection(AttributeSection attributeSection)
        {
            VisitStatementAndChildren(attributeSection);
        }

        public virtual void VisitDelegateDeclaration(DelegateDeclaration delegateDeclaration)
        {
            VisitStatementAndChildren(delegateDeclaration);
        }

        public virtual void VisitNamespaceDeclaration(NamespaceDeclaration namespaceDeclaration)
        {
            VisitStatementAndChildren(namespaceDeclaration);
        }

        public virtual void VisitTypeDeclaration(TypeDeclaration typeDeclaration)
        {
            VisitStatementAndChildren(typeDeclaration);
        }

        public virtual void VisitUsingAliasDeclaration(UsingAliasDeclaration usingAliasDeclaration)
        {
            VisitStatementAndChildren(usingAliasDeclaration);
        }

        public virtual void VisitUsingDeclaration(UsingDeclaration usingDeclaration)
        {
            VisitStatementAndChildren(usingDeclaration);
        }

        public virtual void VisitExternAliasDeclaration(ExternAliasDeclaration externAliasDeclaration)
        {
            VisitStatementAndChildren(externAliasDeclaration);
        }

        public virtual void VisitBlockStatement(BlockStatement blockStatement)
        {
            VisitStatementAndChildren(blockStatement);
        }

        public virtual void VisitBreakStatement(BreakStatement breakStatement)
        {
            VisitStatementAndChildren(breakStatement);
        }

        public virtual void VisitCheckedStatement(CheckedStatement checkedStatement)
        {
            VisitStatementAndChildren(checkedStatement);
        }

        public virtual void VisitContinueStatement(ContinueStatement continueStatement)
        {
            VisitStatementAndChildren(continueStatement);
        }

        public virtual void VisitDoWhileStatement(DoWhileStatement doWhileStatement)
        {
            VisitStatementAndChildren(doWhileStatement);
        }

        public virtual void VisitEmptyStatement(EmptyStatement emptyStatement)
        {
            VisitStatementAndChildren(emptyStatement);
        }

        public virtual void VisitExpressionStatement(ExpressionStatement expressionStatement)
        {
            VisitStatementAndChildren(expressionStatement);
        }

        public virtual void VisitFixedStatement(FixedStatement fixedStatement)
        {
            VisitStatementAndChildren(fixedStatement);
        }

        public virtual void VisitForeachStatement(ForeachStatement foreachStatement)
        {
            VisitStatementAndChildren(foreachStatement);
        }

        public virtual void VisitForStatement(ForStatement forStatement)
        {
            VisitStatementAndChildren(forStatement);
        }

        public virtual void VisitGotoCaseStatement(GotoCaseStatement gotoCaseStatement)
        {
            VisitStatementAndChildren(gotoCaseStatement);
        }

        public virtual void VisitGotoDefaultStatement(GotoDefaultStatement gotoDefaultStatement)
        {
            VisitStatementAndChildren(gotoDefaultStatement);
        }

        public virtual void VisitGotoStatement(GotoStatement gotoStatement)
        {
            VisitStatementAndChildren(gotoStatement);
        }

        public virtual void VisitIfElseStatement(IfElseStatement ifElseStatement)
        {
            VisitStatementAndChildren(ifElseStatement);
        }

        public virtual void VisitLabelStatement(LabelStatement labelStatement)
        {
            VisitStatementAndChildren(labelStatement);
        }

        public virtual void VisitLockStatement(LockStatement lockStatement)
        {
            VisitStatementAndChildren(lockStatement);
        }

        public virtual void VisitReturnStatement(ReturnStatement returnStatement)
        {
            VisitStatementAndChildren(returnStatement);
        }

        public virtual void VisitSwitchStatement(SwitchStatement switchStatement)
        {
            VisitStatementAndChildren(switchStatement);
        }

        public virtual void VisitSwitchSection(SwitchSection switchSection)
        {
            VisitStatementAndChildren(switchSection);
        }

        public virtual void VisitCaseLabel(CaseLabel caseLabel)
        {
            VisitStatementAndChildren(caseLabel);
        }

        public virtual void VisitThrowStatement(ThrowStatement throwStatement)
        {
            VisitStatementAndChildren(throwStatement);
        }

        public virtual void VisitTryCatchStatement(TryCatchStatement tryCatchStatement)
        {
            VisitStatementAndChildren(tryCatchStatement);
        }

        public virtual void VisitCatchClause(CatchClause catchClause)
        {
            VisitStatementAndChildren(catchClause);
        }

        public virtual void VisitUncheckedStatement(UncheckedStatement uncheckedStatement)
        {
            VisitStatementAndChildren(uncheckedStatement);
        }

        public virtual void VisitUnsafeStatement(UnsafeStatement unsafeStatement)
        {
            VisitStatementAndChildren(unsafeStatement);
        }

        public virtual void VisitUsingStatement(UsingStatement usingStatement)
        {
            VisitStatementAndChildren(usingStatement);
        }

        public virtual void VisitVariableDeclarationStatement(VariableDeclarationStatement variableDeclarationStatement)
        {
            VisitStatementAndChildren(variableDeclarationStatement);
        }

        public virtual void VisitWhileStatement(WhileStatement whileStatement)
        {
            VisitStatementAndChildren(whileStatement);
        }

        public virtual void VisitYieldBreakStatement(YieldBreakStatement yieldBreakStatement)
        {
            VisitStatementAndChildren(yieldBreakStatement);
        }

        public virtual void VisitYieldReturnStatement(YieldReturnStatement yieldReturnStatement)
        {
            VisitStatementAndChildren(yieldReturnStatement);
        }

        public virtual void VisitAccessor(Accessor accessor)
        {
            VisitStatementAndChildren(accessor);
        }

        public virtual void VisitConstructorDeclaration(ConstructorDeclaration constructorDeclaration)
        {
            VisitStatementAndChildren(constructorDeclaration);
        }

        public virtual void VisitConstructorInitializer(ConstructorInitializer constructorInitializer)
        {
            VisitStatementAndChildren(constructorInitializer);
        }

        public virtual void VisitDestructorDeclaration(DestructorDeclaration destructorDeclaration)
        {
            VisitStatementAndChildren(destructorDeclaration);
        }

        public virtual void VisitEnumMemberDeclaration(EnumMemberDeclaration enumMemberDeclaration)
        {
            VisitStatementAndChildren(enumMemberDeclaration);
        }

        public virtual void VisitEventDeclaration(EventDeclaration eventDeclaration)
        {
            VisitStatementAndChildren(eventDeclaration);
        }

        public virtual void VisitCustomEventDeclaration(CustomEventDeclaration customEventDeclaration)
        {
            VisitStatementAndChildren(customEventDeclaration);
        }

        public virtual void VisitFieldDeclaration(FieldDeclaration fieldDeclaration)
        {
            VisitStatementAndChildren(fieldDeclaration);
        }

        public virtual void VisitIndexerDeclaration(IndexerDeclaration indexerDeclaration)
        {
            VisitStatementAndChildren(indexerDeclaration);
        }

        public virtual void VisitMethodDeclaration(MethodDeclaration methodDeclaration)
        {
            VisitStatementAndChildren(methodDeclaration);
        }

        public virtual void VisitOperatorDeclaration(OperatorDeclaration operatorDeclaration)
        {
            VisitStatementAndChildren(operatorDeclaration);
        }

        public virtual void VisitParameterDeclaration(ParameterDeclaration parameterDeclaration)
        {
            VisitStatementAndChildren(parameterDeclaration);
        }

        public virtual void VisitPropertyDeclaration(PropertyDeclaration propertyDeclaration)
        {
            VisitStatementAndChildren(propertyDeclaration);
        }

        public virtual void VisitVariableInitializer(VariableInitializer variableInitializer)
        {
            VisitStatementAndChildren(variableInitializer);
        }

        public virtual void VisitFixedFieldDeclaration(FixedFieldDeclaration fixedFieldDeclaration)
        {
            VisitStatementAndChildren(fixedFieldDeclaration);
        }

        public virtual void VisitFixedVariableInitializer(FixedVariableInitializer fixedVariableInitializer)
        {
            VisitStatementAndChildren(fixedVariableInitializer);
        }

        public virtual void VisitSyntaxTree(SyntaxTree syntaxTree)
        {
            VisitStatementAndChildren(syntaxTree);
        }

        public virtual void VisitSimpleType(SimpleType simpleType)
        {
            VisitStatementAndChildren(simpleType);
        }

        public virtual void VisitMemberType(MemberType memberType)
        {
            VisitStatementAndChildren(memberType);
        }

        public virtual void VisitComposedType(ComposedType composedType)
        {
            VisitStatementAndChildren(composedType);
        }

        public virtual void VisitArraySpecifier(ArraySpecifier arraySpecifier)
        {
            VisitStatementAndChildren(arraySpecifier);
        }

        public virtual void VisitPrimitiveType(PrimitiveType primitiveType)
        {
            VisitStatementAndChildren(primitiveType);
        }

        public virtual void VisitComment(Comment comment)
        {
            VisitStatementAndChildren(comment);
        }

        public virtual void VisitNewLine(NewLineNode newLineNode)
        {
            VisitStatementAndChildren(newLineNode);
        }

        public virtual void VisitWhitespace(WhitespaceNode whitespaceNode)
        {
            VisitStatementAndChildren(whitespaceNode);
        }

        public virtual void VisitText(TextNode textNode)
        {
            VisitStatementAndChildren(textNode);
        }

        public virtual void VisitPreProcessorDirective(PreProcessorDirective preProcessorDirective)
        {
            VisitStatementAndChildren(preProcessorDirective);
        }

        public virtual void VisitDocumentationReference(DocumentationReference documentationReference)
        {
            VisitStatementAndChildren(documentationReference);
        }

        public virtual void VisitTypeParameterDeclaration(TypeParameterDeclaration typeParameterDeclaration)
        {
            VisitStatementAndChildren(typeParameterDeclaration);
        }

        public virtual void VisitConstraint(Constraint constraint)
        {
            VisitStatementAndChildren(constraint);
        }

        public virtual void VisitCSharpTokenNode(CSharpTokenNode cSharpTokenNode)
        {
            VisitStatementAndChildren(cSharpTokenNode);
        }

        public virtual void VisitIdentifier(Identifier identifier)
        {
            VisitStatementAndChildren(identifier);
        }

        public virtual void VisitNullNode(AstNode nullNode)
        {
            VisitStatementAndChildren(nullNode);
        }

        public virtual void VisitErrorNode(AstNode errorNode)
        {
            VisitStatementAndChildren(errorNode);
        }

        public virtual void VisitPatternPlaceholder(AstNode placeholder, Pattern pattern)
        {
            VisitStatementAndChildren(placeholder);
        }
    }
}
