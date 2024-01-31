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
                throw new ArgumentException("L'importo del versamento deve essere maggiore di zero.");
            }

            Saldo += importo;
            Console.WriteLine($"Versamento effettuato: {importo}");
            Console.WriteLine($"Nuovo saldo: {Saldo}");
        }

        // Metodo per effettuare un prelevamento
        public void Prelevamento(decimal importo)
        {
            if (importo <= 0)
            {
                throw new ArgumentException("L'importo del prelevamento deve essere maggiore di zero.");
            }

            if (importo > Saldo)
            {
                throw new InvalidOperationException("Saldo insufficiente per effettuare il prelevamento.");
            }

            Saldo -= importo;
            Console.WriteLine($"Prelevamento di {importo} effettuato con successo.");
            Console.WriteLine($"Nuovo saldo: {Saldo}");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
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
    }
}
