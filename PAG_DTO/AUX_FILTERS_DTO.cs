using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Agregadas por DSA

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

//Agregadas por DSA: Build Where Clause Dynamically in Linq

using System.Reflection;
using System.Linq.Expressions;

//Fuente: http://www.codeproject.com/Tips/582450/Build-Where-Clause-Dynamically-in-Linq

namespace PAG_DTO
{
    #region VERSION-2.0-FILTERS
    public abstract class ExpressionBuilder<T>
    {
        private Expression<Func<T, bool>> expression = defaultExpression => true;
        public Expression<Func<T, bool>> GetExpression(T d) { build(d); return expression; }
        public abstract void build(T da);
        protected void and(Expression<Func<T, bool>> left) { expression = expression.AndAlso(left); hasFilters = true; }
        public bool hasFilters { get; set; }
    }

    public static class ExtensionLinq
    {
        public static Expression<Func<T, bool>> AndAlso<T>(this Expression<Func<T, bool>> expr1, Expression<Func<T, bool>> expr2)
        {
            var parameter = Expression.Parameter(typeof(T));

            var leftVisitor = new ReplaceExpressionVisitor(expr1.Parameters[0], parameter);
            var left = leftVisitor.Visit(expr1.Body);

            var rightVisitor = new ReplaceExpressionVisitor(expr2.Parameters[0], parameter);
            var right = rightVisitor.Visit(expr2.Body);

            return Expression.Lambda<Func<T, bool>>(Expression.AndAlso(left, right), parameter);
        }

        private class ReplaceExpressionVisitor : ExpressionVisitor
        {
            private readonly Expression _oldValue;
            private readonly Expression _newValue;
            public ReplaceExpressionVisitor(Expression oldValue, Expression newValue)
            {
                _oldValue = oldValue;
                _newValue = newValue;
            }
            public override Expression Visit(Expression node)
            {
                if (node == _oldValue) return _newValue;
                return base.Visit(node);
            }
        }
    }
    #endregion

    #region VERSION-1.0-FILTERS
    /// <summary>
    /// Clase DTO para los Filtros Dinamicos ExpressionBuilder
    /// </summary>
    /// <history>
    /// FECHA               REPONSABLE              DESCRIPCION
    /// 01/Nov/2015         Danny Lainez            Implementacion de Clase
    /// </history>
    public class AUX_FILTERS_DTO
    {
    }

    public class Filter
    {
        public string PROPERTYNAME { get; set; }
        public Op OPERATION { get; set; }
        public object VALUE { get; set; }
    }

    public enum Op
    {
        Equals,
        GreaterThan,
        LessThan,
        GreaterThanOrEqual,
        LessThanOrEqual,
        Contains,
        StartsWith,
        EndsWith,
        NotEquals,
    }
    public static class ExpressionBuilder
    {
        private static MethodInfo containsMethod = typeof(string).GetMethod("Contains");
        private static MethodInfo startsWithMethod = typeof(string).GetMethod("StartsWith", new Type[] { typeof(string) });
        private static MethodInfo endsWithMethod = typeof(string).GetMethod("EndsWith", new Type[] { typeof(string) });

        public static Expression<Func<T,bool>> GetExpression<T>(IList<Filter> filters)
        {
            if (filters.Count == 0)
                return null;

            ParameterExpression param = Expression.Parameter(typeof(T), "t");
            Expression exp = null;

            if (filters.Count == 1)
                exp = GetExpression<T>(param, filters[0]);
            else if (filters.Count == 2)
                exp = GetExpression<T>(param, filters[0], filters[1]);
            else
            {
                while (filters.Count > 0)
                {
                    var f1 = filters[0];
                    var f2 = filters[1];

                    if (exp == null)
                        exp = GetExpression<T>(param, filters[0], filters[1]);
                    else
                        exp = Expression.AndAlso(exp, GetExpression<T>(param, filters[0], filters[1]));

                    filters.Remove(f1);
                    filters.Remove(f2);

                    if (filters.Count == 1)
                    {
                        exp = Expression.AndAlso(exp, GetExpression<T>(param, filters[0]));
                        filters.RemoveAt(0);
                    }
                }
            }

            return Expression.Lambda<Func<T, bool>>(exp, param);
        }

        private static Expression GetExpression<T>(ParameterExpression param, Filter filter)
        {
            MemberExpression member = Expression.Property(param, filter.PROPERTYNAME);
            ConstantExpression constant = Expression.Constant(filter.VALUE);

            switch (filter.OPERATION)
            {
                case Op.Equals:
                    return Expression.Equal(member, constant);

                case Op.GreaterThan:
                    return Expression.GreaterThan(member, constant);

                case Op.GreaterThanOrEqual:
                    return Expression.GreaterThanOrEqual(member, constant);

                case Op.LessThan:
                    return Expression.LessThan(member, constant);

                case Op.LessThanOrEqual:
                    return Expression.LessThanOrEqual(member, constant);

                case Op.Contains:
                    return Expression.Call(member, containsMethod, constant);

                case Op.StartsWith:
                    return Expression.Call(member, startsWithMethod, constant);

                case Op.EndsWith:
                    return Expression.Call(member, endsWithMethod, constant);
                
                case Op.NotEquals:
                    return Expression.NotEqual(member, constant);
            }

            return null;
        }

        private static BinaryExpression GetExpression<T>
        (ParameterExpression param, Filter filter1, Filter filter2)
        {
            Expression bin1 = GetExpression<T>(param, filter1);
            Expression bin2 = GetExpression<T>(param, filter2);

            return Expression.AndAlso(bin1, bin2);
        }
    }
    #endregion
}
