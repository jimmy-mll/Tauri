using Microsoft.JSInterop;

namespace Tauri.Json.Nodes;

/// <summary>
/// Represents a JSON callback value that returns a ValueTask of type T.
/// </summary>
/// <typeparam name="T">The type of the result produced by the callback.</typeparam>
/// <param name="callback">The callback function to be invoked.</param>
public sealed class FuncCallbackValue<T>(Func<ValueTask<T>> callback)
{
    /// <summary>
    /// Invokes the callback asynchronously.
    /// </summary>
    /// <returns>A <see cref="ValueTask{T}"/> representing the asynchronous operation.</returns>
    [JSInvokable]
    public ValueTask<T> InvokeAsync()
    {
        return callback();
    }
}

/// <summary>
/// Represents a JSON callback value with one parameter that returns a ValueTask of type T2.
/// </summary>
/// <typeparam name="T1">The type of the parameter.</typeparam>
/// <typeparam name="T2">The type of the result produced by the callback.</typeparam>
/// <param name="callback">The callback function to be invoked.</param>
public sealed class FuncCallbackValue<T1, T2>(Func<T1, ValueTask<T2>> callback)
{
    /// <summary>
    /// Invokes the callback asynchronously with the specified argument.
    /// </summary>
    /// <param name="arg">The argument to pass to the callback.</param>
    /// <returns>A <see cref="ValueTask{T2}"/> representing the asynchronous operation.</returns>
    [JSInvokable]
    public ValueTask<T2> InvokeAsync(T1 arg)
    {
        return callback(arg);
    }
}

/// <summary>
/// Represents a JSON callback value with two parameters that returns a ValueTask of type T3.
/// </summary>
/// <typeparam name="T1">The type of the first parameter.</typeparam>
/// <typeparam name="T2">The type of the second parameter.</typeparam>
/// <typeparam name="T3">The type of the result produced by the callback.</typeparam>
/// <param name="callback">The callback function to be invoked.</param>
public sealed class FuncCallbackValue<T1, T2, T3>(Func<T1, T2, ValueTask<T3>> callback)
{
    /// <summary>
    /// Invokes the callback asynchronously with the specified arguments.
    /// </summary>
    /// <param name="arg1">The first argument to pass to the callback.</param>
    /// <param name="arg2">The second argument to pass to the callback.</param>
    /// <returns>A <see cref="ValueTask{T3}"/> representing the asynchronous operation.</returns>
    [JSInvokable]
    public ValueTask<T3> InvokeAsync(T1 arg1, T2 arg2)
    {
        return callback(arg1, arg2);
    }
}

/// <summary>
/// Represents a JSON callback value with three parameters that returns a ValueTask of type T4.
/// </summary>
/// <typeparam name="T1">The type of the first parameter.</typeparam>
/// <typeparam name="T2">The type of the second parameter.</typeparam>
/// <typeparam name="T3">The type of the third parameter.</typeparam>
/// <typeparam name="T4">The type of the result produced by the callback.</typeparam>
/// <param name="callback">The callback function to be invoked.</param>
public sealed class FuncCallbackValue<T1, T2, T3, T4>(Func<T1, T2, T3, ValueTask<T4>> callback)
{
    /// <summary>
    /// Invokes the callback asynchronously with the specified arguments.
    /// </summary>
    /// <param name="arg1">The first argument to pass to the callback.</param>
    /// <param name="arg2">The second argument to pass to the callback.</param>
    /// <param name="arg3">The third argument to pass to the callback.</param>
    /// <returns>A <see cref="ValueTask{T4}"/> representing the asynchronous operation.</returns>
    [JSInvokable]
    public ValueTask<T4> InvokeAsync(T1 arg1, T2 arg2, T3 arg3)
    {
        return callback(arg1, arg2, arg3);
    }
}

/// <summary>
/// Represents a JSON callback value with four parameters that returns a ValueTask of type T5.
/// </summary>
/// <typeparam name="T1">The type of the first parameter.</typeparam>
/// <typeparam name="T2">The type of the second parameter.</typeparam>
/// <typeparam name="T3">The type of the third parameter.</typeparam>
/// <typeparam name="T4">The type of the fourth parameter.</typeparam>
/// <typeparam name="T5">The type of the result produced by the callback.</typeparam>
/// <param name="callback">The callback function to be invoked.</param>
public sealed class FuncCallbackValue<T1, T2, T3, T4, T5>(Func<T1, T2, T3, T4, ValueTask<T5>> callback)
{
    /// <summary>
    /// Invokes the callback asynchronously with the specified arguments.
    /// </summary>
    /// <param name="arg1">The first argument to pass to the callback.</param>
    /// <param name="arg2">The second argument to pass to the callback.</param>
    /// <param name="arg3">The third argument to pass to the callback.</param>
    /// <param name="arg4">The fourth argument to pass to the callback.</param>
    /// <returns>A <see cref="ValueTask{T5}"/> representing the asynchronous operation.</returns>
    [JSInvokable]
    public ValueTask<T5> InvokeAsync(T1 arg1, T2 arg2, T3 arg3, T4 arg4)
    {
        return callback(arg1, arg2, arg3, arg4);
    }
}

/// <summary>
/// Represents a JSON callback value with five parameters that returns a ValueTask of type T6.
/// </summary>
/// <typeparam name="T1">The type of the first parameter.</typeparam>
/// <typeparam name="T2">The type of the second parameter.</typeparam>
/// <typeparam name="T3">The type of the third parameter.</typeparam>
/// <typeparam name="T4">The type of the fourth parameter.</typeparam>
/// <typeparam name="T5">The type of the fifth parameter.</typeparam>
/// <typeparam name="T6">The type of the result produced by the callback.</typeparam>
/// <param name="callback">The callback function to be invoked.</param>
public sealed class FuncCallbackValue<T1, T2, T3, T4, T5, T6>(Func<T1, T2, T3, T4, T5, ValueTask<T6>> callback)
{
    /// <summary>
    /// Invokes the callback asynchronously with the specified arguments.
    /// </summary>
    /// <param name="arg1">The first argument to pass to the callback.</param>
    /// <param name="arg2">The second argument to pass to the callback.</param>
    /// <param name="arg3">The third argument to pass to the callback.</param>
    /// <param name="arg4">The fourth argument to pass to the callback.</param>
    /// <param name="arg5">The fifth argument to pass to the callback.</param>
    /// <returns>A <see cref="ValueTask{T6}"/> representing the asynchronous operation.</returns>
    [JSInvokable]
    public ValueTask<T6> InvokeAsync(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5)
    {
        return callback(arg1, arg2, arg3, arg4, arg5);
    }
}

/// <summary>
/// Represents a JSON callback value with six parameters that returns a ValueTask of type T7.
/// </summary>
/// <typeparam name="T1">The type of the first parameter.</typeparam>
/// <typeparam name="T2">The type of the second parameter.</typeparam>
/// <typeparam name="T3">The type of the third parameter.</typeparam>
/// <typeparam name="T4">The type of the fourth parameter.</typeparam>
/// <typeparam name="T5">The type of the fifth parameter.</typeparam>
/// <typeparam name="T6">The type of the sixth parameter.</typeparam>
/// <typeparam name="T7">The type of the result produced by the callback.</typeparam>
/// <param name="callback">The callback function to be invoked.</param>
public sealed class FuncCallbackValue<T1, T2, T3, T4, T5, T6, T7>(Func<T1, T2, T3, T4, T5, T6, ValueTask<T7>> callback)
{
    /// <summary>
    /// Invokes the callback asynchronously with the specified arguments.
    /// </summary>
    /// <param name="arg1">The first argument to pass to the callback.</param>
    /// <param name="arg2">The second argument to pass to the callback.</param>
    /// <param name="arg3">The third argument to pass to the callback.</param>
    /// <param name="arg4">The fourth argument to pass to the callback.</param>
    /// <param name="arg5">The fifth argument to pass to the callback.</param>
    /// <param name="arg6">The sixth argument to pass to the callback.</param>
    /// <returns>A <see cref="ValueTask{T7}"/> representing the asynchronous operation.</returns>
    [JSInvokable]
    public ValueTask<T7> InvokeAsync(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6)
    {
        return callback(arg1, arg2, arg3, arg4, arg5, arg6);
    }
}

/// <summary>
/// Represents a JSON callback value with seven parameters that returns a ValueTask of type T8.
/// </summary>
/// <typeparam name="T1">The type of the first parameter.</typeparam>
/// <typeparam name="T2">The type of the second parameter.</typeparam>
/// <typeparam name="T3">The type of the third parameter.</typeparam>
/// <typeparam name="T4">The type of the fourth parameter.</typeparam>
/// <typeparam name="T5">The type of the fifth parameter.</typeparam>
/// <typeparam name="T6">The type of the sixth parameter.</typeparam>
/// <typeparam name="T7">The type of the seventh parameter.</typeparam>
/// <typeparam name="T8">The type of the result produced by the callback.</typeparam>
/// <param name="callback">The callback function to be invoked.</param>
public sealed class FuncCallbackValue<T1, T2, T3, T4, T5, T6, T7, T8>(Func<T1, T2, T3, T4, T5, T6, T7, ValueTask<T8>> callback)
{
    /// <summary>
    /// Invokes the callback asynchronously with the specified arguments.
    /// </summary>
    /// <param name="arg1">The first argument to pass to the callback.</param>
    /// <param name="arg2">The second argument to pass to the callback.</param>
    /// <param name="arg3">The third argument to pass to the callback.</param>
    /// <param name="arg4">The fourth argument to pass to the callback.</param>
    /// <param name="arg5">The fifth argument to pass to the callback.</param>
    /// <param name="arg6">The sixth argument to pass to the callback.</param>
    /// <param name="arg7">The seventh argument to pass to the callback.</param>
    /// <returns>A <see cref="ValueTask{T8}"/> representing the asynchronous operation.</returns>
    [JSInvokable]
    public ValueTask<T8> InvokeAsync(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7)
    {
        return callback(arg1, arg2, arg3, arg4, arg5, arg6, arg7);
    }
}

/// <summary>
/// Represents a JSON callback value with eight parameters that returns a ValueTask of type T9.
/// </summary>
/// <typeparam name="T1">The type of the first parameter.</typeparam>
/// <typeparam name="T2">The type of the second parameter.</typeparam>
/// <typeparam name="T3">The type of the third parameter.</typeparam>
/// <typeparam name="T4">The type of the fourth parameter.</typeparam>
/// <typeparam name="T5">The type of the fifth parameter.</typeparam>
/// <typeparam name="T6">The type of the sixth parameter.</typeparam>
/// <typeparam name="T7">The type of the seventh parameter.</typeparam>
/// <typeparam name="T8">The type of the eighth parameter.</typeparam>
/// <typeparam name="T9">The type of the result produced by the callback.</typeparam>
/// <param name="callback">The callback function to be invoked.</param>
public sealed class FuncCallbackValue<T1, T2, T3, T4, T5, T6, T7, T8, T9>(Func<T1, T2, T3, T4, T5, T6, T7, T8, ValueTask<T9>> callback)
{
    /// <summary>
    /// Invokes the callback asynchronously with the specified arguments.
    /// </summary>
    /// <param name="arg1">The first argument to pass to the callback.</param>
    /// <param name="arg2">The second argument to pass to the callback.</param>
    /// <param name="arg3">The third argument to pass to the callback.</param>
    /// <param name="arg4">The fourth argument to pass to the callback.</param>
    /// <param name="arg5">The fifth argument to pass to the callback.</param>
    /// <param name="arg6">The sixth argument to pass to the callback.</param>
    /// <param name="arg7">The seventh argument to pass to the callback.</param>
    /// <param name="arg8">The eighth argument to pass to the callback.</param>
    /// <returns>A <see cref="ValueTask{T9}"/> representing the asynchronous operation.</returns>
    [JSInvokable]
    public ValueTask<T9> InvokeAsync(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8)
    {
        return callback(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8);
    }
}

/// <summary>
/// Represents a JSON callback value with nine parameters that returns a ValueTask of type T10.
/// </summary>
/// <typeparam name="T1">The type of the first parameter.</typeparam>
/// <typeparam name="T2">The type of the second parameter.</typeparam>
/// <typeparam name="T3">The type of the third parameter.</typeparam>
/// <typeparam name="T4">The type of the fourth parameter.</typeparam>
/// <typeparam name="T5">The type of the fifth parameter.</typeparam>
/// <typeparam name="T6">The type of the sixth parameter.</typeparam>
/// <typeparam name="T7">The type of the seventh parameter.</typeparam>
/// <typeparam name="T8">The type of the eighth parameter.</typeparam>
/// <typeparam name="T9">The type of the ninth parameter.</typeparam>
/// <typeparam name="T10">The type of the result produced by the callback.</typeparam>
/// <param name="callback">The callback function to be invoked.</param>
public sealed class FuncCallbackValue<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, ValueTask<T10>> callback)
{
    /// <summary>
    /// Invokes the callback asynchronously with the specified arguments.
    /// </summary>
    /// <param name="arg1">The first argument to pass to the callback.</param>
    /// <param name="arg2">The second argument to pass to the callback.</param>
    /// <param name="arg3">The third argument to pass to the callback.</param>
    /// <param name="arg4">The fourth argument to pass to the callback.</param>
    /// <param name="arg5">The fifth argument to pass to the callback.</param>
    /// <param name="arg6">The sixth argument to pass to the callback.</param>
    /// <param name="arg7">The seventh argument to pass to the callback.</param>
    /// <param name="arg8">The eighth argument to pass to the callback.</param>
    /// <param name="arg9">The ninth argument to pass to the callback.</param>
    /// <returns>A <see cref="ValueTask{T10}"/> representing the asynchronous operation.</returns>
    [JSInvokable]
    public ValueTask<T10> InvokeAsync(T1 arg1, T2 arg2, T3 arg3, T4 arg4, T5 arg5, T6 arg6, T7 arg7, T8 arg8, T9 arg9)
    {
        return callback(arg1, arg2, arg3, arg4, arg5, arg6, arg7, arg8, arg9);
    }
}