public class BindIndex
{
    public int Vaule { get; }

    public BindIndex(int Vaule)
    {
        if (Vaule != -1)
        {
            this.Vaule = Vaule;
        }
        else
        {
            throw new System.NullReferenceException(nameof(Vaule) + "ïsê≥Ç»ílÇ≈Ç∑");
        }

    }

}
