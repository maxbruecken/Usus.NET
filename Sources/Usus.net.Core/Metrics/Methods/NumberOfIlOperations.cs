using Mono.Cecil;
using Mono.Cecil.Cil;

namespace andrena.Usus.net.Core.Metrics.Methods
{
    internal static class NumberOfIlOperations
    {
        public static int Of(MethodDefinition method)
        {
            int num = 0;
            bool flag = false;
            foreach (var operation in method.Body.Instructions)
            {
                if (operation.OpCode.Code != Code.Ret)
                {
                    flag = true;
                }
                num += 1;
            }
            if (flag)
            {
                num = (int)System.Math.Max((double)num, 5.0);
            }
            return (int)System.Math.Round((double)(((double)num) / 5.0));
        }
    }
}
