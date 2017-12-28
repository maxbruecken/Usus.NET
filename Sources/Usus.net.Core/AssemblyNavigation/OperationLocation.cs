using ICSharpCode.Decompiler.CSharp.Syntax;
using Mono.Cecil.Cil;

namespace andrena.Usus.net.Core.AssemblyNavigation
{
    internal class OperationLocation
    {
        public Instruction Operation { get; set; }

        public OpCode OperationCode => Operation.OpCode;

        public TextLocation Location { get; set; }

        public bool IsValidLocation => !Location.IsEmpty;
    }
}
