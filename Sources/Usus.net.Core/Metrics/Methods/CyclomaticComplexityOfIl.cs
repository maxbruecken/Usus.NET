using System.Collections.Generic;
using System.Linq;
using Mono.Cecil;
using Mono.Cecil.Cil;

namespace andrena.Usus.net.Core.Metrics.Methods
{
    internal static class CyclomaticComplexityOfIl
    {
        public static int Of(MethodDefinition method)
        {
            int num = 1;
            num += method.Body.ExceptionHandlers.Count(e => e.HandlerType == ExceptionHandlerType.Catch);
            
            foreach (var operation in method.Body.Instructions)
            {
                switch (operation.OpCode.Code)
                {
                    case Code.Brfalse_S:
                    case Code.Brtrue_S:
                    case Code.Beq_S:
                    case Code.Bge_S:
                    case Code.Bgt_S:
                    case Code.Ble_S:
                    case Code.Blt_S:
                    case Code.Bne_Un_S:
                    case Code.Bge_Un_S:
                    case Code.Bgt_Un_S:
                    case Code.Ble_Un_S:
                    case Code.Blt_Un_S:
                    case Code.Brfalse:
                    case Code.Brtrue:
                    case Code.Beq:
                    case Code.Bge:
                    case Code.Bgt:
                    case Code.Ble:
                    case Code.Blt:
                    case Code.Bne_Un:
                    case Code.Bge_Un:
                    case Code.Bgt_Un:
                    case Code.Ble_Un:
                    case Code.Blt_Un:
                    case (Code)0xfefc:
                    case (Code)0xfefe:
                        num++;
                        break;

                    case Code.Switch:
                        {
                            IEnumerable<int> enumerable = (IEnumerable<int>)operation.Operand;
                            HashSet<int> set = new HashSet<int>();
                            foreach (int num2 in enumerable)
                            {
                                set.Add(num2);
                            }
                            num += set.Count;
                            break;
                        }
                }
            }
            return num;
        }
    }
}
