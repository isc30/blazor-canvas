namespace Isc.Blazor.Canvas
{
    public static partial class Canvas2DContextExtensions
    {
        public static void Save(this Canvas2DContext context)
        {
            context.PushAction(CanvasContextAction.Call("save"));
        }

        public static void Restore(this Canvas2DContext context)
        {
            context.PushAction(CanvasContextAction.Call("restore"));
        }
    }
}
