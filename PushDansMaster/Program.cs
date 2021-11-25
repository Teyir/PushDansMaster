using System;
using System.Collections.Generic;


namespace PushDansMaster
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            
            /// TEST AJOUT D'UN FOURNISSEUR

            Console.WriteLine("Merci d'entrer le nom de la societe");
            string societe = Console.ReadLine();

           // Console.WriteLine("Merci d'entrer votre civilite");
            bool civilite = true;


            Console.WriteLine("Merci d'entrer votre nom");
            string nom = Console.ReadLine();

            Console.WriteLine("Merci d'entrer votre prenom");
            string prenom = Console.ReadLine();

            Console.WriteLine("Merci d'entrer votre email");
            string email = Console.ReadLine();

            Console.WriteLine("Merci d'entrer votre adresse");
            string adresse =  Console.ReadLine();

            var ezez = new Fournisseur(societe, civilite, nom, prenom, email, adresse);

            Console.WriteLine(ezez.societeFournisseur, ezez.civiliteFournisseur, ezez.nomFournisseur, ezez.prenomFournisseur, ezez.emailFournisseur, ezez.adresseFournisseur);
        }
    }
}
