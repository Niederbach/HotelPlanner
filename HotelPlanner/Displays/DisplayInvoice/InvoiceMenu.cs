using ConsoleUI.Displays.DisplayInvoice.InvoiceInterfaces;
using ConsoleUI.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI.Displays.DisplayInvoice
{
    public class InvoiceMenu : IInvoiceMenu
    {
        private bool _running;
        private int _selectedIndex;
        private List<string> _invoiceOptions = new List<string>();

        public InvoiceMenu()
        {
            _invoiceOptions.Add("Titta på Fakturor");
            _invoiceOptions.Add("Titta på betalada Fakturor");
        }
        public void ShowInvoiceMenu()
        {
            _selectedIndex = 0;
            _running = true;
            while (_running)
            {
                Console.Clear();
                Console.WriteLine("Faktura Hantering");
                Console.WriteLine("=================");

                MenuFormat.CreateMenuUI(_invoiceOptions, _selectedIndex);

                Console.WriteLine("=================");
                var keyInput = Console.ReadKey(true);
                UserInput(keyInput); ;
            }
        }
        public void UserInput(ConsoleKeyInfo keyInput)
        {
            if (keyInput.Key == ConsoleKey.DownArrow)
            {
                _selectedIndex++;
                if (_selectedIndex > _invoiceOptions.Count)
                    _selectedIndex = 0;
            }
            else if (keyInput.Key == ConsoleKey.UpArrow)
            {
                _selectedIndex--;
                if (_selectedIndex < 0)
                    _selectedIndex = _invoiceOptions.Count;
            }
            else if (keyInput.Key == ConsoleKey.Enter)
            {
                if (_selectedIndex == 0)
                {
                    
                }
                else if (_selectedIndex == 1)
                {
                    
                }
                else if (_selectedIndex == _invoiceOptions.Count)
                    _running = false;

            }
        }
    }
}
