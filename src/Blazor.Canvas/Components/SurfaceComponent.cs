using System;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.JSInterop;

namespace Isc.Blazor.Canvas
{
    public abstract class SurfaceComponent<TContext> : CanvasComponent<TContext>
        where TContext : CanvasContext
    {
        public abstract Task<bool> RequestFrameAsync();

        protected override async Task OnAfterRenderAsync()
        {
            await base.OnAfterRenderAsync();
            await StartRenderLoop();
        }

        private async Task StartRenderLoop()
        {
            var implementationType = this.GetType();
            var jsInvokableAttribute = implementationType.GetMethod(nameof(RequestFrameAsync)).GetCustomAttribute<JSInvokableAttribute>(inherit: true);

            if (jsInvokableAttribute == null)
            {
                throw new InvalidOperationException($"Missing JSInvokableAttribute in 'RequestFrame' for Type '{implementationType.FullName}'");
            }

            var jsMethodIdentifier = jsInvokableAttribute.Identifier;

            await JsRuntime.InvokeAsync<object>("Canvas.requestAnimFrameLoopAsync", jsMethodIdentifier, new DotNetObjectRef(this));
        }
    }
}
