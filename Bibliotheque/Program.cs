using System;
using System.Text.Json;

public class Livre
{
    public string Nom_Livre {get; private set; }
    public string Nom_Auteur { get; private set; }
    public int Date { get; private set; }
    
    public Livre () {} //constructeur vide
    public Livre (string nom_livre, string nom_auteur, int date) 
    {
        this.Nom_Livre = nom_livre;
        this.Nom_Auteur = nom_auteur;
        this.Date = date;
    }
    public void Creation_Livre()
    {
        Console.WriteLine("nom livre : ");
        var nomlivre = Console.ReadLine();
        Console.WriteLine("nom auteur : ");
        var nomauteur = Console.ReadLine();
        Console.WriteLine("date livre : ");
        int datelivre = Int32.Parse(Console.ReadLine());
        var livre_créé = new Livre(nomlivre, nomauteur, datelivre); 
        string json = JsonSerializer.Serialize(livre_créé); //sérialisation du livre
        System.IO.File.WriteAllText("livre.json", json); //enregistrement dans un fichier JSON
    }

    public void Emprunt_Livre()
    {
        Console.WriteLine("nom livre : ");
        var nomlivre = Console.ReadLine();
        Console.WriteLine("nom auteur : ");
        var nomauteur = Console.ReadLine();
        Console.WriteLine("date livre : ");
        int datelivre = Int32.Parse(Console.ReadLine());
        var livre_emprunté = new Livre(nomlivre, nomauteur, datelivre);
    }
}


public class Program
{
    enum Options //creation de l'enum contenant les fonctions 
    {
        Ajouter_Livre = 1,
        Emprunt_Livre = 2,
        Rendu_Livre = 3,
    }
    static void Main(string[] args) 
    {
        Livre gestionLivre = new Livre();
        while (true) 
        {
            Console.WriteLine("Sélectionnez l'action à accomplir :");
            Console.WriteLine("1. Ajoutez un livre");
            Console.WriteLine("2. Emprunter un livre");
            Console.WriteLine("3. Rendre un livre");
            var choix_option = Console.ReadLine();  //essaie de faire en sorte que l'on puisse choisir les options à l'aide d'une variable qui se réinitialise
            
            if (int.TryParse(choix_option, out int choix))
            {
                switch ((Options) choix)
                {
                    case Options.Ajouter_Livre:
                    gestionLivre.Creation_Livre();
                    break;
                }
            }
        }
    }
}
            
