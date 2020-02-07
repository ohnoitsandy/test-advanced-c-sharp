using System;
using System.Runtime.InteropServices;
using CoreTest.Utilities;
using static System.Console;

namespace CoreTest.App
{
    public static class MainMenu
    {
        public static void Start()
        {
            var selection = 0;
            do
            {
                UiPainter.PaintMainUi();
                selection = Convert.ToInt32(ReadLine());
                switch (selection)
                {
                    case 1:
                        UserHandler.CreateUser();
                        break;
                    case 2:
                        UserHandler.EditUser();
                        break;
                    case 3:
                        UiPainter.PaintDelete();
                        break;
                    case 4:
                        UiPainter.PaintSearch();
                        break;
                    case 5:
                        break;
                }
            }
            while (selection != 5);
        }
    }
}