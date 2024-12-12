namespace ConsoleUI.Displays.DisplayBooking.BookingInterfaces
{
    public interface IDisplayCreateBooking
    {
        void CreateBooking();
        void UserInput(ConsoleKeyInfo keyInput, List<string> userInputs);
    }
}