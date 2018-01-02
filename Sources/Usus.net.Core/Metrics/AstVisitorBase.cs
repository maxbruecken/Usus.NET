using ICSharpCode.Decompiler.CSharp.Syntax;
using ICSharpCode.Decompiler.CSharp.Syntax.PatternMatching;

namespace andrena.Usus.net.Core.Metrics
{
    public abstract class AstVisitorBase : IAstVisitor
    {
        public virtual void VisitAnonymousMethodExpression(AnonymousMethodExpression anonymousMethodExpression)
        {
            VisitNodeAndChildren(anonymousMethodExpression);
        }

	    private void VisitNodeAndChildren(AstNode node)
        {
			VisitAstNode(node);
            foreach (var child in node.Children)
            {
                child.AcceptVisitor(this);
            }
		}

	    protected virtual void VisitAstNode(AstNode node)
	    {
	    }

		public virtual void VisitAnonymousTypeCreateExpression(AnonymousTypeCreateExpression anonymousTypeCreateExpression)
        {
            VisitNodeAndChildren(anonymousTypeCreateExpression);
        }

        public virtual void VisitArrayCreateExpression(ArrayCreateExpression arrayCreateExpression)
        {
            VisitNodeAndChildren(arrayCreateExpression);
        }

        public virtual void VisitArrayInitializerExpression(ArrayInitializerExpression arrayInitializerExpression)
        {
            VisitNodeAndChildren(arrayInitializerExpression);
        }

        public virtual void VisitAsExpression(AsExpression asExpression)
        {
            VisitNodeAndChildren(asExpression);
        }

        public virtual void VisitAssignmentExpression(AssignmentExpression assignmentExpression)
        {
            VisitNodeAndChildren(assignmentExpression);
        }

        public virtual void VisitBaseReferenceExpression(BaseReferenceExpression baseReferenceExpression)
        {
            VisitNodeAndChildren(baseReferenceExpression);
        }

        public virtual void VisitBinaryOperatorExpression(BinaryOperatorExpression binaryOperatorExpression)
        {
            VisitNodeAndChildren(binaryOperatorExpression);
        }

        public virtual void VisitCastExpression(CastExpression castExpression)
        {
            VisitNodeAndChildren(castExpression);
        }

        public virtual void VisitCheckedExpression(CheckedExpression checkedExpression)
        {
            VisitNodeAndChildren(checkedExpression);
        }

        public virtual void VisitConditionalExpression(ConditionalExpression conditionalExpression)
        {
            VisitNodeAndChildren(conditionalExpression);
        }

        public virtual void VisitDefaultValueExpression(DefaultValueExpression defaultValueExpression)
        {
            VisitNodeAndChildren(defaultValueExpression);
        }

        public virtual void VisitDirectionExpression(DirectionExpression directionExpression)
        {
            VisitNodeAndChildren(directionExpression);
        }

        public virtual void VisitIdentifierExpression(IdentifierExpression identifierExpression)
        {
            VisitNodeAndChildren(identifierExpression);
        }

        public virtual void VisitIndexerExpression(IndexerExpression indexerExpression)
        {
            VisitNodeAndChildren(indexerExpression);
        }

        public virtual void VisitInvocationExpression(InvocationExpression invocationExpression)
        {
            VisitNodeAndChildren(invocationExpression);
        }

        public virtual void VisitIsExpression(IsExpression isExpression)
        {
            VisitNodeAndChildren(isExpression);
        }

        public virtual void VisitLambdaExpression(LambdaExpression lambdaExpression)
        {
            VisitNodeAndChildren(lambdaExpression);
        }

        public virtual void VisitMemberReferenceExpression(MemberReferenceExpression memberReferenceExpression)
        {
            VisitNodeAndChildren(memberReferenceExpression);
        }

        public virtual void VisitNamedArgumentExpression(NamedArgumentExpression namedArgumentExpression)
        {
            VisitNodeAndChildren(namedArgumentExpression);
        }

        public virtual void VisitNamedExpression(NamedExpression namedExpression)
        {
            VisitNodeAndChildren(namedExpression);
        }

        public virtual void VisitNullReferenceExpression(NullReferenceExpression nullReferenceExpression)
        {
            VisitNodeAndChildren(nullReferenceExpression);
        }

        public virtual void VisitObjectCreateExpression(ObjectCreateExpression objectCreateExpression)
        {
            VisitNodeAndChildren(objectCreateExpression);
        }

        public virtual void VisitOutVarDeclarationExpression(OutVarDeclarationExpression outVarDeclarationExpression)
        {
            VisitNodeAndChildren(outVarDeclarationExpression);
        }

        public virtual void VisitParenthesizedExpression(ParenthesizedExpression parenthesizedExpression)
        {
            VisitNodeAndChildren(parenthesizedExpression);
        }

        public virtual void VisitPointerReferenceExpression(PointerReferenceExpression pointerReferenceExpression)
        {
            VisitNodeAndChildren(pointerReferenceExpression);
        }

        public virtual void VisitPrimitiveExpression(PrimitiveExpression primitiveExpression)
        {
            VisitNodeAndChildren(primitiveExpression);
        }

        public virtual void VisitSizeOfExpression(SizeOfExpression sizeOfExpression)
        {
            VisitNodeAndChildren(sizeOfExpression);
        }

        public virtual void VisitStackAllocExpression(StackAllocExpression stackAllocExpression)
        {
            VisitNodeAndChildren(stackAllocExpression);
        }

        public virtual void VisitThisReferenceExpression(ThisReferenceExpression thisReferenceExpression)
        {
            VisitNodeAndChildren(thisReferenceExpression);
        }

        public virtual void VisitThrowExpression(ThrowExpression throwExpression)
        {
            VisitNodeAndChildren(throwExpression);
        }

        public virtual void VisitTypeOfExpression(TypeOfExpression typeOfExpression)
        {
            VisitNodeAndChildren(typeOfExpression);
        }

        public virtual void VisitTypeReferenceExpression(TypeReferenceExpression typeReferenceExpression)
        {
            VisitNodeAndChildren(typeReferenceExpression);
        }

        public virtual void VisitUnaryOperatorExpression(UnaryOperatorExpression unaryOperatorExpression)
        {
            VisitNodeAndChildren(unaryOperatorExpression);
        }

        public virtual void VisitUncheckedExpression(UncheckedExpression uncheckedExpression)
        {
            VisitNodeAndChildren(uncheckedExpression);
        }

        public virtual void VisitUndocumentedExpression(UndocumentedExpression undocumentedExpression)
        {
            VisitNodeAndChildren(undocumentedExpression);
        }

        public virtual void VisitQueryExpression(QueryExpression queryExpression)
        {
            VisitNodeAndChildren(queryExpression);
        }

        public virtual void VisitQueryContinuationClause(QueryContinuationClause queryContinuationClause)
        {
            VisitNodeAndChildren(queryContinuationClause);
        }

        public virtual void VisitQueryFromClause(QueryFromClause queryFromClause)
        {
            VisitNodeAndChildren(queryFromClause);
        }

        public virtual void VisitQueryLetClause(QueryLetClause queryLetClause)
        {
            VisitNodeAndChildren(queryLetClause);
        }

        public virtual void VisitQueryWhereClause(QueryWhereClause queryWhereClause)
        {
            VisitNodeAndChildren(queryWhereClause);
        }

        public virtual void VisitQueryJoinClause(QueryJoinClause queryJoinClause)
        {
            VisitNodeAndChildren(queryJoinClause);
        }

        public virtual void VisitQueryOrderClause(QueryOrderClause queryOrderClause)
        {
            VisitNodeAndChildren(queryOrderClause);
        }

        public virtual void VisitQueryOrdering(QueryOrdering queryOrdering)
        {
            VisitNodeAndChildren(queryOrdering);
        }

        public virtual void VisitQuerySelectClause(QuerySelectClause querySelectClause)
        {
            VisitNodeAndChildren(querySelectClause);
        }

        public virtual void VisitQueryGroupClause(QueryGroupClause queryGroupClause)
        {
            VisitNodeAndChildren(queryGroupClause);
        }

        public virtual void VisitAttribute(Attribute attribute)
        {
            VisitNodeAndChildren(attribute);
        }

        public virtual void VisitAttributeSection(AttributeSection attributeSection)
        {
            VisitNodeAndChildren(attributeSection);
        }

        public virtual void VisitDelegateDeclaration(DelegateDeclaration delegateDeclaration)
        {
            VisitNodeAndChildren(delegateDeclaration);
        }

        public virtual void VisitNamespaceDeclaration(NamespaceDeclaration namespaceDeclaration)
        {
            VisitNodeAndChildren(namespaceDeclaration);
        }

        public virtual void VisitTypeDeclaration(TypeDeclaration typeDeclaration)
        {
            VisitNodeAndChildren(typeDeclaration);
        }

        public virtual void VisitUsingAliasDeclaration(UsingAliasDeclaration usingAliasDeclaration)
        {
            VisitNodeAndChildren(usingAliasDeclaration);
        }

        public virtual void VisitUsingDeclaration(UsingDeclaration usingDeclaration)
        {
            VisitNodeAndChildren(usingDeclaration);
        }

        public virtual void VisitExternAliasDeclaration(ExternAliasDeclaration externAliasDeclaration)
        {
            VisitNodeAndChildren(externAliasDeclaration);
        }

        public virtual void VisitBlockStatement(BlockStatement blockStatement)
        {
            VisitNodeAndChildren(blockStatement);
        }

        public virtual void VisitBreakStatement(BreakStatement breakStatement)
        {
            VisitNodeAndChildren(breakStatement);
        }

        public virtual void VisitCheckedStatement(CheckedStatement checkedStatement)
        {
            VisitNodeAndChildren(checkedStatement);
        }

        public virtual void VisitContinueStatement(ContinueStatement continueStatement)
        {
            VisitNodeAndChildren(continueStatement);
        }

        public virtual void VisitDoWhileStatement(DoWhileStatement doWhileStatement)
        {
            VisitNodeAndChildren(doWhileStatement);
        }

        public virtual void VisitEmptyStatement(EmptyStatement emptyStatement)
        {
            VisitNodeAndChildren(emptyStatement);
        }

        public virtual void VisitExpressionStatement(ExpressionStatement expressionStatement)
        {
            VisitNodeAndChildren(expressionStatement);
        }

        public virtual void VisitFixedStatement(FixedStatement fixedStatement)
        {
            VisitNodeAndChildren(fixedStatement);
        }

        public virtual void VisitForeachStatement(ForeachStatement foreachStatement)
        {
            VisitNodeAndChildren(foreachStatement);
        }

        public virtual void VisitForStatement(ForStatement forStatement)
        {
            VisitNodeAndChildren(forStatement);
        }

        public virtual void VisitGotoCaseStatement(GotoCaseStatement gotoCaseStatement)
        {
            VisitNodeAndChildren(gotoCaseStatement);
        }

        public virtual void VisitGotoDefaultStatement(GotoDefaultStatement gotoDefaultStatement)
        {
            VisitNodeAndChildren(gotoDefaultStatement);
        }

        public virtual void VisitGotoStatement(GotoStatement gotoStatement)
        {
            VisitNodeAndChildren(gotoStatement);
        }

        public virtual void VisitIfElseStatement(IfElseStatement ifElseStatement)
        {
            VisitNodeAndChildren(ifElseStatement);
        }

        public virtual void VisitLabelStatement(LabelStatement labelStatement)
        {
            VisitNodeAndChildren(labelStatement);
        }

        public virtual void VisitLockStatement(LockStatement lockStatement)
        {
            VisitNodeAndChildren(lockStatement);
        }

        public virtual void VisitReturnStatement(ReturnStatement returnStatement)
        {
            VisitNodeAndChildren(returnStatement);
        }

        public virtual void VisitSwitchStatement(SwitchStatement switchStatement)
        {
            VisitNodeAndChildren(switchStatement);
        }

        public virtual void VisitSwitchSection(SwitchSection switchSection)
        {
            VisitNodeAndChildren(switchSection);
        }

        public virtual void VisitCaseLabel(CaseLabel caseLabel)
        {
            VisitNodeAndChildren(caseLabel);
        }

        public virtual void VisitThrowStatement(ThrowStatement throwStatement)
        {
            VisitNodeAndChildren(throwStatement);
        }

        public virtual void VisitTryCatchStatement(TryCatchStatement tryCatchStatement)
        {
            VisitNodeAndChildren(tryCatchStatement);
        }

        public virtual void VisitCatchClause(CatchClause catchClause)
        {
            VisitNodeAndChildren(catchClause);
        }

        public virtual void VisitUncheckedStatement(UncheckedStatement uncheckedStatement)
        {
            VisitNodeAndChildren(uncheckedStatement);
        }

        public virtual void VisitUnsafeStatement(UnsafeStatement unsafeStatement)
        {
            VisitNodeAndChildren(unsafeStatement);
        }

        public virtual void VisitUsingStatement(UsingStatement usingStatement)
        {
            VisitNodeAndChildren(usingStatement);
        }

        public virtual void VisitVariableDeclarationStatement(VariableDeclarationStatement variableDeclarationStatement)
        {
            VisitNodeAndChildren(variableDeclarationStatement);
        }

        public virtual void VisitWhileStatement(WhileStatement whileStatement)
        {
            VisitNodeAndChildren(whileStatement);
        }

        public virtual void VisitYieldBreakStatement(YieldBreakStatement yieldBreakStatement)
        {
            VisitNodeAndChildren(yieldBreakStatement);
        }

        public virtual void VisitYieldReturnStatement(YieldReturnStatement yieldReturnStatement)
        {
            VisitNodeAndChildren(yieldReturnStatement);
        }

        public virtual void VisitAccessor(Accessor accessor)
        {
            VisitNodeAndChildren(accessor);
        }

        public virtual void VisitConstructorDeclaration(ConstructorDeclaration constructorDeclaration)
        {
            VisitNodeAndChildren(constructorDeclaration);
        }

        public virtual void VisitConstructorInitializer(ConstructorInitializer constructorInitializer)
        {
            VisitNodeAndChildren(constructorInitializer);
        }

        public virtual void VisitDestructorDeclaration(DestructorDeclaration destructorDeclaration)
        {
            VisitNodeAndChildren(destructorDeclaration);
        }

        public virtual void VisitEnumMemberDeclaration(EnumMemberDeclaration enumMemberDeclaration)
        {
            VisitNodeAndChildren(enumMemberDeclaration);
        }

        public virtual void VisitEventDeclaration(EventDeclaration eventDeclaration)
        {
            VisitNodeAndChildren(eventDeclaration);
        }

        public virtual void VisitCustomEventDeclaration(CustomEventDeclaration customEventDeclaration)
        {
            VisitNodeAndChildren(customEventDeclaration);
        }

        public virtual void VisitFieldDeclaration(FieldDeclaration fieldDeclaration)
        {
            VisitNodeAndChildren(fieldDeclaration);
        }

        public virtual void VisitIndexerDeclaration(IndexerDeclaration indexerDeclaration)
        {
            VisitNodeAndChildren(indexerDeclaration);
        }

        public virtual void VisitMethodDeclaration(MethodDeclaration methodDeclaration)
        {
            VisitNodeAndChildren(methodDeclaration);
        }

        public virtual void VisitOperatorDeclaration(OperatorDeclaration operatorDeclaration)
        {
            VisitNodeAndChildren(operatorDeclaration);
        }

        public virtual void VisitParameterDeclaration(ParameterDeclaration parameterDeclaration)
        {
            VisitNodeAndChildren(parameterDeclaration);
        }

        public virtual void VisitPropertyDeclaration(PropertyDeclaration propertyDeclaration)
        {
            VisitNodeAndChildren(propertyDeclaration);
        }

        public virtual void VisitVariableInitializer(VariableInitializer variableInitializer)
        {
            VisitNodeAndChildren(variableInitializer);
        }

        public virtual void VisitFixedFieldDeclaration(FixedFieldDeclaration fixedFieldDeclaration)
        {
            VisitNodeAndChildren(fixedFieldDeclaration);
        }

        public virtual void VisitFixedVariableInitializer(FixedVariableInitializer fixedVariableInitializer)
        {
            VisitNodeAndChildren(fixedVariableInitializer);
        }

        public virtual void VisitSyntaxTree(SyntaxTree syntaxTree)
        {
            VisitNodeAndChildren(syntaxTree);
        }

        public virtual void VisitSimpleType(SimpleType simpleType)
        {
            VisitNodeAndChildren(simpleType);
        }

        public virtual void VisitMemberType(MemberType memberType)
        {
            VisitNodeAndChildren(memberType);
        }

        public virtual void VisitComposedType(ComposedType composedType)
        {
            VisitNodeAndChildren(composedType);
        }

        public virtual void VisitArraySpecifier(ArraySpecifier arraySpecifier)
        {
            VisitNodeAndChildren(arraySpecifier);
        }

        public virtual void VisitPrimitiveType(PrimitiveType primitiveType)
        {
            VisitNodeAndChildren(primitiveType);
        }

        public virtual void VisitComment(Comment comment)
        {
            VisitNodeAndChildren(comment);
        }

        public virtual void VisitNewLine(NewLineNode newLineNode)
        {
            VisitNodeAndChildren(newLineNode);
        }

        public virtual void VisitWhitespace(WhitespaceNode whitespaceNode)
        {
            VisitNodeAndChildren(whitespaceNode);
        }

        public virtual void VisitText(TextNode textNode)
        {
            VisitNodeAndChildren(textNode);
        }

        public virtual void VisitPreProcessorDirective(PreProcessorDirective preProcessorDirective)
        {
            VisitNodeAndChildren(preProcessorDirective);
        }

        public virtual void VisitDocumentationReference(DocumentationReference documentationReference)
        {
            VisitNodeAndChildren(documentationReference);
        }

        public virtual void VisitTypeParameterDeclaration(TypeParameterDeclaration typeParameterDeclaration)
        {
            VisitNodeAndChildren(typeParameterDeclaration);
        }

        public virtual void VisitConstraint(Constraint constraint)
        {
            VisitNodeAndChildren(constraint);
        }

        public virtual void VisitCSharpTokenNode(CSharpTokenNode cSharpTokenNode)
        {
            VisitNodeAndChildren(cSharpTokenNode);
        }

        public virtual void VisitIdentifier(Identifier identifier)
        {
            VisitNodeAndChildren(identifier);
        }

        public virtual void VisitNullNode(AstNode nullNode)
        {
            VisitNodeAndChildren(nullNode);
        }

        public virtual void VisitErrorNode(AstNode errorNode)
        {
            VisitNodeAndChildren(errorNode);
        }

        public virtual void VisitPatternPlaceholder(AstNode placeholder, Pattern pattern)
        {
            VisitNodeAndChildren(placeholder);
        }
    }
}
