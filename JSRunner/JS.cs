using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSRunner
{
    public class JS
    {
        private IJSRuntime _jsRuntime;
        private IJSObjectReference? javaScriptEvaluatorContext;
        public JS(IJSRuntime jSRuntime)
        {
            _jsRuntime = jSRuntime;
        }
        public async ValueTask Run(string code, object? props = null)
        {
            javaScriptEvaluatorContext ??= await _jsRuntime.InvokeAsync<IJSObjectReference>("import", new[] { "./_content/JSRunner/main.js" });

            var data = new List<object>();
            var names = new List<string>();

            if (props != null)
            {
                var type = props.GetType();
                foreach (var prop in type.GetProperties())
                {
                    var value = prop.GetValue(props);
                    if (value != null)
                    {
                        data.Add(value);
                        names.Add(prop.Name);
                    }
                }
            }
            await javaScriptEvaluatorContext.InvokeVoidAsync("run", data.Prepend(code).Prepend(names).ToArray());
        }
        public async ValueTask<TResult> Run<TResult>(string code, object? props = null)
        {
            javaScriptEvaluatorContext ??= await _jsRuntime.InvokeAsync<IJSObjectReference>("import", new[] { "./_content/JSRunner/main.js" });

            var data = new List<object>();
            var names = new List<string>();

            if (props != null)
            {
                var type = props.GetType();
                foreach (var prop in type.GetProperties())
                {
                    var value = prop.GetValue(props);
                    if (value != null)
                    {
                        data.Add(value);
                        names.Add(prop.Name);
                    }
                }
            }
            return await javaScriptEvaluatorContext.InvokeAsync<TResult>("run", data.Prepend(code).Prepend(names).ToArray());
        }

    }
}
