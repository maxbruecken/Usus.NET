using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using andrena.Usus.net.Core.Helper;
using andrena.Usus.net.Core.Helper.Reflection;
using ICSharpCode.Decompiler.CSharp.Syntax;
using Mono.Cecil;
using Mono.Cecil.Cil;

namespace andrena.Usus.net.Core.AssemblyNavigation
{
    internal static class MethodExtensions
    {
        public static string Signature(this MethodDefinition method)
        {
            var fullName = Normalize.FullMethodName(method.ToString());
            if (method.HasGenericParameters)
            {
                fullName = fullName.Insert(fullName.LastIndexOf("(", StringComparison.InvariantCulture), $"<{string.Join(",", method.GenericParameters.Select(p => p.Name))}>");
            }
            if (method.Parameters.Any(p => p.IsOut) || method.Parameters.Any(p => p.ParameterType.IsByReference))
            {
                fullName = fullName.Replace("&", "");
            }
            if (method.ReturnType.IsGenericInstance || method.Parameters.Any(p => p.ParameterType.IsGenericInstance))
            {
                fullName = fullName.ReplaceRegex("`\\d+", "");
            }
            return fullName;
        }

        public static string Name(this MethodDefinition method)
        {
            return method.Name;
        }

        public static bool IsOnlyDeclaration(this MethodDefinition method)
        {
            return method.IsAbstract;
        }

        public static bool HasOperations(this MethodDefinition method)
        {
            return method.HasBody && method.Body.Instructions.Any();
        }

        public static bool IsDefaultCtor(this MethodDefinition method)
        {
            return method.FullName.EndsWith(".ctor()");
        }

        public static IEnumerable<Instruction> Operations(this MethodDefinition method,
            Func<OpCode, bool> predicate)
        {
            if (!method.HasBody) return Enumerable.Empty<Instruction>();
            return from o in method.Body.Instructions
                   where predicate(o.OpCode)
                   select o;
        }

        public static IEnumerable<string> TypesOfOperations(this MethodDefinition method,
           Func<OpCode, bool> predicate,
           Func<Instruction, IEnumerable<TypeReference>> selector)
        {
            return from o in method.Operations(predicate)
                   from t in selector(o)
                   from rt in t.GetAllRealTypeReferences()
                   select rt.GetFullName();
        }

        public static IEnumerable<OperationLocation> LocatedOperations(this MethodDefinition method)
        {
            if (!method.HasBody) return Enumerable.Empty<OperationLocation>();
            return (from o in method.Body.Instructions
                    from l in o.GetLocations(method)
                    select new OperationLocation { Operation = o, Location = l }).ToList();
        }

        private static IEnumerable<TextLocation> GetLocations(this Instruction instruction, MethodDefinition method)
        {
            if (!method.DebugInformation.HasSequencePoints)
                return new [] {TextLocation.Empty};

            var sequencePoint = method.DebugInformation.GetSequencePoint(instruction);
            if (sequencePoint == null)
                return new[] { TextLocation.Empty };
            return new[] { new TextLocation(sequencePoint.StartLine, sequencePoint.StartColumn) };
        }

        public static bool IsIterator(this MethodDefinition method)
        {
            return method.CustomAttributes.Any(a => a.AttributeType.FullName == typeof(IteratorStateMachineAttribute).FullName);
        }
    }
}
