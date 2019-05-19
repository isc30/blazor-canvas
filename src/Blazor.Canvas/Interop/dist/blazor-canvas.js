var Canvas;
(function (Canvas) {
    var contextCache = {};
    function createContext(contextId, canvasElement, contextName) {
        contextCache[contextId] = canvasElement.getContext(contextName);
    }
    Canvas.createContext = createContext;
    function destroyContext(contextId) {
        delete contextCache[contextId];
    }
    Canvas.destroyContext = destroyContext;
    function render(contextId, contextActions) {
        var context = contextCache[contextId];
        for (var i = 0; i < contextActions.length; ++i) {
            var action = contextActions[i];
            switch (action.action) {
                case "Call":
                    context[action.target].apply(context, action.args);
                    break;
                case "Assign":
                    context[action.target] = action.args[0];
                    break;
                default:
                    console.error("Invalid context action type: " + action.action);
                    break;
            }
        }
    }
    Canvas.render = render;
    function requestAnimFrameLoopAsync(methodName, canvasSurfaceComponent) {
        var gameLoop = function () {
            var animFrameId = window.requestAnimationFrame(gameLoop);
            canvasSurfaceComponent.invokeMethodAsync(methodName)
                .then(function (shouldContinue) {
                if (!shouldContinue) {
                    window.cancelAnimationFrame(animFrameId);
                }
            });
        };
        gameLoop();
    }
    Canvas.requestAnimFrameLoopAsync = requestAnimFrameLoopAsync;
})(Canvas || (Canvas = {}));
;
