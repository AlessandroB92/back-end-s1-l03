using System;

namespace back._end_s1_l03
{
    class ContoCorrente
    {
        // Proprietà del conto
        public string NomeCliente { get; private set; }
        public string CognomeCliente { get; private set; }
        public decimal Saldo { get; private set; }

        // Costruttore per creare un nuovo conto
        public ContoCorrente(string nomeCliente, string cognomeCliente)
        {
            NomeCliente = nomeCliente;
            CognomeCliente = cognomeCliente;
            Saldo = 0;
        }

        // Metodo per effettuare un versamento
        public void Versamento(decimal importo)
        {
            if (importo <= 0)
            {
                Console.WriteLine("Inserisci un valore valido!");
            }

            else
            {
                Saldo += importo;
                Console.WriteLine($"Versamento effettuato: {importo}");
                Console.WriteLine($"Nuovo saldo: {Saldo}");
            }
        }

        // Metodo per effettuare un prelevamento
        public void Prelevamento(decimal importo)
        {
            if (importo <= 0)
            {
                Console.WriteLine("L'importo del prelevamento deve essere maggiore di zero.");
            }

            if (importo > Saldo)
            {
                Console.WriteLine("Saldo non sufficiente...");
            
            }

            else
            {
                Saldo -= importo;
                Console.WriteLine($"Prelevamento di {importo} effettuato con successo.");
                Console.WriteLine($"Nuovo saldo: {Saldo}");
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Seleziona l'esercizio:  |  Contocorrente = 1  |  ArrayNomi = 2  |  SommaNumeriArray = 3  | ");
            string esercizio = Console.ReadLine();
            if (esercizio == "1")
            {

                Console.WriteLine("Vuoi aprire un conto? (Si/No)");
                string risposta = Console.ReadLine();

                if (risposta.ToLower() == "si")
                {
                    Console.WriteLine("Inserisci nome:");
                    string nomeTitolare = Console.ReadLine();
                    Console.WriteLine("Inserisci cognome:");
                    string cognomeTitolare = Console.ReadLine();

                    Console.WriteLine("Quanto vuoi depositare? (minimo 1000)");
                    decimal deposito = decimal.Parse(Console.ReadLine());

                    if (deposito < 1000)
                    {
                        Console.WriteLine("Il deposito minimo è di 1000. Operazione annullata.");
                        return;
                    }

                    ContoCorrente conto = new ContoCorrente(nomeTitolare, cognomeTitolare);
                    Console.WriteLine("Conto aperto con successo!");
                    Console.WriteLine($"Conto di:  {conto.NomeCliente} {conto.CognomeCliente}");

                    conto.Versamento(deposito);

                    // Loop per chiedere all'utente quale operazione eseguire
                    while (true)
                    {
                        Console.WriteLine("Che operazione vuoi eseguire? (1: Preleva, 2: Versa, 3: Chiudi)");
                        int scelta = int.Parse(Console.ReadLine());

                        switch (scelta)
                        {
                            case 1:
                                Console.WriteLine("Inserisci l'importo da prelevare:");
                                decimal importoPrelievo = decimal.Parse(Console.ReadLine());
                                conto.Prelevamento(importoPrelievo);
                                break;
                            case 2:
                                Console.WriteLine("Inserisci l'importo da versare:");
                                decimal importoVersamento = decimal.Parse(Console.ReadLine());
                                conto.Versamento(importoVersamento);
                                break;
                            case 3:
                                Console.WriteLine("Grazie per aver utilizzato il servizio. Arrivederci!");
                                return;
                            default:
                                Console.WriteLine("Scelta non valida. Riprova.");
                                break;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Operazione annullata.");
                }
            }
            if (esercizio == "2") 
            {

                // Chiedi all'utente il numero di nomi da inserire nell'array
                Console.Write("Inserisci il numero di nomi: ");
                int numNomi = int.Parse(Console.ReadLine());

                // Crea un array di stringhe di dimensione numNomi
                string[] nomi = new string[numNomi];

                // Carica i nomi nell'array
                for (int i = 0; i < numNomi; i++)
                {
                    Console.Write($"Inserisci il nome {i + 1}: ");
                    nomi[i] = Console.ReadLine();
                }

                // Chiedi all'utente il nome da cercare
                Console.Write("Inserisci il nome da cercare: ");
                string nomeDaCercare = Console.ReadLine();

                // Cerca il nome nell'array
                bool trovato = false;
                foreach (string nome in nomi)
                {
                    if (nome.Equals(nomeDaCercare.ToLower(), StringComparison.OrdinalIgnoreCase))
                    {
                        trovato = true;
                        break;
                    }
                }

                // Stampa se il nome è stato trovato o meno
                if (trovato)
                {
                    Console.WriteLine($"Il nome '{nomeDaCercare.ToLower()}' è presente nell'array.");
                }
                else
                {
                    Console.WriteLine($"Il nome '{nomeDaCercare.ToLower()}' non è presente nell'array.");
                }

            }

            if (esercizio == "3")
            {
                // Chiedi all'utente la dimensione dell'array
                Console.Write("Inserisci la dimensione dell'array: ");
                int dimensione = Convert.ToInt32(Console.ReadLine());

                // Crea un array di interi di dimensione specificata
                int[] numeri = new int[dimensione];

                // Carica i numeri nell'array
                for (int i = 0; i < dimensione; i++)
                {
                    Console.Write($"Inserisci il numero {i + 1}: ");
                    numeri[i] = Convert.ToInt32(Console.ReadLine());
                }

                // Calcola la somma dei numeri nell'array
                int somma = 0;
                foreach (int numero in numeri)
                {
                    somma += numero;
                }

                // Calcola la media aritmetica dei numeri nell'array
                double media = (double)somma / dimensione;

                // Stampa la somma e la media
                Console.WriteLine($"La somma di tutti i numeri inseriti è: {somma}");
                Console.WriteLine($"La media aritmetica di tutti i numeri inseriti è: {media}");
            }

            else 
            {
                Console.WriteLine("Comando inesistente!!");
                return;
            }

        }
    }
}
    
