namespace Canvas
{
    const contextCache: { [contextId: string]: any; } = {};

    export function createContext(contextId: string, canvasElement: HTMLCanvasElement, contextName: string)
    {
        contextCache[contextId] = canvasElement.getContext(contextName);
    }

    export function destroyContext(contextId: string)
    {
        delete contextCache[contextId];
    }

    interface ContextAction
    {
        action: "Call" | "Assign";
        target: string;
        args: any[] | null;
    }

    export function render(contextId: string, contextActions: Array<ContextAction>)
    {
        const context = contextCache[contextId];

        for (let i = 0; i < contextActions.length; ++i)
        {
            const action = contextActions[i];

            switch (action.action)
            {
                case "Call":
                    context[action.target](...action.args);
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

    export function requestAnimFrameLoopAsync(methodName: string, canvasSurfaceComponent: any)
    {
        const gameLoop = () =>
        {
            const animFrameId = window.requestAnimationFrame(gameLoop);

            canvasSurfaceComponent.invokeMethodAsync(methodName)
                .then((shouldContinue: boolean) =>
                {
                    if (!shouldContinue)
                    {
                        window.cancelAnimationFrame(animFrameId);
                    }
                });
        };

        gameLoop();
    }
};
