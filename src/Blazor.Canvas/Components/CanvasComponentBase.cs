using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.RenderTree;

namespace Isc.Blazor.Canvas
{
    public abstract class CanvasComponentBase : ComponentBase
    {
        [Parameter]
        public int Width { get; protected set; }

        [Parameter]
        public int Height { get; protected set; }

        public ElementRef CanvasElement { get; private set; }

        protected override void BuildRenderTree(RenderTreeBuilder builder)
        {
            base.BuildRenderTree(builder);

            builder.OpenElement(0, "canvas");

            if (Width != default)
            {
                builder.AddAttribute(0, "width", Width);
            }

            if (Height != default)
            {
                builder.AddAttribute(0, "height", Height);
            }

            builder.AddElementReferenceCapture(0, el => CanvasElement = el);
            builder.CloseElement();
        }
    }
}
