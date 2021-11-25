using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            var reference = new List<string>();
            var libelle = new List<string>();
            var marque = new List<string>();

            using (var rd = new StreamReader(pathLink))
            {
                while (!rd.EndOfStream)
                {
                    var splits = rd.ReadLine().Split(';');
                    reference.Add(splits[0]);
                    libelle.Add(splits[1]);
                    marque.Add(splits[2]);
                }
            }

            // print references, libelles, marques

            Console.WriteLine("References:");
            foreach (var element in reference)
                Console.WriteLine(element);

            Console.WriteLine("Libelles:");
            foreach (var element in libelle)
                Console.WriteLine(element);

            Console.WriteLine("Marques:");
            foreach (var element in marque)
                Console.WriteLine(element);

        }

        //todo send to the database


    }
}
