using PushDansMaster.DAL;
using System;
using System.Collections.Generic;
using System.IO;

namespace PushDansMaster
{
    public class importReferences
    {

        public void downloadFile()
        {
            string pathLink = "";

            while (!File.Exists(pathLink) || Path.GetExtension(pathLink) != ".csv")
            {

                Console.WriteLine("Merci d'entrer le chemin de votre fichier references.csv");
                pathLink = Console.ReadLine();

                if (!File.Exists(pathLink))
                {
                    Console.WriteLine("Erreur ! Fichier introuvable, merci de recommencer.");
                    pathLink = Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Fichier trouvé : " + pathLink);
                }


                if (Path.GetExtension(pathLink) != ".csv")
                {
                    Console.WriteLine("Erreur ! Fichier invalide, merci de recommencer de choisir un fichier .csv");
                    pathLink = Console.ReadLine();

                }
                else
                {
                    Console.WriteLine("Fichier trouvé : " + pathLink);
                }




            }

            /// Split csv file 

            List<string> reference = new List<string>();
            List<string> libelle = new List<string>();
            List<string> marque = new List<string>();

            using (StreamReader rd = new StreamReader(pathLink))
            {
                while (!rd.EndOfStream)
                {
                    string[] splits = rd.ReadLine().Split(';');
                    reference.Add(splits[0]);
                    libelle.Add(splits[1]);
                    marque.Add(splits[2]);
                }
            }

            // print references, libelles, marques

            Console.WriteLine("References:");
            foreach (string element in reference)
            {
                Console.WriteLine(element);
            }

            Console.WriteLine("Libelles:");
            foreach (string element in libelle)
            {
                Console.WriteLine(element);
            }

            Console.WriteLine("Marques:");
            foreach (string element in marque)
            {
                Console.WriteLine(element);
            }
        }

        private readonly ReferenceDepot_DAL dpr = new ReferenceDepot_DAL();





    }
}
