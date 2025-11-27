using System;
using System.Collections.Generic;

public class GestioneStudenti
{
    private List<Studente> studenti;

    public GestioneStudenti()
    {
        studenti = new List<Studente>();
    }

    public void AggiungiStudente(string nome, string cognome, string matricola)
    {
        if (CercaPerMatricola(matricola) != null)
        {
            Console.WriteLine(" Errore: matricola già esistente.");
            return;
        }

        studenti.Add(new Studente(nome, cognome, matricola));
        Console.WriteLine(" Studente aggiunto con successo!");
    }

    public Studente CercaPerMatricola(string matricola)
    {
        foreach (var s in studenti)
            if (s.Matricola == matricola)
                return s;

        return null;
    }

    public void VisualizzaStudenti()
    {
        if (studenti.Count == 0)
        {
            Console.WriteLine(" Nessuno studente presente.");
            return;
        }

        Console.WriteLine("\n--- LISTA STUDENTI ---");
        foreach (var s in studenti)
            Console.WriteLine(s);
    }

    public void AggiungiVoto(string matricola, int voto)
    {
        Studente s = CercaPerMatricola(matricola);

        if (s == null)
        {
            Console.WriteLine(" Errore: matricola non trovata.");
            return;
        }

        s.AggiungiVoto(voto);
        Console.WriteLine(" Voto aggiunto!");
    }

    public void TrovaMigliore()
    {
        if (studenti.Count == 0)
        {
            Console.WriteLine(" Nessuno studente presente.");
            return;
        }

        Studente migliore = studenti[0];

        foreach (var s in studenti)
            if (s.Media > migliore.Media)
                migliore = s;

        Console.WriteLine("\n--- Studente con media più alta ---");
        Console.WriteLine(migliore);
    }
}
