using OneOf;

namespace Tauri.Models.Event;

public sealed class EventName : OneOfBase<TauriEvent, string>
{
    public EventName(OneOf<TauriEvent, string> input) : base(input)
    {
    }
}