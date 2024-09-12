window.__TAURI__ = window.__TAURI__ || {};

window.__TAURI__.blazor = window.__TAURI__.blazor || {};

window.__TAURI__.blazor.callbacks = window.__TAURI__.blazor.callbacks || {};

/**
 * Registers an event listener that invokes a .NET method asynchronously when the event is triggered.
 * @param {Object} dotnetObjectRef - The .NET object reference.
 * @param {string} eventName - The name of the event to listen for.
 */
window.__TAURI__.blazor.listen = async function (dotnetObjectRef, eventName) {
    window.__TAURI__.blazor.callbacks[eventName] = await window.__TAURI__.event.listen(eventName, async function (event) {
        await dotnetObjectRef.invokeMethodAsync('InvokeAsync', event);
    });
}

/**
 * Registers a one-time event listener that invokes a .NET method asynchronously when the event is triggered.
 * @param {Object} dotnetObjectRef - The .NET object reference.
 * @param {string} eventName - The name of the event to listen for.
 */
window.__TAURI__.blazor.once = async function (dotnetObjectRef, eventName) {
    window.__TAURI__.blazor.callbacks[eventName] = await window.__TAURI__.event.once(eventName, async function (event) {
        await dotnetObjectRef.invokeMethodAsync('InvokeAsync', event);
    });
}

/**
 * Unregisters an event listener.
 * @param {string} eventName - The name of the event to stop listening for.
 */
window.__TAURI__.blazor.unlisten = async function (eventName) {
    if (window.__TAURI__.blazor.callbacks[eventName]) {
        await window.__TAURI__.blazor.callbacks[eventName]();
        delete window.__TAURI__.blazor.callbacks[eventName];
    }
}