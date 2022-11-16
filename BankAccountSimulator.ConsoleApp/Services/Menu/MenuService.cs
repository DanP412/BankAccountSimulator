﻿using BankAccountSimulator.ConsoleApp.Services.Consoles;

namespace BankAccountSimulator.ConsoleApp.Services.Menu
{
    public class MenuService : IMenuService
    {
        private readonly IConsoleService _consoleService;
        public MenuService(IConsoleService consoleService)
        {
            _consoleService = consoleService;
        }

        private List<string> _options = new List<string>
        {
            "Zaloguj się",
            "Utwórz nowe konto",
            "Zakończ program"
        };
        private List<string> _optionsAfterLogin = new List<string>
        {
            "Dodaj środki do konta",
            "Wyciągnij środki z konta",
            "Wyświetl saldo konta",
            "Wyświetl historię konta",

        };
        public void DisplayOptions(bool isUserLogged)
        {
            int number = 1;
            if (isUserLogged)
            {
                Console.WriteLine("");
                foreach (var option in _optionsAfterLogin)
                {
                    Console.WriteLine($"{number}. {option}");
                    number++;
                }
            }
            else
            {
                foreach (var option in _options)
                {
                    Console.WriteLine($"{number}. {option}");
                    number++;
                }
            }
        }
        public int GetOption(bool isUserLogged)
        {
            if (isUserLogged)
            {
                int optionCount = _optionsAfterLogin.Count;
                int option = _consoleService.GetIntegerWithinRange("\nWybierz opcję: ", 1, optionCount);
                return option;
            }
            else
            {
                int optionCount = _options.Count;
                int option = _consoleService.GetIntegerWithinRange("\nWybierz opcję: ", 1, optionCount);
                return option;
            }
        }


    }
}
