namespace Battleships.Interfaces
{
    interface IMove
    {
        int Message { get; set; }
        int Hit { get; set; }
        int Field { get; set; }
    }
}
