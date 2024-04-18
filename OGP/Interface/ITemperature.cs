namespace OGP.Interface
{
    public interface ITemperature
    {
        int Hotness { get; }
        int Coldness { get; }
        void Heat(int temp);
        void Cool(int temp);
    }
}
