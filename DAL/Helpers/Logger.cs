using System;
using System.IO;
using DAL.Helpers;

public static class Logger
{
    // Ruta del archivo de log
    private static string logFilePath = "application_log.txt";

    // Método para escribir un mensaje de log
    public static void Log(string message, string level = "INFO")
    {
        try
        {
            // Si el archivo no existe, se crea
            if (!File.Exists(logFilePath))
            {
                File.Create(logFilePath).Close();
            }

            // Escribir el mensaje en el archivo con la fecha y el nivel de log
            using (StreamWriter sw = new StreamWriter(logFilePath, true))
            {
                string logMessage = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} [{level}] {message}";
                sw.WriteLine(logMessage);
            }
        }
        catch (Exception ex)
        {
            // Si ocurre un error al escribir el log, lo escribimos en la consola (para fines de desarrollo)
            Console.WriteLine($"Error al escribir el log: {ex.Message}");
        }
    }

    // Métodos específicos para diferentes niveles de log
    public static void Info(string message)
    {
        Log(message, "INFO");
    }

    public static void Warning(string message)
    {
        Log(message, "WARNING");
    }

    public static void Error(string message)
    {
        Log(message, "ERROR");
    }

    public static void Debug(string message)
    {
        Log(message, "DEBUG");
    }
}