namespace Isc.Blazor.Canvas
{
    public static partial class Canvas2DContextExtensions
    {
        public static class GlobalCompositeOperationOption
        {
            /// <summary>
            /// This is the default setting and draws new shapes on top of the existing canvas content.
            /// </summary>
            public const string SourceOver = "source-over";

            /// <summary>
            /// The new shape is drawn only where both the new shape and the destination canvas overlap.
            /// Everything else is made transparent.
            /// </summary>
            public const string SourceIn = "source-in";

            /// <summary>
            /// The new shape is drawn where it doesn't overlap the existing canvas content.
            /// </summary>
            public const string SourceOut = "source-out";

            /// <summary>
            /// The new shape is only drawn where it overlaps the existing canvas content.
            /// </summary>
            public const string SourceAtop = "source-atop";

            /// <summary>
            /// New shapes are drawn behind the existing canvas content.
            /// </summary>
            public const string DestinationOver = "destination-over";

            /// <summary>
            /// The existing canvas content is kept where both the new shape and existing canvas content overlap.
            /// Everything else is made transparent
            /// </summary>
            public const string DestinationIn = "destination-in";

            /// <summary>
            /// The existing content is kept where it doesn't overlap the new shape.
            /// </summary>
            public const string DestinationOut = "destination-out";

            /// <summary>
            /// The existing canvas is only kept where it overlaps the new shape.
            /// The new shape is drawn behind the canvas content.
            /// </summary>
            public const string DestinationAtop = "destination-atop";

            /// <summary>
            /// Where both shapes overlap the color is determined by adding color values.
            /// </summary>
            public const string Lighter = "lighter";

            /// <summary>
            /// Only the new shape is shown.
            /// </summary>
            public const string Copy = "copy";

            /// <summary>
            /// Shapes are made transparent where both overlap and drawn normal everywhere else.
            /// </summary>
            public const string Xor = "xor";

            /// <summary>
            /// The pixels are of the top layer are multiplied with the corresponding pixel of the bottom layer.
            /// A darker picture is the result.
            /// </summary>
            public const string Multiply = "multiply";

            /// <summary>
            /// The pixels are inverted, multiplied, and inverted again.
            /// A lighter picture is the result (opposite of multiply).
            /// </summary>
            public const string Screen = "screen";

            /// <summary>
            /// A combination of multiply and screen.
            /// Dark parts on the base layer become darker, and light parts become lighter.
            /// </summary>
            public const string Overlay = "overlay";

            /// <summary>
            /// Retains the darkest pixels of both layers.
            /// </summary>
            public const string Darken = "darken";

            /// <summary>
            /// Retains the lightest pixels of both layers.
            /// </summary>
            public const string Lighten = "lighten";

            /// <summary>
            /// Divides the bottom layer by the inverted top layer.
            /// </summary>
            public const string ColorDodge = "color-dodge";

            /// <summary>
            /// Divides the inverted bottom layer by the top layer, and then inverts the result.
            /// </summary>
            public const string ColorBurn = "color-burn";

            /// <summary>
            /// A combination of multiply and screen like overlay, but with top and bottom layer swapped.
            /// </summary>
            public const string HardLight = "hard-light";

            /// <summary>
            /// A softer version of hard-light. Pure black or white does not result in pure black or white.
            /// </summary>
            public const string SoftLight = "soft-light";

            /// <summary>
            /// Subtracts the bottom layer from the top layer or the other way round to always get a positive value.
            /// </summary>
            public const string Difference = "difference";

            /// <summary>
            /// Like difference, but with lower contrast.
            /// </summary>
            public const string Exclusion = "exclusion";

            /// <summary>
            /// Preserves the luma and chroma of the bottom layer, while adopting the hue of the top layer.
            /// </summary>
            public const string Hue = "hue";

            /// <summary>
            /// Preserves the luma and hue of the bottom layer, while adopting the chroma of the top layer.
            /// </summary>
            public const string Saturation = "saturation";

            /// <summary>
            /// Preserves the luma of the bottom layer, while adopting the hue and chroma of the top layer.
            /// </summary>
            public const string Color = "color";

            /// <summary>
            /// Preserves the hue and chroma of the bottom layer, while adopting the luma of the top layer.
            /// </summary>
            public const string Luminosity = "luminosity";
        };

        /// <summary>
        /// Sets the type of compositing operation to apply when drawing new shapes.
        /// https://developer.mozilla.org/en-US/docs/Web/API/Canvas_API/Tutorial/Compositing
        /// </summary>
        public static void SetGlobalCompositeOperation(this Canvas2DContext context,
            string operation)
        {
            context.PushAction(CanvasContextAction.Assign("globalCompositeOperation", operation));
        }
    }
}
