using System;
using System.Collections.Generic;

public class Studente
{
    public string Nome { get; }
    public string Cognome { get; }
    public string Matricola { get; }

    private List<int> voti;

    public Studente(string nome, string cognome, string matricola)
    {
        Nome = nome;
        Cognome = cognome;
        Matricola = matricola;
        voti = new List<int>();
    }

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

    public override string ToString()
    {
        return $"{Nome} {Cognome} | Matricola: {Matricola} | Media: {Media:F2}";
    }
}
