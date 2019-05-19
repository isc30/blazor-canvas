using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace Isc.Blazor.Canvas.Demo.Wasm
{
    public sealed class HelloCanvas : Canvas2DComponent
    {
        [Parameter]
        public string Text { get; set; }

        [Parameter]
        public string BgColor { get; set; }

        protected override async Task OnParametersSetAsync()
        {
            await base.OnParametersSetAsync();

            if (BgColor == default)
            {
                BgColor = "orange";
            }

            if (Width == default)
            {
                Width = Text.Length * 33;
            }

            if (Height == default)
            {
                Height = (Text.Count(c => c == '\n') + 1) * 80;
            }
        }

        protected override async Task OnAfterContextCreatedAsync()
        {
            Context.SetFillStyle(BgColor);
            Context.FillRect(0, 0, Width, Height);

            Context.SetFont("64px Arial");
            Context.SetFillStyle("red");
            Context.SetStrokeStyle("black");

            Context.SetTextAlign("center");
            Context.SetTextBaseline("middle");

            Context.FillText(Text, Width / 2.0, Height / 2.0);
            Context.StrokeText(Text, Width / 2.0, Height / 2.0);

            await Context.RenderAsync();
        }
    }
}
