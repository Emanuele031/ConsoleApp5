using System;

class Program
{
    static void Main()
    {
        GestioneStudenti gestione = new GestioneStudenti();
        int scelta = 0;

        do
        {
            MostraMenu();
            Console.Write("Scelta: ");

            // Validazione scelta menu
            if (!int.TryParse(Console.ReadLine(), out scelta))
            {
                Console.WriteLine(" Devi inserire un numero.");
                continue;
            }

            Console.Clear();

            switch (scelta)
            {
                case 1:
                    AggiungiStudenteUI(gestione);
                    break;

                case 2:
                    CercaStudenteUI(gestione);
                    break;

                case 3:
                    AggiungiVotoUI(gestione);
                    break;

                case 4:
                    gestione.VisualizzaStudenti();
                    break;

                case 5:
                    gestione.TrovaMigliore();
                    break;

                case 6:
                    Console.WriteLine("Uscita...");
                    break;

                default:
                    Console.WriteLine(" Scelta non valida.");
                    break;
            }

        } while (scelta != 6);
    }

    static void MostraMenu()
    {
        Console.WriteLine("\n==============================");
        Console.WriteLine("       GESTIONE STUDENTI");
        Console.WriteLine("==============================");
        Console.WriteLine("1  Aggiungi studente");
        Console.WriteLine("2  Cerca studente per matricola");
        Console.WriteLine("3  Aggiungi voto a studente");
        Console.WriteLine("4  Visualizza tutti gli studenti");
        Console.WriteLine("5  Studente con media più alta");
        Console.WriteLine("6  Esci");
        Console.WriteLine("==============================");
    }

    static void AggiungiStudenteUI(GestioneStudenti gestione)
    {
        Console.Write("Nome: ");
        string nome = Console.ReadLine();

        Console.Write("Cognome: ");
        string cognome = Console.ReadLine();

        Console.Write("Matricola: ");
        string matricola = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(nome) ||
            string.IsNullOrWhiteSpace(cognome) ||
            string.IsNullOrWhiteSpace(matricola))
        {
            Console.WriteLine(" Errore: tutti i campi sono obbligatori.");
            return;
        }

        gestione.AggiungiStudente(nome, cognome, matricola);
    }

    static void CercaStudenteUI(GestioneStudenti gestione)
    {
        Console.Write("Matricola da cercare: ");
        string m = Console.ReadLine();

        Studente s = gestione.CercaPerMatricola(m);

        if (s == null)
            Console.WriteLine(" Studente NON trovato.");
        else
            Console.WriteLine(s);
    }

    static void AggiungiVotoUI(GestioneStudenti gestione)
    {
        Console.Write("Matricola studente: ");
        string m = Console.ReadLine();

        Studente s = gestione.CercaPerMatricola(m);

        if (s == null)
        {
            Console.WriteLine(" Matricola non trovata. Operazione annullata.");
            return;
        }

        Console.Write("Inserisci voto: ");

        if (!int.TryParse(Console.ReadLine(), out int voto))
        {
            Console.WriteLine(" Errore: devi inserire un numero valido.");
            return;
        }

        gestione.AggiungiVoto(m, voto);
    }
}
