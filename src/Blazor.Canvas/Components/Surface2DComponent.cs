using System.Threading.Tasks;

namespace Isc.Blazor.Canvas
{
    public abstract class Surface2DComponent : SurfaceComponent<Canvas2DContext>
    {
        protected override Task<Canvas2DContext> CreateContextAsync()
        {
            return Canvas2DContext.CreateAsync(JsRuntime, CanvasElement);
        }
    }
}
