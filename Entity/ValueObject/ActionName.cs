public class ActionName
{
    public string Vaule { get; }

    public ActionName(string value)
    {

        if (string.IsNullOrEmpty(value))
        {
            throw new System.NullReferenceException(nameof(value)+"ТlВ™СґНЁВµВ№ВєВс");
        }
        Vaule = value;
    }

}
