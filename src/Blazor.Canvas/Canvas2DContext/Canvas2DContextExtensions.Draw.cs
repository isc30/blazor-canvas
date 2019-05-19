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

        public static void Clear(this Canvas2DContext context,
            string style = "transparent")
        {
            context.Save();
            context.SetGlobalCompositeOperation("copy");
            context.SetStrokeStyle(style);
            context.BeginPath();
            context.LineTo(0, 0);
            context.Stroke();
            context.Restore();
        }
    }
}
