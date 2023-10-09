using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace SefinMvcHelpers.Helpers
{
    public class MetadataHelper
    {
        public PropertyInfo PropertyInfo { get; set; }
        public ModelMetadata ModelMetadata { get; set; }
        public Object LambdaExpression { get; set; }
    }
    public class MyTableHelper<T>
    {
        public MvcHtmlString TableForModel(ICollection<T> model)
        {
            StringBuilder body = new StringBuilder();
            body.Append("<table class='table table-hover'>");

            var modelType = typeof(T);
            var modelMetadataType = typeof(ModelMetadata);
            var getMetadata = modelMetadataType.GetMethod("FromLambdaExpression", BindingFlags.Static | BindingFlags.Public);
            var properties = modelType.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            var propsMetadata = new List<MetadataHelper>();

            body.Append("<thead>")
                    .Append("<tr>");
            foreach (var property in properties)
            {
                var lambda = BuildLambda(property, modelType);

                ModelMetadata metadata = (ModelMetadata)getMetadata.MakeGenericMethod(new[] { modelType, property.PropertyType }).Invoke(null, new[] { lambda, new ViewDataDictionary<T>() });
                propsMetadata.Add(new MetadataHelper() { PropertyInfo = property, ModelMetadata = metadata, LambdaExpression = lambda });
                body.Append(ThFor(metadata));
            }

            body.Append("</tr>")
            .Append("</thead>")
            .Append("<tbody>");
            foreach (T item in model)
            {
                body.Append("<tr>");
                foreach (MetadataHelper element in propsMetadata)
                {
                    body.AppendFormat("<td>{0}</td>",element.PropertyInfo.GetValue(item));
                }
                body.Append("</tr>");
            }
            body.Append("</tbody>");
            body.Append("</table>");
            return new MvcHtmlString(body.ToString());
        }

        private object BuildLambda(PropertyInfo prop, Type modelType)
        {
            var parameter = Expression.Parameter(modelType);
            var property = Expression.Property(parameter, prop);
            var funcType = typeof(Func<,>).MakeGenericType(modelType, property.Type);
            
            return Expression.Lambda(funcType, property, parameter);
        }
        private string ThFor(ModelMetadata metadata)
        {
            TagBuilder th = new TagBuilder(HtmlTextWriterTag.Th.ToString());
            
            th.SetInnerText(metadata.GetDisplayName());
            return th.ToString();
        }
    }
}