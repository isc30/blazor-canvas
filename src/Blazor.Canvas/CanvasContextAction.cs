namespace Isc.Blazor.Canvas
{
    public struct CanvasContextAction
    {
        public static CanvasContextAction Call(string method, params object[] args)
        {
            return new CanvasContextAction(ActionType.Call, method, args);
        }

        public static CanvasContextAction Call(string method)
        {
            return new CanvasContextAction(ActionType.Call, method, null);
        }

        public static CanvasContextAction Assign(string field, object value)
        {
            return new CanvasContextAction(ActionType.Assign, field, new object[] { value });
        }

        private static class ActionType
        {
            public const string Call = nameof(Call);
            public const string Assign = nameof(Assign);
        }

        public string Action { get; private set; }

        public string Target { get; private set; }

        public object[] Args { get; private set; }

        private CanvasContextAction(string action, string target, object[] args)
        {
            Action = action;
            Target = target;
            Args = args;
        }
    }
}
