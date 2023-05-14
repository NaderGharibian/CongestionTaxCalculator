
using congestion.Enums;

using Enums;

using Helpers;

namespace congestion.calculator;

public class ResponseMessage
{
    public string ShowType { get; private set; }
    public string Text { get; private set; }

    public ResponseMessage(string text, ShowType showType = congestion.Enums.ShowType.None)
    {
        ShowType = EnumHelper<ShowType>.GetName( showType);
        Text = text;
    }
}