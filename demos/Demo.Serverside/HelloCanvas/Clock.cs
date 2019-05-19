using System;
using System.Threading.Tasks;
using Microsoft.JSInterop;

namespace Isc.Blazor.Canvas.Demo.Serverside
{
    public sealed class Clock : Surface2DComponent
    {
        [JSInvokable(nameof(Clock) + nameof(RequestFrameAsync))]
        public override async Task<bool> RequestFrameAsync()
        {
            Context.Clear("white");

            Context.SetFillStyle("black");
            Context.SetFont("24px Arial");
            Context.FillText(DateTime.Now.Millisecond.ToString(), 25, 25);

            await Context.RenderAsync();

            return true;
        }
    }
}
