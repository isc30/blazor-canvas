namespace Isc.Blazor.Canvas
{
    public static partial class Canvas2DContextExtensions
    {
        public static void SetFont(this Canvas2DContext context,
            string font)
        {
            context.PushAction(CanvasContextAction.Assign("font", font));
        }

        public static void FillText(this Canvas2DContext context,
            string text, double x, double y)
        {
            context.PushAction(CanvasContextAction.Call("fillText", text, x, y));
        }

        public static void StrokeText(this Canvas2DContext context,
            string text, double x, double y)
        {
            context.PushAction(CanvasContextAction.Call("strokeText", text, x, y));
        }

        public static void SetTextAlign(this Canvas2DContext context,
            string align)
        {
            context.PushAction(CanvasContextAction.Assign("textAlign", align));
        }

        public static void SetTextBaseline(this Canvas2DContext context,
            string baseline)
        {
            context.PushAction(CanvasContextAction.Assign("textBaseline", baseline));
        }
    }
}
