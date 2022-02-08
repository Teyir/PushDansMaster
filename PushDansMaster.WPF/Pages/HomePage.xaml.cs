using Microsoft.Extensions.Configuration;
using System;
using System.Data.SqlClient;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;

namespace PushDansMaster.WPF.Pages
{
    public partial class HomePage : Page
    {
        public HomePage()
        {
            InitializeComponent();
        }

        //Import sql file
        private bool importSql()
        {
            string fileName = "import.sql";
            //Get the sqlserver configuration
            var builder = new ConfigurationBuilder();
            var config = builder.AddJsonFile("appsettings.json", false, true).Build();

            var connectionString = config.GetSection("ConnectionStrings:default").Value;


            try
            {
                string script = File.ReadAllText(fileName);

                System.Collections.Generic.IEnumerable<string> commandStrings = Regex.Split(script, @"^\s*GO\s*$",
                                         RegexOptions.Multiline | RegexOptions.IgnoreCase);
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    foreach (string commandString in commandStrings)
                    {
                        if (commandString.Trim() != "")
                        {
                            using (var command = new SqlCommand(commandString, connection))
                            {
                                try
                                {
                                    command.ExecuteNonQuery();
                                }
                                catch (SqlException ex)
                                {
                                    string spError = commandString.Length > 100 ? commandString.Substring(0, 100) + " ...\n..." : commandString;
                                    MessageBox.Show(string.Format("Merci de vérifier votre script sql.\nFichier: {0} \nLigne: {1} \nErreur: {2} \nSQL Command: \n{3}", fileName, ex.LineNumber, ex.Message, spError), "Warning");
                                    return false;
                                }
                            }
                        }
                    }
                    connection.Close();
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Warning");
                return false;
            }
        }


    }
}