using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Isc.Blazor.Canvas
{
    public abstract class CanvasComponent<TContext> : CanvasComponentBase, IDisposable
        where TContext : CanvasContext
    {
        [Inject]
        protected IJSRuntime JsRuntime { get; set; } = null;

        public TContext Context { get; private set; } = null;

        protected virtual void OnAfterContextCreated() { }

        protected virtual Task OnAfterContextCreatedAsync() => Task.CompletedTask;

        protected abstract Task<TContext> CreateContextAsync();

        protected override async Task OnAfterRenderAsync()
        {
            Context = await CreateContextAsync();

            OnAfterContextCreated();
            await OnAfterContextCreatedAsync();
        }

        public virtual void Dispose()
        {
            Context?.Dispose();
        }
    }
}
