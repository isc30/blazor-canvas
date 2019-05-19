namespace Isc.Blazor.Canvas
{
    public static partial class Canvas2DContextExtensions
    {
        public static void BeginPath(this Canvas2DContext context)
        {
            context.PushAction(CanvasContextAction.Call("beginPath"));
        }

        public static void EndPath(this Canvas2DContext context)
        {
            context.PushAction(CanvasContextAction.Call("endPath"));
        }

        public static void MoveTo(this Canvas2DContext context,
            double x, double y)
        {
            context.PushAction(CanvasContextAction.Call("moveTo", x, y));
        }

        public static void LineTo(this Canvas2DContext context,
            double x, double y)
        {
            context.PushAction(CanvasContextAction.Call("lineTo", x, y));
        }
    }
}
