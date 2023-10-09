using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Mvc.Razor;
using System.Web.UI;

namespace SefinMvcHelpers.Helpers
{
    public class MyHelper<T>
    {
        private HtmlHelper<T> helper;

        public MyHelper(HtmlHelper<T> helper)
        {
            this.helper = helper;
        }
        private string InputFor(ModelMetadata metadata, string htmlName, string htmlID)
        {

            var tagName = metadata.DataTypeName == "Multiline" ? HtmlTextWriterTag.Textarea.ToString() : HtmlTextWriterTag.Input.ToString();
            
            TagBuilder inputTag = new TagBuilder(tagName);

            var validationAttributes = helper.GetUnobtrusiveValidationAttributes(htmlName, metadata);
            inputTag.MergeAttributes(validationAttributes);
            inputTag.MergeAttribute("placeholder", string.IsNullOrWhiteSpace(metadata.Watermark) ? metadata.GetDisplayName() : metadata.Watermark);
            inputTag.MergeAttribute("name", htmlName);
            inputTag.MergeAttribute("id", htmlID);
            
            inputTag.AddCssClass("form-control");
            
            return inputTag.ToString();
        }
        public MvcHtmlString InputFor<TProp>(Expression<Func<T, TProp>> propertyExpression)
        {
            var metadata = ModelMetadata.FromLambdaExpression(propertyExpression, new ViewDataDictionary<T>());
            var htmlName = helper.NameFor(propertyExpression).ToString();
            var htmlID = helper.IdFor(propertyExpression).ToString();
            
            return new MvcHtmlString(InputFor(metadata,htmlName,htmlID));
        }
        private string LabelFor(ModelMetadata metadata, string htmlName)
        {

            TagBuilder labelTag = new TagBuilder(HtmlTextWriterTag.Label.ToString());

            labelTag.AddCssClass("control-label");
            labelTag.MergeAttribute("for", htmlName);
            labelTag.SetInnerText(metadata.GetDisplayName());
            return labelTag.ToString();
        }
        public MvcHtmlString LabelFor<TProp>(Expression<Func<T, TProp>> propertyExpression)
        {
            var metadata = ModelMetadata.FromLambdaExpression(propertyExpression, new ViewDataDictionary<T>());
            var htmlName = helper.NameFor(propertyExpression).ToString();
            return new MvcHtmlString(LabelFor(metadata, htmlName));

        }
        public MvcHtmlString FormGroupFor<TProp>(Expression<Func<T, TProp>> propertyExpression)
        {
            return new MvcHtmlString(FormGroupForInternal(propertyExpression));
        }
        
        private string FormGroupForInternal<TProp>(Expression<Func<T, TProp>> propertyExpression)
        {
            var body=new StringBuilder();
            var metadata = ModelMetadata.FromLambdaExpression(propertyExpression, new ViewDataDictionary<T>());
            var htmlName = helper.NameFor(propertyExpression).ToString();
            var htmlID = helper.IdFor(propertyExpression).ToString();

            TagBuilder divTag = new TagBuilder(HtmlTextWriterTag.Div.ToString());
            
            divTag.AddCssClass("form-group");
            body.Append(LabelFor(metadata, htmlName));
            body.Append(InputFor(metadata, htmlName, htmlID));

            divTag.InnerHtml = body.ToString();

            return divTag.ToString();
        }
        public MvcHtmlString FormForModel(T model){
            var modelType = typeof(T);
            var selfType=typeof(MyHelper<T>);
            var formGroupForMethod = selfType.GetMethod("FormGroupForInternal",BindingFlags.NonPublic|BindingFlags.Instance);

            var publicProperties = modelType.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            StringBuilder body = new StringBuilder();
            foreach (var prop in publicProperties)
            {
                if (prop.GetCustomAttributes().OfType<HiddenInputAttribute>().Any()) continue;
                var formGroupForMethodGeneric = formGroupForMethod.MakeGenericMethod(prop.PropertyType);
                var lambda = BuildLambda(prop, modelType);
                string formGroup=(string) formGroupForMethodGeneric.Invoke(this, new []{ lambda });
                body.Append(formGroup);
            }
            TagBuilder form = new TagBuilder(HtmlTextWriterTag.Form.ToString());
            form.InnerHtml = body.ToString();
            return new MvcHtmlString(form.ToString());
        }
        private object BuildLambda(PropertyInfo prop, Type modelType)
        {
            var parameter = Expression.Parameter(modelType);
            var property = Expression.Property(parameter, prop);
            var funcType = typeof(Func<,>).MakeGenericType(modelType, property.Type);
            return Expression.Lambda(funcType, property, parameter);
        }

        
    }
}
