using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace web_app_asp_net_mvc_export_xml.Extensions
{
    public static class EnumerableExtensions
    {

        public static IEnumerable<SelectListItem> ToSelectList<TItem, TValue>(this IEnumerable<TItem> items, Func<TItem, TValue> valueSelector, Func<TItem, string> nameSelector, Func<TItem, bool> selectedValueSelector)
        {
            foreach (var item in items)
            {
                var value = valueSelector(item);

                yield return new SelectListItem
                {
                    Text = nameSelector(item),
                    Value = value.ToString(),
                    Selected = selectedValueSelector(item)
                };
            }
        }

    }
}