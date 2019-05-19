namespace Isc.Blazor.Canvas
{
    public static partial class Canvas2DContextExtensions
    {
        public static void Stroke(this Canvas2DContext context)
        {
            context.PushAction(CanvasContextAction.Call("stroke"));
        }

        public static void Fill(this Canvas2DContext context)
        {
            context.PushAction(CanvasContextAction.Call("fill"));
        }
    }
}
