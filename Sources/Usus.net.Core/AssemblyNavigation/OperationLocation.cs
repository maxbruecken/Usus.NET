using Mono.Cecil.Cil;

namespace andrena.Usus.net.Core.AssemblyNavigation
{
    internal class OperationLocation
    {
        public Instruction Operation { get; set; }
        public OpCode OperationCode
        {
            get { return Operation.OpCode; }
        }

        public IPrimarySourceLocation Location { get; set; }
        public bool IsValidLocation
        {
            get { return Location.Length != 0; }
        }
    }
}
