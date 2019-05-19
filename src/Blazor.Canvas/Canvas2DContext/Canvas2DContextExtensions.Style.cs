namespace Isc.Blazor.Canvas
{
    public static partial class Canvas2DContextExtensions
    {
        public static void SetFillStyle(this Canvas2DContext context,
            string style)
        {
            context.PushAction(CanvasContextAction.Assign("fillStyle", style));
        }

        public static void SetStrokeStyle(this Canvas2DContext context,
            string style)
        {
            context.PushAction(CanvasContextAction.Assign("strokeStyle", style));
        }
    }
}
