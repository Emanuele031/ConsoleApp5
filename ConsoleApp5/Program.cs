using System;
using System.Collections;

public class Studente
{
    private string nome;
    private string cognome;
    private string matricola;
    private ArrayList voti;

    public Studente(string nome, string cognome, string matricola)
    {
        this.nome = nome;
        this.cognome = cognome;
        this.matricola = matricola;
        this.voti = new ArrayList();
    }

    public string Nome {get {return nome;} }
    public string Cognome { get {return cognome;} }
    public string Matricola { get {return matricola;} }

    public int NumeroVoti { get { return voti.Count; } }

    public double Media
    {
        get
        {
            if (voti.Count == 0) return 0;
            double somma = 0;

            foreach (int voto in voti)
                somma += voto;

            return somma / voti.Count;
        }
    }

    public void AggiungiVoto(int voto)
    {
        voti.Add(voto);
    }

    public void RimuoviUltimoVoto()
    {
        if (voti.Count > 0)
            voti.RemoveAt(voti.Count - 1);
    }

    public void StampaLibretto()
    {
        Console.WriteLine($"Libretto di {Nome} {Cognome} (Matricola {Matricola})");

        if (voti.Count == 0)
        {
            Console.WriteLine("Nessun voto presente.");
        }
        else
        {
            Console.Write("Voti: ");
            foreach (int voto in voti)
                Console.Write(voto + " ");
            Console.WriteLine();
        }

        Console.WriteLine($"\nMedia: {Media:F2}");
    }

    public override string ToString()
    {
        return $"{Nome} {Cognome} - Matricola: {Matricola} - Media: {Media:F2}";
    }
}
class Program
{
    static void Main()
    {
        ArrayList studenti = new ArrayList();
        int scelta;

        do
        {
            Console.WriteLine("\n==== MENU GESTIONE STUDENTI ====");
            Console.WriteLine("1. Aggiungi studente");
            Console.WriteLine("2. Cerca per matricola");
            Console.WriteLine("3. Aggiungi voto a studente");
            Console.WriteLine("4. Visualizza tutti");
            Console.WriteLine("5. Trova studente con media più alta");
            Console.WriteLine("6. Esci");
            Console.Write("Scelta: ");

            scelta = int.Parse(Console.ReadLine());
            Console.Clear();

            switch (scelta)
            {
                case 1: AggiungiStudente(studenti); break;
                case 2: CercaStudente(studenti); break;
                case 3: AggiungiVotoStudente(studenti); break;
                case 4: VisualizzaTutti(studenti); break;
                case 5: TrovaMigliore(studenti); break;
                case 6: Console.WriteLine("Uscita..."); break;
                default: Console.WriteLine("Scelta non valida!"); break;
            }

        } while (scelta != 6);
    }

    static void AggiungiStudente(ArrayList studenti)
    {
        Console.Write("Nome: ");
        string nome = Console.ReadLine();

        Console.Write("Cognome: ");
        string cognome = Console.ReadLine();

        Console.Write("Matricola: ");
        string matricola = Console.ReadLine();

        studenti.Add(new Studente(nome, cognome, matricola));
        Console.WriteLine("Studente aggiunto con successo!");
    }

    static Studente Cerca(ArrayList studenti, string matricola)
    {
        foreach (Studente s in studenti)
            if (s.Matricola == matricola)
                return s;

        return null;
    }

    static void CercaStudente(ArrayList studenti)
    {
        Console.Write("Inserisci matricola da cercare: ");
        string m = Console.ReadLine();

        Studente s = Cerca(studenti, m);

        if (s != null)
            Console.WriteLine(s);
        else
            Console.WriteLine("Studente NON trovato.");
    }

    static void AggiungiVotoStudente(ArrayList studenti)
    {
        Console.Write("Matricola studente: ");
        string m = Console.ReadLine();

        Studente s = Cerca(studenti, m);

        if (s == null)
        {
            Console.WriteLine("Studente non trovato.");
            return;
        }

        Console.Write("Inserisci voto: ");
        int voto = int.Parse(Console.ReadLine());

        s.AggiungiVoto(voto);

        Console.WriteLine("Voto aggiunto!");
    }

    static void VisualizzaTutti(ArrayList studenti)
    {
        if (studenti.Count == 0)
        {
            Console.WriteLine("Nessuno studente presente.");
            return;
        }

        Console.WriteLine("\n--- LISTA STUDENTI ---");
        foreach (Studente s in studenti)
            Console.WriteLine(s);
    }

    static void TrovaMigliore(ArrayList studenti)
    {
        if (studenti.Count == 0)
        {
            Console.WriteLine("Nessuno studente presente.");
            return;
        }

        Studente migliore = (Studente)studenti[0];

        foreach (Studente s in studenti)
            if (s.Media > migliore.Media)
                migliore = s;

        Console.WriteLine("\n--- Studente con media più alta ---");
        Console.WriteLine(migliore);
    }
}
