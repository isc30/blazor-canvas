# Blazor.Canvas

Blazor Canvas Components for easy graphics rendering

## Supported Rendering Contexts

- [x] 2D
- [ ] WebGL (WIP)

## Important Note about Context

Calling JS from .NET is an expensive operation, that's why every operation on the context is being batched.<br/>
It is required to call `Context.RenderAsync()` to actually perform the rendering: it pops all the pending operations and applies them in the browser.

> Please remember to call `Context.RenderAsync()` in the end to actually perform the rendering in the canvas!

# 2D Rendering Context

The lib includes some components ready to be used for 2D rendering:

- ### `Canvas2DComponent` for static rendering

  This component will render a `canvas` element in the screen and create the 2D context for you.<br/>
  Your custom component should inherit from `Canvas2DComponent` and override `OnAfterContextCreatedAsync()`.<br/>
  Use `Context` from the base to invoke render operations.
  
  ```cs
  public sealed class HelloCanvas : Canvas2DComponent
  {
      protected override async Task OnAfterContextCreatedAsync()
      {
          Context.SetFillStyle("orange");
          Context.FillRect(x: 50, y: 50, width: 50, height: 50);

          await Context.RenderAsync();
      }
  }
  ```

- ### `Surface2DComponent` for realtime rendering

  Same as `Canvas2DComponent`, but this time you will need to override `Task<bool> RequestFrameAsync()`.
  Also, add `[JSInvokable]` to `RequestFrameAsync` so it can be automatically invoked from javascript every frame by the browser (using `requestAnimationFrame` in the background).
  Return `true` from `RequestFrameAsync` if you want a new frame to be requested and `false` if you want to stop the realtime rendering.

  ```cs
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
  ```
