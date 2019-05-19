using System.Threading.Tasks;

namespace Isc.Blazor.Canvas
{
    public abstract class Canvas2DComponent : CanvasComponent<Canvas2DContext>
    {
        protected override Task<Canvas2DContext> CreateContextAsync()
        {
            return Canvas2DContext.CreateAsync(JsRuntime, CanvasElement);
        }
    }
}
