namespace Isc.Blazor.Canvas
{
    public static partial class Canvas2DContextExtensions
    {
        public static void FillRect(this Canvas2DContext context,
            double x, double y, double width, double height)
        {
            context.PushAction(CanvasContextAction.Call("fillRect", x, y, width, height));
        }

        public static void ClearRect(this Canvas2DContext context,
            double x, double y, double width, double height)
        {
            context.PushAction(CanvasContextAction.Call("clearRect", x, y, width, height));
        }
    }
}
