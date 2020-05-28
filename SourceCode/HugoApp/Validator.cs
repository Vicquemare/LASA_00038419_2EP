using System;
using System.Globalization;
using System.Windows.Forms;

namespace HugoApp
{
    public static class Validator
    {
        public static string InputText(string message)
        {
            bool valid = false;
            string text = "";
            string error = "Texto invalido";
            do
            {
                try
                {
                    text = message;
                    if (string.IsNullOrEmpty(text) || string.IsNullOrWhiteSpace(text))
                    {
                        throw new Exception(error+"\n");
                    }
                    valid = true;
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message);
                }
            } while (string.IsNullOrEmpty(text)&& !valid);
            return text;
        }

        public static int InputInt(string message, int min, int max)
        {
            int number = 0;
            bool valid = false;
            string text = "";
            string error = "numInvalido";
            do
            {
                try
                {
                    text = message;
                    valid = int.TryParse(text, out number);
                    if (!valid || (number > max || number < min))
                    {
                        valid = false;
                        throw new Exception(error+"\n");
                        
                    }
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                }
            } while (string.IsNullOrEmpty(text) || !valid);
            return number;
        }
        
        public static double InputDouble(string message, string error, double min, double max)
        {
            double number = 0;
            bool valid = false;
            string text = "";
            do
            {
                try
                {
                    Console.WriteLine(message);
                    text = Console.ReadLine();
                    valid = double.TryParse(text, out number);
                    if (!valid || (number > max || number < min))
                    {
                        valid = false;
                        throw new Exception(error+"\n");
                        
                    }
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                }
            } while (string.IsNullOrEmpty(text) || !valid);
            return number;
        }
        
        public static DateTime InputFecha(string message, string error)
        {
            bool valid = false;
            string text = "";
            CultureInfo culture = new CultureInfo("en-US");    
            DateTime dateTime = Convert.ToDateTime("1/1/2020 12:10:15 PM", culture);   
            
            do
            {
                try
                {
                    Console.WriteLine(message);
                    text = Console.ReadLine();
                    valid = DateTime.TryParse(text, out dateTime);
                    if (!valid)
                    {
                        throw new Exception(error+"\n");
                    }
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                }
            } while (string.IsNullOrEmpty(text) || !valid);
            return dateTime;
        }
    }
}
