using OneOf;
using Tauri.Extensions;

namespace Tauri.Models.Event;

public sealed class EventName : OneOfBase<TauriEvent, string>
{
    public EventName(OneOf<TauriEvent, string> input) : base(input)
    {
    }

    public override string ToString()
    {
        return Match(tauriEvent => tauriEvent.ToSchemeName(), customEvent => customEvent);
    }
}