public class ActionName
{
    public string Vaule { get; }

    public ActionName(string value)
    {

        if (string.IsNullOrEmpty(value))
        {
            throw new System.NullReferenceException(nameof(value)+"値が存在しません");
        }
        Vaule = value;
    }

}
