using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using AutoMapper.Configuration;
using AutoMapper.Mappers.Internal;

namespace AutoMapper.QueryableExtensions.Impl
{
    public class EnumerableExpressionBinder : IExpressionBinder
    {
        public bool IsMatch(PropertyMap propertyMap, TypeMap propertyTypeMap, ExpressionResolutionResult result) =>
            propertyMap.DestinationType.IsEnumerableType() && propertyMap.SourceType.IsEnumerableType();

        public MemberAssignment Build(IConfigurationProvider configuration, PropertyMap propertyMap, TypeMap propertyTypeMap, ExpressionRequest request, ExpressionResolutionResult result, IDictionary<ExpressionRequest, int> typePairCount, LetPropertyMaps letPropertyMaps) 
            => BindEnumerableExpression(configuration, propertyMap, request, result, typePairCount, letPropertyMaps);

        private static MemberAssignment BindEnumerableExpression(IConfigurationProvider configuration, PropertyMap propertyMap, ExpressionRequest request, ExpressionResolutionResult result, IDictionary<ExpressionRequest, int> typePairCount, LetPropertyMaps letPropertyMaps)
        {
            var destinationListType = ElementTypeHelper.GetElementType(propertyMap.DestinationType);
            var sourceListType = ElementTypeHelper.GetElementType(propertyMap.SourceType);
            var expression = result.ResolutionExpression;

            if (sourceListType != destinationListType)
            {
                var listTypePair = new ExpressionRequest(sourceListType, destinationListType, request.MembersToExpand, request);
                var transformedExpressions = configuration.ExpressionBuilder.CreateMapExpression(listTypePair, typePairCount, letPropertyMaps.New());
                if(transformedExpressions == null)
                {
                    return null;
                }
                expression = transformedExpressions.Aggregate(expression, Select);
            }

            expression =
                propertyMap.DestinationType.IsArray
                    ? Expression.Call(typeof(Enumerable), nameof(Enumerable.ToArray), new[] {destinationListType}, expression) 
                    : propertyMap.DestinationType.IsCollectionType()
                        ? Expression.Call(typeof(Enumerable), nameof(Enumerable.ToList), new[] {destinationListType}, expression)
                        : expression;

            return Expression.Bind(propertyMap.DestinationMember, expression);
        }

        private static Expression Select(Expression source, LambdaExpression lambda)
        {
            return Expression.Call(typeof(Enumerable), nameof(Enumerable.Select), new[] { lambda.Parameters[0].Type, lambda.ReturnType }, source, lambda);
        }
    }
}