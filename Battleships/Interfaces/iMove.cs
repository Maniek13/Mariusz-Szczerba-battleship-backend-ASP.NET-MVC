namespace Battleships.Move
{
    interface iMove
    {
        int Message { get; set; }
        int Hit { get; set; }
        int Field { get; set; }
    }
}
