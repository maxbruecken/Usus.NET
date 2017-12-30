using System.Collections.Generic;
using System.Linq;
using Mono.Cecil;

namespace andrena.Usus.net.Core.AssemblyNavigation
{
    internal static class TypeReferenceUnfold
    {
        public static IEnumerable<TypeReference> GetAllRealTypeReferences(this TypeReference typeReference)
        {
            if (typeReference is GenericInstanceType)
                return AnalyzeGenericTypeReference(typeReference as GenericInstanceType);
            else
                return AnalyzeNonGenericTypeReference(typeReference);
        }

        #region non generics
        private static IEnumerable<TypeReference> AnalyzeNonGenericTypeReference(TypeReference typeReference)
        {
            if (typeReference is ArrayType)
                return AnalyzeVectorTypeReference(typeReference);
            else
                return AnalyzeNonVectorTypeReference(typeReference);
        }

        private static IEnumerable<TypeReference> AnalyzeVectorTypeReference(TypeReference typeReference)
        {
            return (typeReference as ArrayType).ElementType.GetAllRealTypeReferences();
        }

        private static IEnumerable<TypeReference> AnalyzeNonVectorTypeReference(TypeReference typeReference)
        {
            yield return typeReference;
        } 
        #endregion

        #region generics
        private static IEnumerable<TypeReference> AnalyzeGenericTypeReference(GenericInstanceType typeReference)
        {
            return GetGenericType(typeReference)
                .Union(GetGenericTypeArguments(typeReference));
        }

        private static IEnumerable<TypeReference> GetGenericType(GenericInstanceType typeReference)
        {
            yield return typeReference;
        }

        private static IEnumerable<TypeReference> GetGenericTypeArguments(GenericInstanceType typeReference)
        {
            return from a in typeReference.GenericArguments
                   from t in a.GetAllRealTypeReferences()
                   select t;
        } 
        #endregion
    }
}
