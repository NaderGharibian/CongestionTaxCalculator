
using Dto.Enums ;


using Helpers;

namespace Dto;

public class ResponseMessage
{
    public string ShowType { get; private set; }
    public string Text { get; private set; }

    public ResponseMessage(string text, ShowType showType = Enums.ShowType.None)
    {
        ShowType = EnumHelper<ShowType>.GetName( showType);
        Text = text;
    }
}