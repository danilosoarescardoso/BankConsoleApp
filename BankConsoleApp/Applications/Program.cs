using Bank.Business;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankConsoleApp
{
	public class Program
	{
		static ContaBancaria _contaBancaria;

		static void Main(string[] args)
		{
			int opcaoSelecionada;
			bool quit = false;
			do
			{
				Console.Clear();

				Console.WriteLine("1. Abrir Conta");
				Console.WriteLine("2. Depositar");
				Console.WriteLine("3. Resgatar");
				Console.WriteLine("4. Saldo");
				Console.WriteLine("5. Imprimir Extrato");
				Console.WriteLine("digite 0 para sair: ");

				opcaoSelecionada = int.Parse(Console.ReadLine());

				switch (opcaoSelecionada)
				{
				case 1:
					AbrirConta();
					break;
				case 2:
					Depositar();
					break;
				case 3:
					Resgatar();
					break;
				case 4:
					Saldo();
					break;
				case 5:
					ImprimirExtrato();
					break;
				case 0:
					quit = true;
					break;
				default:
					Console.WriteLine("Wrong choice.");
					break;
				}
					


			} while (!quit);

			Console.WriteLine("Bye!");
		}

		private static void ImprimirExtrato()
		{
			Console.Clear();
			Console.WriteLine(_contaBancaria.ImprimirExtrato());
			Console.WriteLine("Pressione qualquer tecla para retornar ao menu...");
			Console.ReadKey();
		}

		private static void Saldo()
		{
			Console.Clear();
			Console.WriteLine("Seu saldo é: " + _contaBancaria.Saldo.ToString("C", CultureInfo.CreateSpecificCulture("pt-BR")));
			Console.WriteLine("Pressione qualquer tecla para retornar ao menu...");
			Console.ReadKey();
		}

		private static void Resgatar()
		{
			Console.Clear();
			Console.Write("Informe o valor a ser resgatado: ");

			decimal valorResgate = decimal.Parse(Console.ReadLine());

			_contaBancaria.Resgatar(valorResgate);

			Console.Clear();
			Console.WriteLine("Resgate efetuado sucesso!");
			Console.WriteLine("Pressione qualquer tecla para retornar ao menu...");
			Console.ReadKey();
		}

		private static void Depositar()
		{
			Console.Clear();
			Console.Write("Informe o valor a ser depositado: ");

			decimal valorDeposito = decimal.Parse(Console.ReadLine());

			_contaBancaria.Depositar(valorDeposito);

			Console.Clear();
			Console.WriteLine("Deposito efetuado sucesso!");
			Console.WriteLine("Pressione qualquer tecla para retornar ao menu...");
			Console.ReadKey();
		}

		private static void AbrirConta()
		{
			Console.Clear();
			Console.Write("Informe o saldo inicial: ");

			decimal saldoInicial = decimal.Parse(Console.ReadLine());

			try {
				_contaBancaria = new ContaPremium(saldoInicial);
			} catch (Exception ex) {
				Console.WriteLine (ex.Message);
				Console.ReadKey ();
				return;
			}


			Console.Clear();
			Console.WriteLine("Conta aberta com sucesso!");
			Console.WriteLine("Pressione qualquer tecla para retornar ao menu...");
			Console.ReadKey();
		}
	}
}