//MainMenu.cs
//using consoleuser;
using System;
using System.Collections.Generic;
//using System.ComponentModel.Design;
//using System.Text;

//using consoleuser;

internal class MainMenu
{
    public void Menu()
    {
        UserServices ott = new UserServices();
        VideoServices ott1 = new VideoServices();
        RequestServices req =new RequestServices();
        ott.adduser(1, "thiru", "12345678@", "t@t", Subscription.Premium, Role.Admin);
        ott.adduser(2, "seenu", "12345678@", "s@s", Subscription.Basic, Role.User);
        while (true)// while loop --> infinite loop
        {
            Console.WriteLine("1.NEW USER \n2.LOGIN NOW \n3.EXIT");

            int choice; // type casting we can use convert.ToInt32()
            ott.typecheck(out choice);

            switch (choice) //switch case which is a type of conditional statement
            {
                case 1: ott.CreateUser(); break;
                case 2: ott.UserLogin(ott, ott1,req); break;
                case 3: Console.WriteLine("THANKS FOR USING OUR OTT PLATFORM !!!"); return;

            }
        }
    }
}
////}
