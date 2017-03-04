using andrena.Usus.net.Core.AssemblyNavigation;
using Microsoft.Cci;

namespace andrena.Usus.net.Core.Metrics.Methods
{
    internal class CyclomaticComplexityCalculator : CodeTraverser
    {
        private readonly PdbReader _pdb;
        private readonly IMetadataHost _host;

        public int Result { get; private set; }

        public CyclomaticComplexityCalculator(PdbReader pdb, IMetadataHost host)
        {
            _pdb = pdb;
            _host = host;
            Result = 1;
        }

        public override void TraverseChildren(IBitwiseAnd bitwiseAnd)
        {
            Result++;
            base.TraverseChildren(bitwiseAnd);
        }

        public override void TraverseChildren(IBitwiseOr bitwiseOr)
        {
            Result++;
            base.TraverseChildren(bitwiseOr);
        }

        public override void TraverseChildren(IConditional conditional)
        {
            Result++;
            base.TraverseChildren(conditional);
        }

        public override void TraverseChildren(IConditionalStatement conditionalStatement)
        {
            Result++;
            base.TraverseChildren(conditionalStatement);
        }

        public override void TraverseChildren(IWhileDoStatement whileDoStatement)
        {
            Result++;
            base.TraverseChildren(whileDoStatement);
        }

        public override void TraverseChildren(IForStatement forStatement)
        {
            Result++;
            base.TraverseChildren(forStatement);
        }

        public override void TraverseChildren(IForEachStatement forEachStatement)
        {
            Result++;
            base.TraverseChildren(forEachStatement);
        }

        public override void TraverseChildren(ICatchClause catchClause)
        {
            Result++;
            base.TraverseChildren(catchClause);
        }

        public override void TraverseChildren(ISwitchCase switchCase)
        {
            if (!switchCase.IsDefault)
                Result++;
            base.TraverseChildren(switchCase);
        }

        public override void TraverseChildren(IYieldReturnStatement addition)
        {
            base.TraverseChildren(addition);
        }

        public override void TraverseChildren(ICreateObjectInstance createObjectInstance)
        {
            var methodBody = createObjectInstance.MethodToCall.ResolvedMethod.Decompile(_pdb, _host);
            //Traverse(methodBody.Statements());
            base.TraverseChildren(createObjectInstance);
        }
    }
}
