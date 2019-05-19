using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Newtonsoft.Json;

namespace Isc.Blazor.Canvas
{
    public abstract class CanvasContext : IDisposable
    {
        protected static async Task<string> CreateAsync(IJSRuntime jsRuntime, ElementRef canvasElement, string contextType)
        {
            var contextId = Guid.NewGuid().ToString();

            await jsRuntime.InvokeAsync<object>("Canvas.createContext", contextId, canvasElement, contextType);

            return contextId;
        }

        protected readonly IJSRuntime JsRuntime;
        protected readonly string ContextId;

        protected CanvasContext(IJSRuntime jsRuntime, string contextId)
        {
            JsRuntime = jsRuntime;
            ContextId = contextId;
        }

        private List<CanvasContextAction> _renderContextActions = new List<CanvasContextAction>();

        public void PushAction(CanvasContextAction action)
        {
            _renderContextActions.Add(action);
        }

        private IList<CanvasContextAction> PopActions()
        {
            var actions = _renderContextActions;
            _renderContextActions = new List<CanvasContextAction>();

            return actions;
        }

        public virtual async Task RenderAsync()
        {
            var actions = PopActions();

            await JsRuntime.InvokeAsync<object>("Canvas.render", ContextId, actions);
        }

        public void Dispose()
        {
            JsRuntime.InvokeAsync<object>("Canvas.destroyContext", ContextId).Wait();
        }
    }
}
