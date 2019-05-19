using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Isc.Blazor.Canvas
{
    public sealed class Canvas2DContext : CanvasContext
    {
        public static async Task<Canvas2DContext> CreateAsync(IJSRuntime jsRuntime, ElementRef canvasElement)
        {
            var contextId = await CanvasContext.CreateAsync(jsRuntime, canvasElement, "2d");

            return new Canvas2DContext(jsRuntime, contextId);
        }

        private Canvas2DContext(IJSRuntime jsRuntime, string contextId)
            : base(jsRuntime, contextId)
        {
        }
    }
}
